using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiThreadSort.Data
{
    class DataBase
    {
        /// <summary>
        /// The number of lists in the main list
        /// </summary>
        public int ListCount { get; set; }
        /// <summary>
        /// The number of elements in each list
        /// </summary>
        public int ListSize { get; set; }
        public List<List<int>> Data { get; set; }

        /// <summary>
        /// Creates DataBase and fill list vith random values from RandMin to RandMax
        /// </summary>
        /// <param name="listCount">Using to set general list size</param>
        /// <param name="listSize">Using to set number of elements in each list</param>
        /// <param name="randMin">Minimal rand value</param>
        /// <param name="randMax">Maximal rand value</param>
        public DataBase(int listCount, int listSize, int randMin, int randMax)
        {
            ListCount = listCount;
            ListSize = listSize;
            Data = new List<List<int>>(ListCount);
            Random rand = new Random();
            for (int i = 0; i < ListCount; i++)
            {
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
            for(int i = 0; i < ListCount; i++)
            {
                Data[i].Sort();
            }
        }

        public void MultiThreadSort()
        {
            const int threadCount = 4;
            for(int i = 0; i < threadCount; i++)
            {
                Thread t = new Thread(SortFunc);
                t.Start(Data.GetRange(i * (ListCount / threadCount), ListCount / threadCount));
            }
        }
        void SortFunc(Object dat)
        {
            List<List<int>> Dat = (List<List<int>>)dat;
            foreach(List<int> list in Dat)
            {
                list.Sort();
            }
        }
    }
}
