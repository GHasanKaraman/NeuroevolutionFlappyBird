using System;

namespace Mathematic
{
    public static class Matrix
    {
        public static int Row(double[,] matrix)
        {
            return matrix.GetLength(0);
        }

        public static int Column(double[,] matrix)
        {
            return matrix.GetLength(1);
        }

        public static double[,] Transpose(double[,] matrix)
        {
            double[,] temp = new double[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < Row(matrix); i++)
            {
                for (int j = 0; j < Column(matrix); j++)
                {
                    temp[j, i] = matrix[i, j];
                }
            }

            return temp;
        }

        public static double[,]Add(double[,] matrix1, double[,] matrix2)
        {
            bool condition = Row(matrix1) == Row(matrix2) && Column(matrix1) == Column(matrix2);

            if (!condition)
            {
                throw new Exception("The sizes are not same!", new Exception("Row and Column Error"));
            }

            else
            {
                double[,] temp = new double[Row(matrix1), Column(matrix1)];

                for (int i = 0; i < Row(matrix1); i++)
                {
                    for (int j = 0; j < Column(matrix1); j++)
                    {
                        temp[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }

                return temp;
            }
        }

        public static double[,] Add(double[,] matrix, double number)
        {
            double[,] temp = new double[Row(matrix), Column(matrix)];

            for (int i = 0; i < Row(matrix); i++)
            {
                for (int j = 0; j < Column(matrix); j++)
                {
                    temp[i, j] = matrix[i, j] + number;
                }
            }

            return temp;
        }

        public static double[,] Subtract(double[,] matrix1, double[,] matrix2)
        {
            bool condition = Row(matrix1) == Row(matrix2) && Column(matrix1) == Column(matrix2);

            if (!condition)
            {
                throw new Exception("The sizes are not same!", new Exception("Row and Column Error"));
            }

            else
            {
                double[,] temp = new double[Row(matrix1), Column(matrix1)];

                for (int i = 0; i < Row(matrix1); i++)
                {
                    for (int j = 0; j < Column(matrix1); j++)
                    {
                        temp[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }

                return temp;
            }
        }

        public static double[,] Multiply(double[,]matrix, double scalar)
        {
            double[,] temp = new double[Row(matrix), Column(matrix)];

            for (int i = 0; i < Row(matrix); i++)
            {
                for (int j = 0; j < Column(matrix); j++)
                {
                    temp[i, j] = matrix[i, j] * scalar;
                }
            }

            return temp;
        }

        public static double[,] Dot(double[,] matrix1, double[,] matrix2)
        {
            bool condition = Row(matrix1) == Row(matrix2) && Column(matrix1) == Column(matrix2);

            if (!condition)
            {
                throw new Exception("The sizes are not same!", new Exception("Row and Column Error"));
            }

            else
            {
                double[,] temp = new double[Row(matrix1), Column(matrix1)];

                for (int i = 0; i < Row(matrix1); i++)
                {
                    for (int j = 0; j < Column(matrix1); j++)
                    {
                        temp[i, j] = matrix1[i, j] * matrix2[i, j];
                    }
                }

                return temp;
            }
        }

        public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
        {
            bool condition = Column(matrix1) == Row(matrix2);

            if (!condition)
            {
                throw new Exception("Column size of the first matrix and row size of the second matrix are not same!", new Exception("Row and Column Error"));
            }

            else
            {
                double[,] temp = new double[Row(matrix1), Column(matrix2)];
                double _temp = 0;
                int n = Row(matrix2);

                for (int i = 0; i < Row(matrix1); i++)
                {
                    for (int j = 0; j < Column(matrix2); j++)
                    {
                        for (int l = 0; l < n; l++)
                        {
                            _temp += matrix1[i, l] * matrix2[l, j];
                        }
                        temp[i, j] = _temp;
                        _temp = 0;
                    }
                }

                return temp;
            }
        }

        public static double[,] Pow(double[,] matrix, int power)
        {
            if (power == 2)
            {
                return Multiply(matrix, matrix);
            }

            return Multiply(matrix, Pow(matrix, power - 1));
        }

        public static double[,] Random(int row, int column)
        {
            double[,] temp = new double[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    temp[i, j] = UnityEngine.Random.Range(0, 1f);
                }
            }

            return temp;
        }

        public static double[,] f(double[,] matrix, Func<Double, Double> function)
        {
            double[,] temp = new double[Row(matrix), Column(matrix)];

            for (int i = 0; i < Row(matrix); i++)
            {
                for (int j = 0; j < Column(matrix); j++)
                {
                    temp[i, j] = function(matrix[i, j]);
                }
            }

            return temp;
        }
    }
}
