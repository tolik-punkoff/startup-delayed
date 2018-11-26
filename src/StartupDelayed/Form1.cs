using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wildsoft.About;

namespace StartupDelayed
{
    public partial class frmMain : Form
    {        

        public frmMain()
        {
            InitializeComponent();
        }

        AppSettingsManager SetMan = null;
        TasksManager TaskMan = null;
        Timer tmpTimer = new Timer();
        bool runningExit = false;
        bool allComplete = false;

        private void frmMain_Load(object sender, EventArgs e)
        {
            niMain.Visible = false;
            NIWorker.niMain = niMain;
            SetMan = new AppSettingsManager();
            if (!SetMan.LoadConfig())
            {
                MessageBox.Show(SetMan.ConfigError, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            TaskMan = new TasksManager(SetMan.TasksFile);

            if (!TaskMan.LoadTasks())
            {
                MessageBox.Show(TaskMan.ErrorMessage, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (CommonClass.Running) this.Hide();
            this.Text = "Отложенная автозагрузка [Режим настройки]";
            
            grdMain.DataSource = TaskMan.dsTasks.Tables["StartupTasks"].DefaultView;
            grdMain.Columns[0].Visible = false;
            grdMain.Columns[1].HeaderText = "Название";
            grdMain.Columns[2].HeaderText = "Путь";
            grdMain.Columns[3].HeaderText = "Параметры";
            grdMain.Columns[4].HeaderText = "Каталог";
            grdMain.Columns[5].HeaderText = "Окно";
            grdMain.Columns[6].HeaderText = "Админ";
            grdMain.Columns[7].HeaderText = "Активна";
            grdMain.Columns.Add("Status", "Статус");
            
            if (CommonClass.Running)
            {
                runningExit = false;
                allComplete = false;

                if (!TaskMan.CreateTasks())
                {
                    NIWorker.ShowError(0, TaskMan.ErrorMessage);
                }
                

                mnuEdit.Visible = false;                
                grdMain.Enabled = false;
                this.Text = "Отложенная автозагрузка [Просмотр выполняемых задач]";

                TaskMan.TypeTime = SetMan.Settings.CheckTimeType;
                TaskMan.Interval = SetMan.Settings.CheckTime;
                TaskMan.TaskManagerStatusChanged += new TasksManager.OnTaskManagerStatusChanged(TaskMan_TaskManagerStatusChanged);
                TaskMan.TaskStatusChanged += new TasksManager.OnTaskStatusChanged(TaskMan_TaskStatusChanged);
                NIWorker.Start();
                TaskMan.StartTasks();                
            }
        }

        void TaskMan_TaskStatusChanged(object sender, TaskStatusEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                StartupTask task = (StartupTask)sender;
                int N = 0;

                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    int v = (int)grdMain.Rows[i].Cells["ID"].Value;
                    if (v == task.ID)
                    {
                        N = i;
                        break;
                    }
                }

                switch (e.Status)
                {
                    case TaskStatus.OK:
                        {
                            grdMain.Rows[N].Cells["Status"].Style.ForeColor =
                                Color.Green;
                            grdMain.Rows[N].Cells["Status"].Value = "OK";

                        }; break;
                    case TaskStatus.Wait:
                        {
                            grdMain.Rows[N].Cells["Status"].Style.ForeColor =
                                Color.Blue;
                            grdMain.Rows[N].Cells["Status"].Value = "Wait...";
                        }; break;
                    case TaskStatus.Error:
                        {
                            grdMain.Rows[N].Cells["Status"].Style.ForeColor =
                                Color.Red;
                            grdMain.Rows[N].Cells["Status"].Value = e.Message;

                        }; break;
                }
            });
        }

        void TaskMan_TaskManagerStatusChanged(object sender, TaskManagerStatusEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                switch (e.Status)
                {
                    case TaskManagerStatus.Complete:
                        {                            
                            if (TaskMan.NoActiveTasks)
                            {
                                niMain.Text = "Отложенная автозагрузка. Нет активных задач.";
                            }
                            else
                            {
                                niMain.Text = "Отложенная автозагрузка. Все задачи запущены.";
                            }
                            if (SetMan.Settings.CloseAfterSuccess)
                            {
                                NIWorker.ShowOK(5000);
                                tmpTimer.Interval = 5500;
                                tmpTimer.Tick += new EventHandler(tmpTimer_Tick);
                                tmpTimer.Start();
                            }
                            else
                            {
                                NIWorker.ShowOK(0);
                            }
                            allComplete = true;
                        }; break;
                    case TaskManagerStatus.CompleteWithErrors:
                        {
                            NIWorker.ShowError(0, "При запуске задач произошли ошибки!");
                            allComplete = true;
                        }; break;
                    case TaskManagerStatus.Pause:
                        {
                            NIWorker.Pause("Приостановлено пользователем!");
                            cmnuMainStop.Text = "Возобновить";
                        }; break;
                    case TaskManagerStatus.Continue:
                        {
                            NIWorker.Continue("");
                            cmnuMainStop.Text = "Остановить";
                        }; break;                    
                }                
            });
        }

        void tmpTimer_Tick(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                runningExit = true;
                this.Close();
            }
        }

        private void grdMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mnuEditEdit_Click(null, null);
        }

        private void grdMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdMain.CurrentCell == null) return;
            
            //булевы данные можно изменять прямо из грида
            if (grdMain.CurrentCell.ValueType == typeof(bool))
            {
                grdMain.CurrentCell.Value =
                    (!(bool)grdMain.CurrentCell.Value);

                if (!TaskMan.SaveTasks())
                {
                    MessageBox.Show(TaskMan.ErrorMessage, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void grdMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grdMain.Columns[e.ColumnIndex].Name == "WindowStyle")
            {
                
                object val = grdMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    Enum.GetName(typeof(System.Diagnostics.ProcessWindowStyle), val);
                }
                catch { return; }

                System.Diagnostics.ProcessWindowStyle wstyle =
                    (System.Diagnostics.ProcessWindowStyle)val;
                    

                switch (wstyle)
                {
                    case System.Diagnostics.ProcessWindowStyle.Normal:
                        {
                            e.Value = "Нормальное";
                        }; break;
                    case System.Diagnostics.ProcessWindowStyle.Maximized:
                        {
                            e.Value = "Развернутое";
                        }; break;
                    case System.Diagnostics.ProcessWindowStyle.Minimized:
                        {
                            e.Value = "Свернутое";
                        }; break;
                }
            }
        }

        private void mnuEditAdd_Click(object sender, EventArgs e)
        {
            frmAdd fAdd = new frmAdd();
            fAdd.dsMain = TaskMan.dsTasks;
            fAdd.IsEdit = false;
            DialogResult Res = fAdd.ShowDialog();
            if (Res == DialogResult.OK)
            {
                if (!TaskMan.SaveTasks())
                {
                    MessageBox.Show(TaskMan.ErrorMessage, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void mnuEditDelete_Click(object sender, EventArgs e)
        {
            if (grdMain.CurrentRow == null) return;
            if (TaskMan.dsTasks == null) return;
            
            object curID = grdMain.CurrentRow.Cells["ID"].Value;
            DataRow dr = TaskMan.dsTasks.Tables["StartupTasks"].Rows.Find(curID);
            //не нашли
            if (dr == null) return;

            string taskname = dr["TaskName"].ToString();
            DialogResult Ans = MessageBox.Show("Удалить '" + taskname + "'?",
                "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Ans != DialogResult.Yes) return;

            TaskMan.dsTasks.Tables["StartupTasks"].Rows.Remove(dr);

        }

        private void mnuEditEdit_Click(object sender, EventArgs e)
        {
            if (grdMain.CurrentRow == null) return;
            if (TaskMan.dsTasks == null) return;

            object curID = grdMain.CurrentRow.Cells["ID"].Value;

            frmAdd fAdd = new frmAdd();
            fAdd.dsMain = TaskMan.dsTasks;
            fAdd.IsEdit = true;
            fAdd.idValue = curID;
            DialogResult Res = fAdd.ShowDialog();
            if (Res == DialogResult.OK)
            {
                if (!TaskMan.SaveTasks())
                {
                    MessageBox.Show(TaskMan.ErrorMessage, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        

        private void mnuFileSettings_Click(object sender, EventArgs e)
        {
            frmAppSettings fAS = new frmAppSettings();
            fAS.ASM = SetMan;
            DialogResult Ans = fAS.ShowDialog();
            if (Ans == DialogResult.OK)
            {
                MessageBox.Show("Сохраненные настройки будут применены при следующем запуске", 
                    "Настройки сохранены успешно", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        
        private void mnuHelpCLI_Click(object sender, EventArgs e)
        {
            frmCLIHelp fch = new frmCLIHelp();
            fch.ShowDialog();
        }

        private void mnuFileConfigs_Click(object sender, EventArgs e)
        {
            frmConfigFiles fCF = new frmConfigFiles();
            fCF.SetMan = SetMan;
            fCF.ShowDialog();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            string exitMess = "Вы действительно хотите выйти?";
            if (CommonClass.Running && (!allComplete))
            {                
                exitMess += "\n Некоторые задачи останутся невыполнены.";                                
            }

            DialogResult Ans = MessageBox.Show(exitMess, "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Ans == DialogResult.No) return;

            if (CommonClass.Running) runningExit = true;
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CommonClass.Running && (!runningExit))
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void cmnuMainExit_Click(object sender, EventArgs e)
        {
            mnuFileExit_Click(null, null);
        }

        private void cmnuMainShow_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void cmnuMainStop_Click(object sender, EventArgs e)
        {
            TaskMan.PauseContinue();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            frmAbout fAbout = new frmAbout();
            fAbout.ShowDialog();
        }
        
        
    }
}
