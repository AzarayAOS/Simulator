using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// Класс массива типа double,
    /// чтоб можно было использовать set и get, а так же индексы
    /// </summary>
    internal class DoubleIndex
    {
        private double[] _source;

        public int Lenght { get { return _source.Length; } }

        public double this[int index]
        {
            get { return _source[index]; }
            set { _source[index] = value; }
        }

        public DoubleIndex(int size)
        {
            _source = new double[size];
        }
    }

    internal class TOrbVec
    {
        private double P { get; set; }
        private double K { get; set; }
        private double Q { get; set; }
        private double I { get; set; }
        private double Omega { get; set; }
        private double U { get; set; }

        private DoubleIndex itemss = new DoubleIndex(6);

        /// <summary>
        /// Перевод всех элементов массива по переменных отдельным
        /// </summary>
        private void DoubleToTOrbVec()
        {
            P = itemss[0];
            K = itemss[1];
            Q = itemss[2];
            I = itemss[3];
            Omega = itemss[4];
            U = itemss[5];
        }

        private void TOrbVecToDouble()
        {
            itemss[0] = P;
            itemss[1] = K;
            itemss[2] = Q;
            itemss[3] = I;
            itemss[4] = Omega;
            itemss[5] = U;
        }

        private DoubleIndex Items
        {
            set
            {
                for (int i = 0; i < itemss.Lenght; i++)
                    itemss[i] = value[i];

                DoubleToTOrbVec();
            }
            get
            {
                TOrbVecToDouble();
                return itemss;
            }
        }
    }

    internal class TXYZ
    {
        private double X { get; set; }
        private double Y { get; set; }
        private double Z { get; set; }

        private DoubleIndex itemss = new DoubleIndex(3);

        private void DoubleToTXYZ()
        {
            X = itemss[0];
            Y = itemss[1];
            Z = itemss[2];
        }

        private void TXYZTpDouble()
        {
            itemss[0] = X;
            itemss[1] = Y;
            itemss[2] = Z;
        }

        private DoubleIndex Items
        {
            set
            {
                for (int i = 0; i < itemss.Lenght; i++)
                    itemss[i] = value[i];

                DoubleToTXYZ();
            }
            get
            {
                TXYZTpDouble();
                return itemss;
            }
        }
    }

    internal static class bal_types
    {
    }
}