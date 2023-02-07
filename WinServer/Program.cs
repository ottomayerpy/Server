using System.ServiceProcess;

namespace WinServer
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service_WinServer()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}