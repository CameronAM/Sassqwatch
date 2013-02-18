using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sassqwatch
{
    class Program
    {
        private static ManualResetEvent waitHandle = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var watcher = new FileSystemWatcher
                {
                    Path = @"C:\Development\SmartClinics.HealthMax",
                    Filter = "*.scss",
                    IncludeSubdirectories = true
                };

            watcher.Changed += WatcherOnChanged;

            watcher.EnableRaisingEvents = true;

            while (true)
            {
                waitHandle.WaitOne();
            }
        }

        private static void WatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            Console.WriteLine("{0} {1} {2}", fileSystemEventArgs.FullPath, fileSystemEventArgs.ChangeType, DateTime.Now.Ticks);
        }
    }
}
