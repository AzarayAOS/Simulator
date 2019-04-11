using System;

namespace Simulator
{
    public struct DCplx
    {
        double Re { get; set; }
        double Im { get; set; }
    };





    class pg_type
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
        public double[][] MatrixCopy(ref double[][] A)
        {

            double[][] res = new double[A.Length][];
            for (int i = 0; i < A.Length; i++)
                res[i] = new double[A[0].Length];


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
        public double MatrixDet(double[][] a)
        {
            int m;
            double temp;


            temp = 1;
            double[][] b;
            b = new double[a.Length + 1][];
            for (int i = 0; i <= b.Length; i++)
                b[i] = new double[a.Length + 1];

            for (int i = 0; i <= a.Length; i++)
                for (int j = 0; j < a[i].Length; j++)
                    b[i][j] = a[i][j];


            for (int i = 0; i <= a.Length - 1; i++)
            {
                if (b[i][i] == 0)
                {
                    m = 0;
                    while (b[i][i] == 0)
                    {
                        m++;
                        if ((i + m) == a.Length + 1)
                        {
                            return 0;
                        }
                        temp = -1 * temp;


                        for (int j = 0; j <= a.Length; j++)
                        {
                            b[i + m][j] = b[i + m][j] + b[i][j];
                            b[i][j] = b[i + m][j] - b[i][j];
                            b[i + m][j] = b[i + m][j] - b[i][j];
                        }
                    }
                }

                for (int k = i + 1; k <= a.Length; k++)
                    for (int j = a.Length; j >= i; j--)
                        b[k][j] = b[k][j] - (b[k][i] / b[i][i]) * b[i][j];

            }


            for (int i = 0; i <= a.Length; i++)
                temp = temp * b[i][i];


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
        public double[][] TrVectorOnVector(double[] a, double[] b)
        {
            double[][] temp;

            temp = new double[a.Length + 1][];
            for (int i = 0; i <= temp.Length; i++)
                temp[i] = new double[a.Length + 1];

            for (int i = 0; i <= temp.Length; i++)
                for (int j = 0; j <= temp[i].Length; j++)
                    temp[i][j] = a[i] * b[j];

            return temp;
        }

        /// <summary>
        /// Инвертируем матрицу
        /// </summary>
        /// <param name="a">Матрица, которую надо инфертировать</param>
        /// <returns></returns>
        public double[][] MatrixInvert(double[][] a)
        {
            double[][] b;
            double[][] c;
            int m;

            b = new double[a.Length + 1][];
            for (int i = 0; i <= b.Length; i++)
                b[i] = new double[(a.Length + 1) * 2];


            c = new double[a.Length + 1][];
            for (int i = 0; i <= c.Length; i++)
                c[i] = new double[(a.Length + 1)];


            for (int i = 0; i <= a.Length; i++)
                for (int j = 0; j <= a.Length; j++)
                    c[i][j] = a[i][j];

            for (int i = 0; i <= a.Length; i++)
                for (int j = 0; j <= a.Length; j++)
                    b[i][j] = c[i][j];


            for (int i = 0; i <= a.Length; i++)
                b[i][i + a.Length + 1] = 1;




            for (int i = 0; i <= a.Length - 1; i++)
            {
                if (b[i][i] == 0)
                {
                    m = 0;
                    while (b[i][i] == 0)
                    {
                        m++;
                        for (int j = 0; j <= 2 * a.Length; j++)
                        {
                            b[i + m][j] = b[i + m][j] + b[i][j];
                            b[i][j] = b[i + m][j] - b[i][j];
                            b[i + m][j] = b[i + m][j] - b[i][j];
                        }
                    }
                }
            }

            for (int i = 0; i <= a.Length; i++)
                for (int k = 0; k <= a.Length; k++)
                    if (i != k)
                        for (int j = 2 * a.Length; j >= i; j--)
                            b[k][j] = b[k][j] - (b[k][i] / b[i][i]) * b[i][j];


            for (int i = a.Length; i >= 0; i--)
                for (int j = 2 * a.Length; j >= 0; j--)
                    b[i][j] = b[i][j] / b[i][i];

            for (int i = 0; i <= a.Length; i++)
                for (int j = 0; j <= a.Length; j++)
                    c[i][j] = b[i][j + a.Length + 1];

            return c;
        }
        
        /// <summary>
        /// Вычисление определеителся инверстной матрицы
        /// </summary>
        /// <param name="a"></param>
        /// <param name="detg"></param>
        /// <returns></returns>
        public double[][] MatrixInvertDet(double[][]a,ref double detg)
        {
            int dim;
            double[][] b;
            double[][] c;
            int m;

            dim = a.Length + 1;
            b = new double[a.Length + 1][];
            for (int i = 0; i <= b.Length; i++)
                b[i] = new double[(a.Length + 1) * 2];


            c = new double[a.Length + 1][];
            for (int i = 0; i <= c.Length; i++)
                c[i] = new double[(a.Length + 1)];


            for (int i = 0; i <= a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    c[i][j] = a[i][j];

            for (int i = 0; i <= a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    b[i][j] = c[i][j];


            for (int i = 0; i <= a.Length; i++)
                b[i][i + a.Length + 1] = 1;



            for (int i = 0; i <= dim - 2; i++)
            {
                if (b[i][i] == 0)
                {
                    m = 0;
                    while (b[i][i] == 0)
                    {
                        m++;
                        for (int j = 0; j <= 2 * a.Length; j++)
                        {
                            b[i + m][j] = b[i + m][j] + b[i][j];
                            b[i][j] = b[i + m][j] - b[i][j];
                            b[i + m][j] = b[i + m][j] - b[i][j];
                        }
                    }
                }
            }




            for (int i = 0; i <= dim - 1; i++)
                for (int k = 0; k <= dim - 1; k++)
                    if (i != k)
                        for (int j = 2 * dim - 1; j >= i; j--)
                            b[k][j] = b[k][j] - (b[k][i] / b[i][i]) * b[i][j];

            detg = 1;

            for (int i = dim - 1; i >= 0; i--)
            {
                detg = detg * b[i][i];
                for (int j = 2 * dim - 1; j >= 0; j--)
                    b[i][j] = b[i][j] / b[i][i];
            }


            for (int i = 0; i <= dim - 1; i++)
                for (int j = 0; j <= dim - 1; j++)
                    c[i][j] = b[i][j + dim];



            return c;

        }



        /// <summary>
        /// Трансопнирование матрицы
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public double [][] MatrixTranspose(double [][]a)
        {
            double[][] b;
            int dim1,dim2;

            dim1 = a.Length+1;
            dim2 = a[0].Length+1;
            b = new double[a.Length + 1][];
            for (int i = 0; i <= dim2; i++)
                b[i] = new double[dim1];

            for (int i = 0; i <= dim1 - 1; i++)
                for (int j = 0; j <= dim2; j++)
                    b[j][i] = a[i][j];

            return b;
        }


        /// <summary>
        /// Перемножение матриц(кажеться)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[][] MatrixOnMatrix(double[][]a,double[][]b)
        {
            double[][] temp;
            temp = new double[a.Length + 1][];
            for (int i = 0; i < a.Length + 1; i++)
                temp[i] = new double[a[0].Length + 1];


            for (int i = 0; i <= a.Length; i++)
                for (int j = 0; j <= b[0].Length; j++)
                    for (int k = 0; k <= a[0].Length; k++)
                        temp[i][j] = temp[i][j] + a[i][k] * b[k][j];


            return temp;
        }

        /// <summary>
        /// Умножение строк матрицы на вектор
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[] MatrixOnVector(double[][]a,double[]b)
        {
            double[] temp = new double[a.Length + 1];
            for (int i = 0; i <= a.Length; i++)
                for (int j = 0; j < a[0].Length; j++)
                    temp[i] = temp[i] + a[i][j] * b[j];
            return temp;
        }

        /// <summary>
        /// Поэлементно суммируем две матрицы
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[][]MatrixSum(double[][]a,double[][]b)
        {
            double[][] temp = new double[a.Length + 1][];
            for (int i = 0; i <= a.Length + 1; i++)
                temp[i] = new double[a[i].Length+1];

            for(int i=0;i<=a.Length;i++)
                for(int j=0;j<=a[i].Length;j++)
                    temp[i][j] = a[i][j] + b[i][j];


            return temp;

        }


        /// <summary>
        /// Перемножение одной матрицы на транспонированную другую
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[][]MatrixOnTrMatrix(double[][]a,double[][]b)
        {
            double[][] temp = new double[a.Length + 1][];
            for (int i = 0; i <= a.Length + 1; i++)
                temp[i] = new double[a[i].Length + 1];


            for (int i = 0; i <= a.Length; i++)
                for (int j = 0; j <= b.Length; j++)
                    for (int k = 0; k <= a[0].Length; k++)
                        temp[i][j] = temp[i][j] + a[i][k] * b[j][k];


            return temp;
        }



        /// <summary>
        /// Вычитание одного вектора из другого
        /// </summary>
        /// <param name="a">Из какого вычитаем</param>
        /// <param name="b">То, что вычитаем</param>
        /// <returns></returns>
        public double[] VectorDif(double[] a,double[]b)
        {
            double[] temp = new double[a.Length + 1];

            for (int i = 0; i <= a.Length; i++)
                temp[i] = a[i] - b[i];

            return temp;

        }




    }
}
 