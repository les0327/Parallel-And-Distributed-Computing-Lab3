using System;

namespace ParallelAndDistributedComputingLab3
{
    public class Data
    {

        private readonly int _size;

        public Data(int size)
        {
            _size = size;
        }
        
        public int F1(int[] a, int[] b, int[] c, int[] d, int[,] ma, int[,] md) {
            return Scalar(a, b) + Scalar(c, VectorMatrixMultiplication(d, MatrixMultiplication(ma, md)));
        }
        
        public int[,] F2 (int[,] mf, int[,] mg, int[,] mh) {
            return MatrixAddition(mf, MatrixMultiplication(mg, mh));
        }
        
        public int[] F3(int[,] mp, int[,] mr, int[] T) {
            return NumberVectorMultiplication(MatrixMax(MatrixMultiplication(mp, mr)), T);
        }
        
        public void FillArrWithNum(int num, int[] arr)
        {
            for (int i = 0; i < _size; i++)
                arr[i] = num;
        }

        public void FillMatrixWithNum(int num, int[,] matrix)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    matrix[i, j] = num;
                }
            }
        }

        private int Scalar(int[] a, int[] b)
        {
            var scalar = 0;
            for (int i = 0; i < _size; i++)
                scalar += a[i] * b[i];
            return scalar;
        }
        
        private int[,] MatrixAddition(int[,] a, int[,] b) {

            int[,] c = new int[_size, _size];

            for (int i = 0; i < _size; i++ ) {
                for (int j = 0; j < _size; j++) {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }

            return c;
        } 
        
        private int[,] MatrixMultiplication(int[,] a, int[,] b) {
            int[,] c = new int[_size, _size];

            for (int i = 0; i < _size; i++ ) {
                for (int j = 0; j < _size; j++) {
                    int buf = 0;
                    for (int k = 0; k < _size; k++) {
                        buf += a[i, k] * b[k, j];
                    }
                    c[i,j] = buf;
                }
            }

            return c;
        }
        
       
        private int[] VectorMatrixMultiplication(int [] a, int[,] b) {
            int[] c = new int[_size];

            for (int i = 0; i < _size; i++ ) {
                int buf = 0;
                for (int j = 0; j < _size; j++) {
                    buf += a[j] * b[j, i];
                }
                c[i] = buf;
            }

            return c;
        }
        
        private int[] NumberVectorMultiplication(int num, int[] a) {
            int[] b = new int[_size];

            for (int i = 0; i < _size; i++)
                b[i] = a[i] * num;

            return b;
        }
        
        private int MatrixMax(int[,] a) {
            int max = int.MinValue;

            for (int i = 0; i < _size; i++) {
                for (int j = 0; j < _size; j++) {
                    if (a[i, j] > max) {
                        max = a[i, j];
                    }
                }
            }

            return max;
        }
        
        private void MatrixSort(int[,] a) {
            int index = 0;
            int max   = 0;
            for (int line = 0; line < _size; line++) {
                for (int i = 0; i < _size; i++) {
                    index = i;
                    max   = a[line, i];
                    for (int j = i + 1; j < _size; j++) {
                        if (a[line, j] > max) {
                            index = j;
                            max   = a[line, j];
                        }
                    }
                    a[line, index] = a[line, i];
                    a[line, i]     = max;
                }
            }
        }
    }
}