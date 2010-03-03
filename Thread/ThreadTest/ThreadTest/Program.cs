using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using System.IO;

namespace ThreadTest
{
    class Program
    {
        static void Main()
        {
            IList<string> FileNameList = GetFile();
            int FibonacciCalculations = FileNameList.Count;

            // One event is used for each Fibonacci object
            ManualResetEvent[] doneEvents = new ManualResetEvent[FibonacciCalculations];           
            Console.WriteLine("launching {0} tasks...{1}", FibonacciCalculations, DateTime.Now);
            for (int i = 0; i < FibonacciCalculations; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                GetXmlStr f = new GetXmlStr(FileNameList[i], doneEvents[i]);                
                ThreadPool.QueueUserWorkItem(f.Action, FileNameList[i]);
            }

            // Wait for all threads in pool to calculation...
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All calculations are complete.结束{0}", FibonacciCalculations, DateTime.Now);            
        }
        static IList<string> GetFile()
        {
            string path = System.Environment.CurrentDirectory.ToString();
            path = path.Replace("bin\\Debug", "contet\\");
            IList<string> filenames = Directory.GetFiles(path);
            return filenames;
        }     
    }
}
