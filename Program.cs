using System;

namespace FKN_32
{
    public class Program
    {
        
        public static double[,] CreateRandomMatrix(int height, int width)
        {
            double[,] matr = new double[height, width];
            
            Random random = new Random();
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; j++)
                {
                    
                    matr[i, j] = random.Next(10);
                }
            }
            return matr;
        }

        public static void PrintMatrix(double[,] matr)
        {
            
            int rows = matr.GetUpperBound(0) + 1;
            int cols = matr.GetUpperBound(1) + 1;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    
                    Console.Write("{0:0.0} ", matr[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static int FindMaxStr(double[,] matr)
        {
            int maxIndex = 0;
            double maxSum = 0;
            double tmpSum = 0;

            int rows = matr.GetUpperBound(0) + 1;
            int cols = matr.GetUpperBound(1) + 1;
            for (int i = 0; i < cols; i++)
            {
                maxSum += matr[0, i];
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tmpSum += matr[i, j];
                }

                if (tmpSum > maxSum)
                {
                    maxSum = tmpSum;
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public static double[,] CreateNewMatrix(double[,] matr, int k)
        {
            int rows = matr.GetUpperBound(0) + 1;
            int cols = matr.GetUpperBound(1) + 1;
            
            double[] vec = new double[cols];
            double[,] newMatr = new double[rows, cols];
            for (int i = 0; i < cols; i++)
            {
                vec[i] = matr[k, i];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatr[i, j] = matr[i, j] / vec[j];
                }
            }

            return newMatr;
        }

        public static double[,] ReadMatrix(int height, int width)
        {
            double[,] matr = new double[height, width];

            int count = 0;
         
            while (count < height * width)
            {
                
                var input = Console.ReadLine();
                var numbers = input.Split(' ');
                foreach (var n in numbers)
                {
                    
                    matr[count / width, count % width] = Convert.ToDouble(n);
                    ++count;
                }
            }

            return matr;
        }



        public static void Main(string[] args)
        {

            Console.WriteLine("Введите размеры матрицы: ");
            Console.Write("N: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.Write("M: ");
            int M = Convert.ToInt32(Console.ReadLine());

            
            var matr = ReadMatrix(N, M);
            PrintMatrix(matr);

            int k = FindMaxStr(matr);
            Console.WriteLine($"Строка с максимальной суммой: {k}");

            var matrB = CreateNewMatrix(matr, k);
            PrintMatrix(matrB);
        }
    }
}
