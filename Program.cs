using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    // Двовимірна матриця 3x3
    public class TwoDimensionalMatrix
    {
        protected const int Columns = 3;
        protected const int Rows = 3;
        private double[,] matrix = new double[Columns, Rows];

        public virtual void InputFromKeyboard()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    while (true)
                    {
                        Console.Write($"Enter element [{i},{j}]: ");
                        string input = Console.ReadLine();
                        if (double.TryParse(input, out double result))
                        {
                            matrix[i, j] = result;
                            break;
                        }

                        Console.WriteLine("Invalid input, try again.");
                    }
                }
            }
        }

        public virtual void FillRandom(int minValue = 0, int maxValue = 100)
        {
            Random rnd = new Random();
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    matrix[i, j] = rnd.Next(minValue, maxValue + 1);
                }
            }
        }

        public virtual double GetMinimum()
        {
            double min = matrix[0, 0];
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }
            }

            return min;
        }

        public virtual void PrintMatrix()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }
    }

    public class ThreeDimensionalMatrix : TwoDimensionalMatrix
    {
        private const int Depth = 3;
        private double[,,] matrix3D = new double[Columns, Rows, Depth];

        public override void InputFromKeyboard()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    for (int k = 0; k < Depth; k++)
                    {
                        while (true)
                        {
                            Console.Write($"Enter element [{i},{j},{k}]: ");
                            string input = Console.ReadLine();
                            if (double.TryParse(input, out double result))
                            {
                                matrix3D[i, j, k] = result;
                                break;
                            }

                            Console.WriteLine("Invalid input, try again.");
                        }
                    }
                }
            }
        }

        public override void FillRandom(int minValue = 0, int maxValue = 100)
        {
            Random rnd = new Random();
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    for (int k = 0; k < Depth; k++)
                    {
                        matrix3D[i, j, k] = rnd.Next(minValue, maxValue + 1);
                    }
                }
            }
        }

        public override double GetMinimum()
        {
            double min = matrix3D[0, 0, 0];
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    for (int k = 0; k < Depth; k++)
                    {
                        if (matrix3D[i, j, k] < min)
                            min = matrix3D[i, j, k];
                    }
                }
            }

            return min;
        }

        public void PrintMatrix3D()
        {
            for (int k = 0; k < Depth; k++)
            {
                Console.WriteLine($"Depth {k}:");
                for (int i = 0; i < Columns; i++)
                {
                    for (int j = 0; j < Rows; j++)
                    {
                        Console.Write(matrix3D[i, j, k] + "\t");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== 2D Matrix ===");
            TwoDimensionalMatrix matrix2D = new TwoDimensionalMatrix();
            matrix2D.FillRandom();
            matrix2D.PrintMatrix();
            Console.WriteLine("Minimum: " + matrix2D.GetMinimum());

            Console.WriteLine("\n=== 3D Matrix ===");
            ThreeDimensionalMatrix matrix3D = new ThreeDimensionalMatrix();
            matrix3D.FillRandom();
            matrix3D.PrintMatrix3D();
            Console.WriteLine("Minimum: " + matrix3D.GetMinimum());
        }
    }
}
