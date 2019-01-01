using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiThreadSort.Data;

namespace MultiThreadSort
{
    class Program
    {
        static void Main()
        {
            var watch = Stopwatch.StartNew();
            DataBase dat = new DataBase(1000, 1000, 0, 1000000);
            //DataBase dat2 = new DataBase(10000, 10000, 0, 1000000);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Created in {elapsedMs} ms");

            //watch.Restart();
            //dat.SingleThreadSort();
            //watch.Stop();
            //elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine($"Single thread sort time = {elapsedMs} ms");

            watch.Restart();
            dat.MultiThreadSort();
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Multi thread sort time = {elapsedMs} ms");

            Console.ReadKey(false);
        }
    }
}
