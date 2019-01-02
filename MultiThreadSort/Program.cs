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
            const int debugSize = 20000;

            Console.WriteLine("Creating");
            DataBase dat1 = new DataBase
                (listSize: debugSize, 
                listCount: debugSize, 
                randMin: 0, 
                randMax: 1000000);
            DataBase dat2 = new DataBase
                (listSize: debugSize,
                listCount: debugSize,
                randMin: 0,
                randMax: 1000000);

            var watch = new Stopwatch();
            Console.Clear();
            Console.WriteLine("Sorting");

            watch.Restart();
            dat1.SingleThreadSort();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Single thread sort time = {elapsedMs} ms");

            watch.Restart();
            dat2.MultiThreadSort();
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Multi thread sort time = {elapsedMs} ms");

            Console.ReadKey(false);
        }
    }
}
