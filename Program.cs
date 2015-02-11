using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace LSLoginBypass
{
    class Program
    {
        readonly static string HOSTS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\etc\\hosts";

        static void Welcome()
        {
            Console.WriteLine("LeagueSharp L# Login Auth Bypasser");
            Console.WriteLine("by NitroXenon");
            Console.WriteLine("My blog : http://nitroxenon.com");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Welcome();
            if (args.Length != 1)
            {
                Exit("No args, np command <3");
            }
            File.SetAttributes(HOSTS_PATH, FileAttributes.Normal);
            if (args[0] == "--go")
            {
                File.Copy(HOSTS_PATH, HOSTS_PATH.Replace("hosts", "hosts_bak"),true);
                File.Delete(HOSTS_PATH);
                File.Create(HOSTS_PATH).Close();

                using (var reader = new StreamReader(HOSTS_PATH.Replace("hosts", "hosts_bak")))
                {
                    using (var writer = new StreamWriter(HOSTS_PATH, false, Encoding.Default))
                    {
                        while (!reader.EndOfStream)
                            writer.WriteLine(reader.ReadLine());
                        writer.WriteLine("50.87.204.226 loader.joduska.me");
                        writer.WriteLine();
                    }
                }
                Exit("Bypass success!");
            }
            if (args[0] == "--restore")
            {
                using (var reader = new StreamReader(HOSTS_PATH.Replace("hosts", "hosts_bak")))
                {
                    using (var writer = new StreamWriter(HOSTS_PATH,false,Encoding.Default))
                    {
                        while (!reader.EndOfStream)
                        {
                            string tempStr = reader.ReadLine();
                            if (!tempStr.StartsWith("50.87.204.226"))
                                writer.WriteLine(tempStr);
                        }
                    }
                }
                Exit("Restore success!");
            }
        }

        static void Exit(string message = "")
        {
            if (!(message == "" || String.IsNullOrEmpty(message)))
            {
                Console.WriteLine(message);
            }
            Console.Write("LSLoginBypass will be automatically exited after 5 seconds");
            System.Threading.Thread.Sleep(1000);
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            Console.Write(".");
            Environment.Exit(0);
        }
    }
}
