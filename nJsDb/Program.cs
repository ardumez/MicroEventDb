using nJsDb.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nJsDb
{
    class Program
    {

        public static ManualResetEvent ShutdownServerMre = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Server starting...");

            var server = new ServerEngine();
            server.Load();

            while(true)
            {
                Console.WriteLine("Start command...");

                var command = Console.ReadLine();
                var argsCmd = command.Split(' ');



                if (argsCmd[0] == "find")
                {
                    var entity = argsCmd[1];
                    var id = argsCmd[2];
                    server.find(entity, id, result => Console.WriteLine(result));
                }

                if (argsCmd[0] == "run")
                {
                    var entity = argsCmd[1];
                    var id = argsCmd[2];

                    ThreadPool.QueueUserWorkItem(ThreadProc);
                    server.find(entity, id, result => Console.WriteLine(result));
                }

                if (argsCmd[0] == "help")
                {
                    
                }
            }

            ShutdownServerMre.WaitOne();
        }
    }
}
