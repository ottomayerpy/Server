using System;
using System.IO;
using System.Net;

namespace WinServerWinForms
{
    public static class Command
    {
        const string Url = "http://winserver.mcdir.ru/command/";

        public static string Add(string data)
        {
            return GET($"{Url}add/?{data}");
        }

        public static string Check(string data)
        {
            return GET($"{Url}check/?{data}");
        }

        public static string CheckResult()
        {
            return GET($"{Url}checkresult/");
        }

        public static string Perform(string data)
        {
            return GET($"{Url}perform/?{data}");
        }

        public static string OnlineCheck()
        {
            return GET($"{Url}online/?command=check");
        }

        public static string OnlineAdd()
        {
            return GET($"{Url}online/?command=add&user={Environment.MachineName}");
        }

        public static string OnlineRemove()
        {
            return GET($"{Url}online/?command=remove&user={Environment.MachineName}");
        }

        private static string GET(string Data)
        {
            WebRequest req = WebRequest.Create(Data);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
    }
}
