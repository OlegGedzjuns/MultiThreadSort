using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiThreadSort.Data
{
    class DataBase
    {
        public int ListCnt;
        public int ListSize;

        public List<List<int>> Data { get; set; }

        public DataBase(int listCnt, int listSize, int randMin, int randMax)
        {
            ListCnt = listCnt;
            ListSize = listSize;
            Data = new List<List<int>>(ListCnt);
            for (int i = 0; i < ListCnt; i++)
            {
                Random rand = new Random();
                List<int> buf = new List<int>(ListSize);
                for(int j = 0; j < ListSize; j++)
                {
                    buf.Add(rand.Next(randMin, randMax));
                }
                Data.Add(buf);
            }
        }

        public void SingleThreadSort()
        {
            for(int i = 0; i < ListCnt; i++)
            {
                Data[i].Sort();
            }
        }

        public void MultiThreadSort()
        {
            Thread t1 = new Thread(Func);
            Thread t2 = new Thread(Func);
            Thread t3 = new Thread(Func);
            for (int i = 0; i < ListCnt; i += 4)
            {
                t1.Start(Data[i]);
                t2.Start(Data[i + 1]);
                t3.Start(Data[i + 2]);
                Data[i + 3].Sort();
                t1.Join();
                t2.Join();
                t3.Join();
            }
        }
        void Func(Object dat)
        {
            List<int> Dat = (List<int>)dat;
            Dat.Sort();
        }
    }
}
