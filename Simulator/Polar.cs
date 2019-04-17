using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// Полярное приедставление комплексного числа
    /// </summary>
    public class Polar
    {
        /// <summary>
        /// Радиус, по сути модуль
        /// </summary>
        private double m_r;

        /// <summary>
        /// Угол
        /// </summary>
        private double m_phi;

        #region Конструкторы

        public Polar(double r)
        {
            m_r = r;
            m_phi = 0.0;
        }

        public Polar(double r, double phi)
        {
            m_r = r;
            m_phi = phi;
        }

        public Polar(Complex x)
        {
            m_r = x.Abs;
            m_phi = x.Arg;
        }

        #endregion Конструкторы

        public Complex Complex
        {
            get
            {
                return new Complex(this);
            }

            set
            {
                m_r = value.Abs;
                m_phi = value.Arg;
            }
        }

        public double R
        {
            get { return m_r; }
            set { m_r = value; }
        }

        public double Phi
        {
            get { return m_phi; }
            set { m_phi = value; }
        }

        public override string ToString()
        {
            return "r=" + m_r.ToString() + " phi=" + m_phi.ToString();
        }

        public static implicit operator Complex(Polar p)
        {
            return new Complex(p);
        }

        public static explicit operator Polar(Complex c)
        {
            return new Polar(c);
        }
    }
}