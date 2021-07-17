# startup-delayed

A simple program that runs the specified applications and batch files as soon as they become available along the specified paths (for example, when connecting a network, external or encrypted disk)

## v 0.0.2

+ Fixed bug with saving configuration when deleting entries (thanks to SCPicker for testing and reporting)

+ Removed the mode of selecting the configuration directory from the command line. 

+ Optimized detection startup programs.

+ Fixed other minor bugs.

------------------------------------------------

Простая программа, запускающая указанные приложения и командные файлы, как только они становятся доступными по указанным путям (например, при подключении сетевого, внешнего или зашифрованного диска)

## v 0.0.2

+ Исправлен баг с сохранением конфигурации при удалении записей (спасибо SCPicker за тестирование и сообщение).

+ Убран режим выбора каталога конфигурации из командной строки, оставлен только обычный (файлы конфигурации в LocalApplicationData\StartupDelayed\) и портативный (файлы конфигурации в директории с программой).

+ Оптимизировано обнаружение запускаемых программ, сначала программа проверяет наличие соответствующего диска, если не задан относительный или сетевой путь.

+ Исправлены прочие мелкие недочеты.