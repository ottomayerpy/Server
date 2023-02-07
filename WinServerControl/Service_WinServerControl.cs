using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;
using System.ServiceProcess;
using WinServerControl.Properties;

namespace WinServerControl
{
    public partial class Service_WinServerControl : ServiceBase
    {
        public Service_WinServerControl() => InitializeComponent();

        protected override void OnStart(string[] args)
        {
            Thread Th = new Thread(StartServer) { IsBackground = true };
            Th.Start();
        }

        protected override void OnStop()
        {
            Settings.Default.Log += "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": (wsc)Сервер завершает работу\n";
            Settings.Default.Save();
        }

        private void StartServer()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Создаем сокет
            socket.Bind(new IPEndPoint(IPAddress.Any, 8006)); // Получив адреса для запуска сокета, связываем сокет с локальной точкой, по которой будем принимать данные
            socket.Listen(10); // Начинаем прослушивание

            Settings.Default.Log += "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": (wsc)Сервер запущен\n";
            Settings.Default.Save();

            while (true)
            {
                try
                {
                    Socket handler = socket.Accept(); // Создаем новый сокет
                    StringBuilder builder = new StringBuilder();
                    byte[] data = new byte[256]; // Буфер для получаемых данных

                    do
                    {
                        int bytes = handler.Receive(data); // Получаем число принятых байт
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes)); // Конвертируем байты в строку и записываем в StringBuilder
                    }
                    while (handler.Available > 0); // Проверяем есть ли доступные данные в сокете для чтения

                    if (builder.ToString() == null) // Если из сокета ничего не получено, прекращаем текущую итерацию цикла
                        break;

                    string message = null; // Переменная для ответа клиенту
                    string[] Com = { builder.ToString().Substring(0, 1), null, null, }; // Буффер для комманд

                    try
                    {
                        // Разбиваем строку на команды
                        if (!builder.ToString().Contains("?"))
                            Com[1] = builder.ToString().Substring(1); // One Path
                        else
                        {
                            int index = builder.ToString().IndexOf("?");
                            Com[1] = builder.ToString().Substring(1, index - 1); // One Path
                            Com[2] = builder.ToString().Substring(index + 1); // Two Path
                        }
                    }
                    catch (Exception ex)
                    {
                        Settings.Default.Log += "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": (wsc)Ошибка Com[]: " + ex.Message + "\n";
                        Settings.Default.Save();
                    }

                    switch (Com[0])
                    {
                        case "c": // Connect
                            message = "(wsc)Сервер запущен. Ожидание подключений...";
                            break;
                        case "l": // Log
                            if (Settings.Default.Log == null)
                                message = "(wsc)В лог файле отсутствуют записи";
                            else
                                message = "(wsc)\n" + Settings.Default.Log;
                            break;
                        case "e": // Clear Log
                            Settings.Default.Log = null;
                            Settings.Default.Save();
                            message = "(wsc)Лог файл очищен";
                            break;
                        case "s": // Start Service
                            message = StartService(Com[1]);
                            break;
                        case "d": // Stop Service
                            message = StopService(Com[1]);
                            break;
                        case "r": // Restart Service
                            message = RestartService(Com[1]);
                            break;
                        case "x": // Exit
                            Process.GetCurrentProcess().Kill();
                            break;
                        case "u": // Update
                            if (!File.Exists(@"C:\Windows\MSS\mss.exe"))
                            {
                                message = string.Format("(wsc)Error 'FileExists': Файл {0} не найден", Path.GetTempPath() + "mss.exe");
                                break;
                            }
                            
                            StopService("mss");
                            new WebClient().DownloadFile(Com[1], @"C:\Windows\MSS\temp_mss.exe");
                            File.Delete(@"C:\Windows\MSS\mss.exe");
                            File.Move(@"C:\Windows\MSS\temp_mss.exe", @"C:\Windows\MSS\mss.exe");
                            StartService("mss");
                            message = "(wsc)Обновление прошло успешно!";
                            break;
                        default:
                            message = "(wsc)Команда не определена";
                            break;
                    }

                    if (message == null)
                        message = "(wsc)Сервер не ответил";
                    handler.Send(Encoding.Unicode.GetBytes(message));
                    handler.Shutdown(SocketShutdown.Both); // Закрываем сокет
                    handler.Close();
                }
                catch (Exception ex)
                {
                    Settings.Default.Log += "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": (wsc)Ошибка сервера: " + ex.Message + "\n";
                    Settings.Default.Save();
                }
            }
        }

        // Запуск службы
        public string StartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            // Проверяем не запущена ли служба
            if (service.Status != ServiceControllerStatus.Running)
            {
                // Запускаем службу
                service.Start();
                // В течении минуты ждём статус от службы
                service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMinutes(1));
                return "(wsc)Служба была успешно запущена!";
            }
            else
            {
                return "(wsc)Служба уже запущена!";
            }
        }

        // Останавливаем службу
        public string StopService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            // Если служба не остановлена
            if (service.Status != ServiceControllerStatus.Stopped)
            {
                // Останавливаем службу
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMinutes(1));
                return "(wsc)Служба была успешно остановлена!";
            }
            else
            {
                return "(wsc)Служба уже остановлена!";
            }
        }

        // Перезапуск службы
        public string RestartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            TimeSpan timeout = TimeSpan.FromMinutes(1);

            if (service.Status != ServiceControllerStatus.Stopped)
            {
                // Останавливаем службу
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            }
            if (service.Status != ServiceControllerStatus.Running)
            {
                // Запускаем службу
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            return "(wsc)Служба была успешно перезапущена!";
        }
    }
}