using System;
using System.Numerics;

namespace Simulator
{
    /*public class DCplx
    {
        public double Re { get; set; }
        public double Im { get; set; }
    };*/

    public class pg_type
    {
        /// <summary>
        /// Копирует массив в другой массив.
        /// Функция устаревшая, в бущующем планируется отказаться от неё.
        /// </summary>
        /// <param name="n"> размерность массива</param>
        /// <param name="p"> массив, который надо скопировать</param>
        /// <returns></returns>
        public double[] VectorFromPointer(int n, ref double[] p)
        {
            double[] res = new double[n];

            res = p;
            return res;
        }

        /// <summary>
        /// копирует матрицы из массива в массив
        /// Функция устаревшая, в бущующем планируется отказаться от неё.
        /// </summary>
        /// <param name="A">Матрица, которую надо скопировать</param>
        /// <returns></returns>
        public double[,] MatrixCopy(ref double[,] A)
        {
            //double[,] res = new double[A.Length][];
            //for (int i = 0; i < A.Length; i++)
            //    res[i] = new double[A[0].Length];

            double[,] res = new double[A.GetLength(0), A.GetLength(1)];

            return res;
        }

        /// <summary>
        /// Копирует вектор в массив
        /// Функция устаревшая, в бущующем планируется отказаться от неё.
        /// </summary>
        /// <param name="from">Копируемый ветор</param>
        /// <returns></returns>
        public double[] VectorCopy(ref double[] from)
        {
            double[] res = new double[from.Length];

            res = from ?? null;

            return res;
        }

        public void A_To_2pi(ref double a)
        {
            if (a < 0.0f)
                do
                {
                    a = a + 2 * Math.PI;
                } while (a >= 0);

            if (a > 2 * Math.PI)
                do
                {
                    a = a - 2 * Math.PI;
                } while (a <= 2 * Math.PI);
        }

        public void A_ToPi(ref double a)
        {
            if (a < -Math.PI)
                do
                {
                    a = a + 2 * Math.PI;
                } while (a >= -Math.PI);

            if (a > Math.PI)
                do
                {
                    a = a - 2 * Math.PI;
                } while (a <= Math.PI);
        }

        /// <summary>
        /// Подсчёт определителя матрицы
        /// </summary>
        /// <param name="a">Матрица, определитель которой считается</param>
        /// <returns>Определитель</returns>
        public double MatrixDet(double[,] a)
        {
            int m;
            double temp;

            int dim = a.GetLength(0) + 1;
            temp = 1;
            double[,] b = new double[dim, dim];
            //for (int i = 0; i <= b.Length; i++)
            //    b[i] = new double[a.Length + 1];

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                    b[i, j] = a[i, j];

            for (int i = 0; i <= dim - 2; i++)
            {
                if (b[i, i] == 0)
                {
                    m = 0;
                    while (b[i, i] == 0)
                    {
                        m++;
                        if ((i + m) == dim)
                        {
                            return 0;
                        }
                        temp = -1 * temp;

                        for (int j = 0; j <= dim - 1; j++)
                        {
                            b[i + m, j] = b[i + m, j] + b[i, j];
                            b[i, j] = b[i + m, j] - b[i, j];
                            b[i + m, j] = b[i + m, j] - b[i, j];
                        }
                    }
                }

                for (int k = i + 1; k <= dim - 1; k++)
                    for (int j = dim - 1; j >= i; j--)
                        b[k, j] = b[k, j] - (b[k, i] / b[i, i]) * b[i, j];
            }

            for (int i = 0; i <= dim - 1; i++)
                temp = temp * b[i, i];

            return temp;
        }

        /// <summary>
        /// Сумма векторных поэлементных перемножений
        /// </summary>
        /// <param name="a">Массив-вектор</param>
        /// <param name="b">Массив-вектор</param>
        /// <returns>Результат перемножения</returns>
        private double VectorOnVector(double[] a, double[] b)
        {
            double temp = 0;

            for (int i = 0; i <= a.Length; i++)
                temp = temp + (a[i] * b[i]);

            return temp;
        }

        /// <summary>
        /// Умножение каждого элемента массива а на все жлементы массива b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Матрицу перемножения</returns>
        public double[,] TrVectorOnVector(double[] a, double[] b)
        {
            //double[,] temp;

            //temp = new double[a.Length + 1][];
            //for (int i = 0; i <= temp.Length; i++)
            //    temp[i] = new double[a.Length + 1];

            double[,] temp = new double[a.GetLength(0) + 1, a.GetLength(1) + 1];

            for (int i = 0; i <= a.GetLength(0); i++)
                for (int j = 0; j <= a.GetLength(0); j++)
                    temp[i, j] = a[i] * b[j];

            return temp;
        }

        /// <summary>
        /// Инвертируем матрицу
        /// </summary>
        /// <param name="a">Матрица, которую надо инфертировать</param>
        /// <returns></returns>
        public double[,] MatrixInvert(double[,] a)
        {
            double[,] b;
            double[,] c;
            int m;

            //b = new double[a.Length + 1][];
            //for (int i = 0; i <= b.Length; i++)
            //    b[i] = new double[(a.Length + 1) * 2];

            //c = new double[a.Length + 1][];
            //for (int i = 0; i <= c.Length; i++)
            //    c[i] = new double[(a.Length + 1)];

            int dim = a.GetLength(0) + 1;

            b = new double[dim, 2 * dim];
            c = new double[dim, dim];

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                    c[i, j] = a[i, j];

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                    b[i, j] = c[i, j];

            for (int i = 0; i <= dim - 1; i++)
                b[i, i + dim] = 1;

            for (int i = 0; i <= dim - 2; i++)
            {
                if (b[i, i] == 0)
                {
                    m = 0;
                    while (b[i, i] == 0)
                    {
                        m++;
                        for (int j = 0; j <= 2 * dim - 1; j++)
                        {
                            b[i + m, j] = b[i + m, j] + b[i, j];
                            b[i, j] = b[i + m, j] - b[i, j];
                            b[i + m, j] = b[i + m, j] - b[i, j];
                        }
                    }
                }
            }

            for (int i = 0; i <= dim - 1; i++)
                for (int k = 0; k <= dim - 1; k++)
                    if (i != k)
                        for (int j = 2 * dim - 1; j >= i; j--)
                            b[k, j] = b[k, j] - (b[k, i] / b[i, i]) * b[i, j];

            for (int i = dim - 1; i >= 0; i--)
                for (int j = 2 * dim - 1; j >= 0; j--)
                    b[i, j] = b[i, j] / b[i, i];

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                    c[i, j] = b[i, j + dim - 1];

            return c;
        }

        /// <summary>
        /// Вычисление определеителся инверстной матрицы
        /// </summary>
        /// <param name="a"></param>
        /// <param name="detg"></param>
        /// <returns></returns>
        public double[,] MatrixInvertDet(double[,] a, ref double detg)
        {
            int dim;
            double[,] b;
            double[,] c;
            int m;

            dim = a.GetLength(0) + 1;
            //b = new double[a.Length + 1][];
            //for (int i = 0; i <= b.Length; i++)
            //    b[i] = new double[(a.Length + 1) * 2];

            //c = new double[a.Length + 1][];
            //for (int i = 0; i <= c.Length; i++)
            //    c[i] = new double[(a.Length + 1)];

            b = new double[dim, 2 * dim];
            c = new double[dim, dim];

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                    c[i, j] = a[i, j];

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                    b[i, j] = c[i, j];

            for (int i = 0; i <= dim - 1; i++)
                b[i, i + dim] = 1;

            for (int i = 0; i <= dim - 2; i++)
            {
                if (b[i, i] == 0)
                {
                    m = 0;
                    while (b[i, i] == 0)
                    {
                        m++;
                        for (int j = 0; j <= 2 * dim - 1; j++)
                        {
                            b[i + m, j] = b[i + m, j] + b[i, j];
                            b[i, j] = b[i + m, j] - b[i, j];
                            b[i + m, j] = b[i + m, j] - b[i, j];
                        }
                    }
                }
            }

            for (int i = 0; i <= dim - 1; i++)
                for (int k = 0; k <= dim - 1; k++)
                    if (i != k)
                        for (int j = 2 * dim - 1; j >= i; j--)
                            b[k, j] = b[k, j] - (b[k, i] / b[i, i]) * b[i, j];

            detg = 1;

            for (int i = dim - 1; i >= 0; i--)
            {
                detg = detg * b[i, i];
                for (int j = 2 * dim - 1; j >= 0; j--)
                    b[i, j] = b[i, j] / b[i, i];
            }

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                    c[i, j] = b[i, j + dim];

            return c;
        }

        /// <summary>
        /// Трансопнирование матрицы
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public double[,] MatrixTranspose(double[,] a)
        {
            double[,] b;
            int dim1, dim2;

            dim1 = a.GetLength(0) + 1;
            dim2 = a.GetLength(1) + 1;
            //b = new double[a.Length + 1][];
            //for (int i = 0; i <= dim2; i++)
            //    b[i] = new double[dim1];

            b = new double[dim1, dim2];

            for (int i = 0; i <= dim1 - 1; i++)
                for (int j = 0; j <= dim2 - 1; j++)
                    b[j, i] = a[i, j];

            return b;
        }

        /// <summary>
        /// Перемножение матриц(кажеться)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[,] MatrixOnMatrix(double[,] a, double[,] b)
        {
            //double[,] temp;
            //temp = new double[a.Length + 1][];
            //for (int i = 0; i < a.Length + 1; i++)
            //    temp[i] = new double[a[0].Length + 1];

            double[,] temp = new double[a.GetLength(0) + 1, b.GetLength(1) + 1];

            for (int i = 0; i <= a.GetLength(0); i++)
                for (int j = 0; j <= b.GetLength(1); j++)
                    for (int k = 0; k <= a.GetLength(1); k++)
                        temp[i, j] = temp[i, j] + a[i, k] * b[k, j];

            return temp;
        }

        /// <summary>
        /// Умножение строк матрицы на вектор
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[] MatrixOnVector(double[,] a, double[] b)
        {
            double[] temp = new double[a.GetLength(0) + 1];
            for (int i = 0; i <= a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    temp[i] = temp[i] + a[i, j] * b[j];
            return temp;
        }

        /// <summary>
        /// Поэлементно суммируем две матрицы
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[,] MatrixSum(double[,] a, double[,] b)
        {
            //double[][] temp = new double[a.Length + 1][];
            //for (int i = 0; i <= a.Length + 1; i++)
            //    temp[i] = new double[a[i].Length+1];

            int dim1 = a.GetLength(0) + 1;
            int dim2 = a.GetLength(1) + 1;

            double[,] temp = new double[dim1, dim2];

            for (int i = 0; i <= dim1 - 1; i++)
                for (int j = 0; j <= dim2 - 1; j++)
                    temp[i, j] = a[i, j] + b[i, j];

            return temp;
        }

        /// <summary>
        /// Перемножение одной матрицы на транспонированную другую
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[,] MatrixOnTrMatrix(double[,] a, double[,] b)
        {
            //double[][] temp = new double[a.Length + 1][];
            //for (int i = 0; i <= a.Length + 1; i++)
            //    temp[i] = new double[a[i].Length + 1];

            double[,] temp = new double[a.GetLength(0) + 1, b.GetLength(0) + 1];

            for (int i = 0; i <= a.GetLength(0); i++)
                for (int j = 0; j <= b.GetLength(0); j++)
                    for (int k = 0; k <= a.GetLength(1); k++)
                        temp[i, j] = temp[i, j] + a[i, k] * b[j, k];

            return temp;
        }

        /// <summary>
        /// Сложение одного вектора с другогим
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[] VectorSum(double[] a, double[] b)
        {
            double[] temp = new double[a.Length + 1];

            for (int i = 0; i <= a.Length; i++)
                temp[i] = a[i] + b[i];

            return temp;
        }

        /// <summary>
        /// Вычитание одного вектора из другого
        /// </summary>
        /// <param name="a">Из какого вычитаем</param>
        /// <param name="b">То, что вычитаем</param>
        /// <returns></returns>
        public double[] VectorDif(double[] a, double[] b)
        {
            double[] temp = new double[a.Length + 1];

            for (int i = 0; i <= a.Length; i++)
                temp[i] = a[i] - b[i];

            return temp;
        }

        /// <summary>
        /// Произведение каждого столбца матрицы на вектор
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[] TrVectorOnMatrix(double[] a, double[,] b)
        {
            int dim1 = a.Length + 1;
            int dim2 = b.GetLength(0) + 1;

            double[] temp = new double[dim2];

            for (int i = 0; i <= dim2 - 1; i++)
                for (int j = 0; j <= dim1 - 1; j++)
                    temp[i] = temp[i] + a[j] * b[j, i];

            return temp;
        }

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[] VectorOnDouble(double[] a, double b)
        {
            int dim = a.Length + 1;
            double[] temp = new double[dim];

            for (int i = 0; i <= dim - 1; i++)
                temp[i] = a[i] * b;

            return temp;
        }

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[,] MatrixOnDouble(double[,] a, double b)
        {
            int dim1 = a.GetLength(0) + 1;
            int dim2 = a.GetLength(1) + 1;

            double[,] temp = new double[dim1, dim2];
            //for (int i = 0; i < temp.Length; i++)
            //    temp[i] = new double[dim2];

            for (int i = 0; i <= dim1 - 1; i++)
                for (int j = 0; j <= dim2 - 1; j++)
                    temp[i, j] = a[i, j] * b;

            return temp;
        }

        /// <summary>
        /// Поэлементное вычитание одной матрицы из другой
        /// </summary>
        /// <param name="a">Из чего вычитать</param>
        /// <param name="b">Что вычитать</param>
        /// <returns></returns>
        public double[,] MatrixDif(double[,] a, double[,] b)
        {
            int dim1 = a.GetLength(0) + 1;
            int dim2 = a.GetLength(1) + 1;

            double[,] temp = new double[dim1, dim2];

            for (int i = 0; i <= dim1 - 1; i++)
                for (int j = 0; j <= dim2 - 1; j++)
                    temp[i, j] = a[i, j] - b[i, j];

            return temp;
        }

        /// <summary>
        /// Метод Гаусса — Зейделя
        /// </summary>
        /// <param name="A">Матрица коэфициентов</param>
        /// <param name="B">Матрица ответов</param>
        /// <param name="Coef">Матрица неизвестных</param>
        /// <returns></returns>
        public bool GaussSolve(double[,] A, ref double[] B, ref double[] Coef)
        {
            int m;
            int size = A.GetLength(0) + 1;

            for (int i = 0; i <= size - 2; i++)
            {
                if (A[i, i] == 0)
                {
                    m = 0;
                    while (A[i, i] == 0)
                    {
                        m++;
                        if ((i + m) == size)
                        {
                            return false;
                        }

                        for (int j = 0; j <= size - 1; j++)
                        {
                            A[i + m, j] = A[i + m, j] + A[i, j];
                            A[i, j] = A[i + m, j] - A[i, j];
                            A[i + m, j] = A[i + m, j] - A[i, j];
                        }

                        B[i + m] = B[i + m] + B[i];
                        B[i] = B[i + m] - B[i];
                        B[i + m] = B[i + m] - B[i];
                    }
                }

                for (int k = i + 1; k <= size - 1; k++)
                {
                    B[k] = B[k] - (A[k, i] / A[i, i]) * B[i];
                    for (int j = size - 1; j >= i; j--)
                        A[k, j] = A[k, j] - (A[k, j] / A[i, i]) * A[i, j];
                }
            }

            for (int i = 0; i <= size - 1; i++)
                if (A[i, i] == 0)
                    return false;

            for (int i = size - 1; i >= 0; i--)
            {
                double temp = 0;
                for (int j = i + 1; j <= size - 1; j++)
                    temp += Coef[j] * A[i, j];
                Coef[i] = (B[i] - temp) / A[i, i];
            }

            return true;
        }

        /// <summary>
        /// Метод Гаусса — Зейделя для комплексных чисел
        /// </summary>
        /// <param name="A">Матрица коэфициентов</param>
        /// <param name="B">Матрица ответов</param>
        /// <param name="Coef">Матрица неизвестных</param>
        /// <returns></returns>
        public bool GaussSolveComp(Complex[,] A, ref Complex[] B, ref Complex[] Coef)
        {
            int m;
            int size = A.GetLength(0) + 1;
            Complex temp;

            for (int i = 0; i <= size - 2; i++)
            {
                if (ComplexModul(A[i, i]) == 0)
                {
                    m = 0;

                    while (ComplexModul(A[i, i]) == 0)
                    {
                        m++;
                        if ((i + m) == size)
                            return false;

                        for (int j = 0; j <= size - 1; j++)
                        {
                            A[i + m, j] = ComplexSumm(A[i + m, j], A[i, j]);
                            A[i, j] = ComplexSumm(A[i + m, j], A[i, j]);
                            A[i + m, j] = ComplexSumm(A[i + m, j], A[i, j]);
                        }

                        B[i + m] = ComplexSumm(B[i + m], B[i]);
                        B[i] = ComplexSumm(B[i + m], B[i]);
                        B[i + m] = ComplexSumm(B[i + m], B[i]);
                    }
                }

                for (int k = i + 1; k <= size - 1; k++)
                {
                    B[k] = ComplexDiff(B[k], ComplexMult(ComplexDiv(A[k, i], A[i, i]), B[i]));
                    for (int j = size - 1; j >= i; j--)
                        A[k, j] = ComplexDiff(A[k, j], ComplexMult(ComplexDiv(A[k, i], A[i, i]), A[i, j]));
                }
            }

            for (int i = 0; i <= size - 1; i++)
                if (ComplexModul(A[i, i]) == 0)
                    return false;

            Coef = new Complex[size];

            for (int i = size - 1; i >= 0; i--)
            {
                temp = new Complex(0, 0);
                for (int j = i + 1; j <= size - 1; j++)
                    temp = ComplexSumm(temp, ComplexMult(Coef[j], A[i, j]));

                Coef[i] = ComplexDiv(ComplexDiff(B[i], temp), A[i, i]);
            }

            return true;
        }

        /// <summary>
        /// Суммирование комплекных чисел
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public Complex ComplexSumm(Complex A, Complex B)
        {
            return A + B;
        }

        /// <summary>
        /// Разность комплексных чисел
        /// </summary>
        /// <param name="A">Из чего вычитаем</param>
        /// <param name="B">Что вычитаем</param>
        /// <returns></returns>
        public Complex ComplexDiff(Complex A, Complex B)
        {
            return A - B;
        }

        /// <summary>
        /// Перемножение комплексных чисел
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public Complex ComplexMult(Complex A, Complex B)
        {
            return A * B;
        }

        /// <summary>
        /// Стремное умножение
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public Complex ComplexMultSopr(Complex A, Complex B)
        {
            return new Complex((A.Re * B.Re - A.Im * B.Im), (A.Im * B.Re + A.Re * B.Im));
        }

        /// <summary>
        /// Вроде бы деление двух комплексных чисел
        /// </summary>
        /// <param name="A">Что делим</param>
        /// <param name="B">На что делим </param>
        /// <param name="Norm">Если в результате действительная часть делителя равна 0,
        /// то заменяем 0 на 0,001</param>
        /// <returns></returns>
        public Complex ComplexDiv(Complex A, Complex B, bool Norm = false)
        {
            Complex Temp, Temp1, BTemp;
            BTemp = new Complex(B.Re, -B.Im);
            Temp1 = A * BTemp;
            Temp = B * BTemp;
            if (Norm && (Temp.Re == 0))
                Temp.Re = 0.001f;
            Temp.Im = Temp1.Im / Temp.Re;
            Temp.Re = Temp1.Re / Temp.Re;

            return Temp;
        }

        /// <summary>
        /// Модуль комплекстного числа
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public double ComplexModul(Complex A)
        {
            return A.Abs;
        }

        /// <summary>
        /// Арктангенс мнимой части, делённой на действительную
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public double ComplexPhase(Complex A)
        {
            return Math.Atan(A.Im / A.Re);
        }

        public Complex[,] MatrixInvertCompl(Complex[,] a)
        {
            int m, dim;
            dim = a.GetLength(0) + 1;

            Complex[,] b = new Complex[dim, 2 * dim];
            Complex[,] c = new Complex[dim, dim];

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                {
                    //c[i, j].Re = a[i, j].Re;
                    //c[i, j].Im = a[i, j].Im;
                    c[i, j] = a[i, j];
                }

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                {
                    //b[i, j].Re = c[i, j].Re;
                    //b[i, j].Im = c[i, j].Im;
                    b[i, j] = c[i, j];
                }

            for (int i = 0; i <= dim - 1; i++)
            {
                //b[i, dim + i].Re = 1;
                //b[i, dim + i].Im = 1;
                b[i, dim + i] = new Complex(1f, 1f);
            }

            for (int i = 0; i <= dim - 2; i++)
            {
                if ((Math.Abs(b[i, i].Re) < 1e-10) && (Math.Abs(b[i, i].Im) < 1e-10))
                {
                    m = 0;
                    while ((Math.Abs(b[i, i].Re) > 1e-10) && (Math.Abs(b[i, i].Im) != 1e-10))
                    {
                        m++;
                        for (int j = 0; j <= 2 * dim - 1; j++)
                        {
                            b[i + m, j] = ComplexSumm(b[i + m, j], b[i, j]);
                            b[i, j] = ComplexDiff(b[i + m, j], b[i, j]);
                            b[i + m, j] = ComplexDiff(b[i + m, j], b[i, j]);
                        }
                    }
                }
            }

            for (int i = 0; i <= dim - 1; i++)
                for (int k = 0; k <= dim - 1; k++)
                    if (i != k)
                        for (int j = 2 * dim - 1; j >= i; j--)
                            b[k, j] = ComplexDiff(b[k, j], ComplexMult(ComplexDiv(b[k, i], b[i, i]), b[i, j]));

            for (int i = dim - 1; i >= 0; i--)
                for (int j = 2 * dim - 1; j >= 0; j--)
                    b[i, j] = ComplexDiv(b[i, j], b[i, i]);

            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                {
                    c[i, j] = b[i, j + dim];
                }

            return c;
        }

        public double gauss(double x, double m, double g)
        {
            return (1 / (Math.Sqrt(2 * Math.PI * g)) * Math.Exp((-0.5f) * (Math.Pow(x - m, 2) / g)));
        }
    }
}