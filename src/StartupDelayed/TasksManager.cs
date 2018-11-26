using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Reflection;
using System.Timers;

namespace StartupDelayed
{
    public class TaskStatusEventArgs : EventArgs
    {
        public TaskStatus Status { get; set; }        
        public string Message { get; set; }
    }
    public class TaskManagerStatusEventArgs : EventArgs
    {
        public TaskManagerStatus Status { get; set; }
    }

    public enum TaskManagerStatus
    {
        Start = 0,
        Complete = 1,
        CompleteWithErrors = 2,
        Pause = 4,
        Continue = 5
    }
    
    public enum TaskStatus
    {
        OK = 0,
        Wait = 1,
        Error = 2
    }
    public class TasksManager
    {
        public delegate void OnTaskStatusChanged(object sender, 
            TaskStatusEventArgs e);
        public delegate void OnTaskManagerStatusChanged(object sender, 
            TaskManagerStatusEventArgs e);

        public event OnTaskStatusChanged TaskStatusChanged;
        public event OnTaskManagerStatusChanged TaskManagerStatusChanged;

        public MainDataSet dsTasks = null;
        public bool NoActiveTasks { get; private set; } 
        public string ErrorMessage { get; private set; }
        public TimeType TypeTime
        {
            get
            {
                return typetime;
            }
            set
            {
                typetime = value;
                if (typetime == TimeType.Secs) TimeMul = 1000;
                else TimeMul = 1000 * 60;
            }
        }
        public int Interval
        {
            get
            {
                return (int)(checkInterval / TimeMul);
            }
            set 
            {
                checkInterval = value * TimeMul;
            }
        }
        public bool Pause { get; private set; }
        
        private string TasksFile = null;
        private List<StartupTask> TasksList = new List<StartupTask>();
        private string TableName = "StartupTasks";
        private Timer CheckTimer = null;
        private double TimeMul = 1000;
        private TimeType typetime = TimeType.Secs;
        private double checkInterval = 30;
        private bool IsErrors = false;


        public TasksManager(string filename)
        {
            TasksFile = filename;
            NoActiveTasks = false;
            Pause = false;

        }

        public bool LoadTasks()
        {
            dsTasks = new MainDataSet();

            if (!File.Exists(TasksFile)) return true;

            try
            {
                dsTasks.ReadXml(TasksFile);
            }
            catch (Exception ex)
            {
                
                ErrorMessage = ex.Message;
                return false;
            }
            
            return true;
        }

        public bool SaveTasks()
        {
            if (dsTasks == null)
            {
                ErrorMessage = "Задачи не загружены";
                return false;
            }
            
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(TasksFile));
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }

            try
            {
                dsTasks.WriteXml(TasksFile);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }

            return true;
        }

        private StartupTask CreateTask(DataRow dr)
        {
            StartupTask task = new StartupTask(null);

            PropertyInfo[] properties = task.GetType().GetProperties();
            foreach (PropertyInfo pr in properties)
            {
                string propName = pr.Name;
                if (dr.Table.Columns.Contains(propName))
                {
                    object propValue = dr[propName];
                    if (propValue.GetType() != typeof(System.DBNull))
                    {
                        pr.SetValue(task, propValue, null);
                    }
                }
            }

            return task;
        }

        public bool CreateTasks()
        {
            NoActiveTasks = false;
            if (!LoadTasks()) return false;
            if (dsTasks.Tables[TableName].Rows.Count == 0)
            {
                NoActiveTasks = true;
                return true;
            }

            foreach (DataRow dr in dsTasks.Tables[TableName].Rows)
            {
                if ((bool)dr["ActiveTask"])
                {
                    StartupTask task = CreateTask(dr);
                    TasksList.Add(task);
                }
            }

            if (TasksList.Count == 0) NoActiveTasks = true;

            return true;
        }

        public void StartTasks()
        {
            IsErrors = false;
            Pause = false;
            if (TasksList.Count == 0)
            {
                Complete();
                return;
            }

            CheckTimer = new Timer();
            CheckTimer.AutoReset = true;
            CheckTimer.Interval = checkInterval;
            CheckTimer.Elapsed += new ElapsedEventHandler(CheckTimer_Elapsed);
            TaskManagerStatusEventArgs e = new TaskManagerStatusEventArgs();
            e.Status = TaskManagerStatus.Start;
            if (TaskManagerStatusChanged != null)
                TaskManagerStatusChanged(this, e);
            CheckStart(); 
        }

        private void CheckStart() //основная функция по проверке и запуску задачи
        {            
            foreach (StartupTask task in TasksList) //пробегаемся по списку задач
            {
                if (task.Complete)
                {                    
                    continue;
                }
                
                TaskStatusEventArgs earg = new TaskStatusEventArgs();
                earg.Status = TaskStatus.Wait;
                earg.Message = string.Empty;

                if (task.Exist()) //файл на месте
                {
                    if (!task.Run()) //ошибка при выполнении
                    {
                        earg.Status = TaskStatus.Error;
                        earg.Message = task.ErrorMessage;
                        IsErrors = true;

                    }
                    else //выполнено успешно
                    {
                        earg.Status = TaskStatus.OK;
                    }
                    task.Complete = true; //задача выполнена так или иначе                    
                }
                //файла нет, проверим на следующей итерации

                //генерируем событие
                if (TaskStatusChanged != null)
                {
                    TaskStatusChanged(task, earg);
                }
            }

            int cmplCount = 0; //подсчитываем количество выполненных задач
            foreach (StartupTask task in TasksList)
            {
                if (task.Complete) cmplCount++;
            }
            
            if (TasksList.Count == cmplCount) //все задачи кончились
            {
                //завершаемся
                Complete();
                return;
            }
            else
            {
                //запускаем таймер обратно
                CheckTimer.Start();
            }
        }

        void CheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckTimer.Stop(); //останавливаем таймер
            CheckStart();            
        }

        private void Complete()
        {
            TaskManagerStatusEventArgs e = new TaskManagerStatusEventArgs();

            if (IsErrors)
            {
                e.Status = TaskManagerStatus.CompleteWithErrors;
            }
            else
            {
                e.Status = TaskManagerStatus.Complete;
            }

            if (TaskManagerStatusChanged != null)
                TaskManagerStatusChanged(this, e);
        }

        public void PauseContinue()
        {
            TaskManagerStatusEventArgs e = new TaskManagerStatusEventArgs();
            if (Pause) //пауза - стартуем заново
            {
                if (TasksList.Count == 0) return;
                e.Status = TaskManagerStatus.Continue;
                //событие
                if (TaskManagerStatusChanged != null)
                    TaskManagerStatusChanged(this, e);
                CheckStart();
            }
            else //останавливаемся
            {
                e.Status = TaskManagerStatus.Pause;
                //событие
                if (TaskManagerStatusChanged != null)
                    TaskManagerStatusChanged(this, e);
                CheckTimer.Stop();
            }

            //инвертируем флаг
            Pause = !Pause;            
        }
    }
}
