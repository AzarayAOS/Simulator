using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{ public struct DCplx
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
        public double [] VectorFromPointer(int n, ref double[] p)
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
        public double[][] MatrixCopy( ref double [][]A)
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
            if(a<0.0f)
                do
                {
                    a = a + 2 * Math.PI;
                } while (a>=0);

            if(a>2*Math.PI)
                do
                {
                    a = a - 2 * Math.PI;
                } while (a<=2*Math.PI);
        }


        public void A_ToPi(ref double a)
        {
            if (a < -Math.PI)
                do
                {
                    a = a + 2 * Math.PI;
                } while (a >=-Math.PI);

            if (a > Math.PI)
                do
                {
                    a = a - 2 * Math.PI;
                } while (a <= Math.PI);
        }




    }
}
