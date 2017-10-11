using System;
using System.Text;
using System.Threading;

namespace ParallelAndDistributedComputingLab3
{
    public class Threads
    {
        private readonly int _size;

        public Threads(int size)
        {
            _size = size;
        }

        public void Task1()
        {
            Data data = new Data(_size);
            Console.WriteLine(Thread.CurrentThread.Name + " start");

            int[]   a = new int[_size];
            int[]   b = new int[_size];
            int[]   c = new int[_size];
            int[]   d = new int[_size];
            int[,] ma = new int[_size, _size];
            int[,] md = new int[_size, _size];

            data.FillArrWithNum(1, a);
            data.FillArrWithNum(1, b);
            data.FillArrWithNum(1, c);
            data.FillArrWithNum(1, d);
            data.FillMatrixWithNum(1, ma);
            data.FillMatrixWithNum(1, md);

            Thread.Sleep(1000);
            int e = data.F1(a, b, c, d, ma, md);
            Thread.Sleep(1000);

            if (_size < 10)
                Console.WriteLine(Thread.CurrentThread.Name + ": E = " + e);

            Console.WriteLine(Thread.CurrentThread.Name + " finish");

            
        }

        public void Task2()
        {
            Data data = new Data(_size);
            Console.WriteLine(Thread.CurrentThread.Name + " start");

            int[,] mf = new int[_size, _size];
            int[,] mg = new int[_size, _size];
            int[,] mh = new int[_size, _size];

            data.FillMatrixWithNum(1, mf);
            data.FillMatrixWithNum(1, mg);
            data.FillMatrixWithNum(1, mh);

            Thread.Sleep(700);          
            int[,] ml = data.F2(mf, mg, mh);
            Thread.Sleep(700);

            string s = "";
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                    s += ml[i, j] + " ";
                s += "\n";
            }
            
            if (_size < 10)
                Console.WriteLine(Thread.CurrentThread.Name + ": Ml = \n" + s);

            Console.WriteLine(Thread.CurrentThread.Name + " finish"); 
        }

        public void Task3()
        {
            Data data = new Data(_size);
            Console.WriteLine(Thread.CurrentThread.Name + " start");
            
            int[,] mp = new int[_size, _size];
            int[,] mr = new int[_size, _size];
            int[] T   = new int[_size];

            data.FillMatrixWithNum(1, mp);
            data.FillMatrixWithNum(1, mr);
            data.FillArrWithNum(1, T);

            Thread.Sleep(500);
            int[] o = data.F3(mp, mr, T);    
            Thread.Sleep(500);

            string s = "";
            for (int i = 0; i < _size; i++)
                s += o[i] + " ";
            
            if (_size < 10)
                Console.WriteLine(Thread.CurrentThread.Name + ": O = " + s);

            Console.WriteLine(Thread.CurrentThread.Name + " finish");
        }
    }
}