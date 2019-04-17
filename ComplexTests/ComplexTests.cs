//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Simulator.Tests
{/// <summary>
 /// Класс для теста полярного представления комплексных чисел
 /// </summary>
    [TestFixture]
    public class PolarTest
    {
        [Test]
        public void InitTest()
        {
            Polar p1 = new Polar(1.0, 2.0);
            Assert.IsTrue(p1.R == 1.0 && p1.Phi == 2.0);

            Polar p2 = new Polar(3.0);
            Assert.IsTrue(p2.R == 3.0 && p2.Phi == 0.0);

            Complex c1 = new Complex(2.0, 2.0);
            Polar p3 = new Polar(c1);
            Assert.IsTrue(p3.R == Math.Sqrt(8.0) && p3.Phi - Math.PI / 4.0 < 0.0001, p3.ToString());

            Complex c3 = new Complex(p3);
            Assert.IsTrue(c3.Re - 2.0 < 0.000001 && c3.Im - 2.0 < 0.000001, p3.ToString());

            c1 = 1.0;
            Assert.IsTrue(Math.Abs(c1.Re - 1.0) < 0.0001 && c1.Im == 0.0, p3.ToString());
        }

        [Test]
        public void OperatorsTest()
        {
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(2, 3);

            Polar p1 = new Polar(c2);

            Complex c3 = c1 + p1;
            Assert.IsTrue(c3.Re == 3.0 && c3.Im == 5.0, c3.ToString());

            Complex c4 = p1 + c1;
            Assert.IsTrue(c4.Re == 3.0 && c4.Im == 5.0, c4.ToString());

            Complex c5 = c1 - p1;
            Assert.IsTrue(c5 == c1 - c2, c5.ToString());

            Complex c6 = p1 - c1;
            Assert.IsTrue(c6 == c2 - c1, c6.ToString());

            Complex c7 = c1 * p1;
            Assert.IsTrue(c7 == c1 * c2, c7.ToString());

            Complex c8 = p1 * c1;
            Assert.IsTrue(c8 == c2 * c1, c8.ToString());

            Complex c9 = c1 / p1;
            Assert.IsTrue(c9 == c1 / c2, c9.ToString());

            Complex c10 = p1 / c1;
            Assert.IsTrue(c10 == c2 / c1, c10.ToString());

            Complex c11 = new Complex(2, 2);
            Assert.IsTrue(((Polar)c11).R == Math.Sqrt(8.0) &&
                ((Polar)c11).Phi - Math.PI / 4.0 < 0.0001);

            Polar p2 = new Polar(c11);
            Assert.IsTrue(((Complex)p2).Abs == p2.R);
        }
    }

    /// <summary>
    /// Класс для теста комплексных чисел
    /// </summary>
    [TestFixture]
    public class ComplexTest
    {
        [Test]
        public void InitTest()
        {
            Complex c1 = new Complex();
            Assert.IsTrue(c1.Re == 0.0 && c1.Im == 0.0);

            Complex c2 = new Complex(2.1);
            Assert.IsTrue(c2.Re == 2.1 && c2.Im == 0.0);

            Complex c3 = new Complex(3.3, 4.4);
            Assert.IsTrue(c3.Re == 3.3 && c3.Im == 4.4);

            Complex c4 = new Complex(c3);
            Assert.IsTrue(c4.Re == 3.3 && c4.Im == 4.4);
        }

        [Test]
        public void CompareTest()
        {
            Complex c1 = new Complex(1.0, 2.0);
            Complex c2 = new Complex(3.0, 4.0);
            Complex c3 = new Complex(5.0, 6.0);

            c1 = c2;
            Assert.IsTrue(c1.Re == c2.Re && c1.Im == c2.Im);
            Assert.IsTrue(c1 == c2);
            Assert.IsTrue(c1 != c3);

            c1.Re = 5.0;
            c1.Im = 6.0;
            Assert.IsTrue(c1.Re != c2.Re && c1.Im != c2.Im);
            Assert.IsTrue(c1 != c2);
            Assert.IsTrue(c1 == c3);

            Complex c4 = new Complex(1, 0);
            double d = 1;
            Assert.IsTrue(c4 == d);
            Assert.IsTrue(d == c4);

            Assert.IsTrue(c3 != d);
            Assert.IsTrue(d != c3);
        }

        [Test]
        public void MiscTest()
        {
            // Проверка модуля
            Complex c1 = new Complex(1.0, 5.0);
            Assert.IsTrue(c1.Abs == Math.Sqrt(26.0) && c1.Re == 1.0 && c1.Im == 5.0, c1.ToString());

            // Комплексно-сопряженные числа
            Complex c2 = c1.GetConjugate();
            Assert.IsTrue(c2.Re == 1.0 && c2.Im == -5.0 &&
                c1.Re == 1.0 && c1.Im == 5.0, c2.ToString());

            // Просто тест "сложного" выражения
            c1 = new Complex(1.0, 5.0);
            c2 = new Complex(2.0, -4.0);
            Complex c3 = (c1 + c2 * c1) / c2;
            Assert.IsTrue(c3.Re == 0.1 && c3.Im == 5.7, c3.ToString());

            // Проверка аргумента
            double arg = c1.Arg;
            Assert.IsTrue(arg - 1.373 < 0.001, arg.ToString());

            Complex c8 = new Complex(1, 1);
            Assert.IsTrue(c8.Arg - 0.785 < 0.001, c8.Arg.ToString());

            Complex c9 = new Complex(-1, 1);
            Assert.IsTrue(c9.Arg - 2.356 < 0.001, c9.Arg.ToString());

            Complex c10 = new Complex(-1, -1);
            Assert.IsTrue(c10.Arg - 3.927 < 0.001, c10.Arg.ToString());

            Complex c11 = new Complex(1, -1);
            Assert.IsTrue(c11.Arg - 5.498 < 0.001, c11.Arg.ToString());

            // Проверка квадратного корня
            Complex c4 = new Complex(1, 4);
            Complex c5 = Complex.Sqrt(c4);
            Assert.IsTrue(c5.Re - 1.6 < 0.01 && c5.Im - 1.25 < 0.01, c5.ToString());

            Complex c6 = Complex.Sqrt(-9);
            Assert.IsTrue(c6.Re == 0 && c6.Im == 3, c6.ToString());

            Complex c7 = Complex.Sqrt(4);
            Assert.IsTrue(c7.Re == 2 && c7.Im == 0, c7.ToString());

            // Проверка константы j
            Complex c12 = Complex.J;
            Assert.IsTrue(c12.Re == 0 && c12.Im == 1, c12.ToString());

            Complex c13 = new Complex(2, 3);
            Complex c14 = c13 + Complex.J;
            Assert.IsTrue(c14.Re == 2 && c14.Im == 4, c14.ToString());
        }

        [Test]
        public void RadicalTest()
        {
            Complex c1 = new Complex(-8, 8 * Math.Sqrt(3));
            Complex[] CArr = Complex.Radical(c1, 4);
            Assert.IsTrue(CArr.Length == 4);
            Assert.IsTrue(Math.Abs(CArr[0].Re - Math.Sqrt(3)) < 0.0001 && CArr[0].Im == 1, CArr[0].ToString());
            Assert.IsTrue(Math.Abs(CArr[1].Re + 1) < 0.001 && Math.Abs(CArr[1].Im - Math.Sqrt(3)) < 0.0001, CArr[1].ToString());
            Assert.IsTrue(Math.Abs(CArr[2].Re + Math.Sqrt(3)) < 0.0001 && Math.Abs(CArr[2].Im + 1) < 0.0001, CArr[2].ToString());
            Assert.IsTrue(Math.Abs(CArr[3].Re - 1) < 0.0001 && Math.Abs(CArr[3].Im + Math.Sqrt(3)) < 0.0001, CArr[3].ToString());
        }

        [Test]
        public void AdditionTest()
        {
            Complex c1 = new Complex(1.0, 3.0);
            Complex c2 = new Complex(5.0, 6.0);
            Complex c3 = c1 + c2;

            Assert.IsTrue(c3.Re == 6.0 && c3.Im == 9.0, c3.ToString());

            c2 = c1 + 3.2;
            Assert.IsTrue(c2.Re == 4.2 && c2.Im == 3.0, c2.ToString());

            c2 = 5.6 + c1;
            Assert.IsTrue(c2.Re == 6.6 && c2.Im == 3.0, c2.ToString());

            c1 += 5;
            Assert.IsTrue(c1.Re == 6.0 && c1.Im == 3.0, c1.ToString());

            c1 = new Complex(1.0, 2.5);
            c2 = new Complex(3.6, 5.6);
            c1 += c2;
            Assert.IsTrue(c1.Re == 4.6 && c1.Im == 8.1, c1.ToString());

            c1 += c2;
            Assert.IsTrue(c1.Re == 8.2 && c1.Im == 13.7, c1.ToString());

            c1 += 10;
            Assert.IsTrue(c1.Re == 18.2 && c1.Im == 13.7, c1.ToString());
        }

        [Test]
        public void SubtractionTest()
        {
            Complex c1 = new Complex(1.0, 3.0);
            Complex c2 = new Complex(5.0, 6.0);
            Complex c3 = c1 - c2;
            Assert.IsTrue(c3.Re == -4.0 && c3.Im == -3.0, c3.ToString());

            c3 = c1 - 2;
            Assert.IsTrue(c3.Re == -1 && c3.Im == 3.0, c3.ToString());

            c3 = 5 - c1;
            Assert.IsTrue(c3.Re == 4 && c3.Im == -3.0, c3.ToString());

            c1 -= c3;
            Assert.IsTrue(c1.Re == -3 && c1.Im == 6, c1.ToString());

            c1 -= -13;
            Assert.IsTrue(c1.Re == 10 && c1.Im == 6, c1.ToString());
        }

        [Test]
        public void MultiplicationTest()
        {
            Complex c1 = new Complex(1, -2);
            Complex c2 = new Complex(3, 2);
            Complex c3 = c1 * c2;
            Complex c4 = c2 * c1;

            Assert.IsTrue(c3.Re == 7 && c3.Im == -4);
            Assert.IsTrue(c3 == c4);

            c2 = c1 * 3;
            Assert.IsTrue(c2.Re == 3 && c2.Im == -6);

            c2 = -5 * c1;
            Assert.IsTrue(c2.Re == -5 && c2.Im == 10);

            c2 *= c1;
            Assert.IsTrue(c2.Re == 15 && c2.Im == 20);

            c2 *= 0.2;
            Assert.IsTrue(c2.Re == 3 && c2.Im == 4, c2.ToString());
        }

        [Test]
        public void DivisionTest()
        {
            Complex c1 = new Complex(7, -4);
            Complex c2 = new Complex(3, 2);
            Complex c3 = c1 / c2;

            Assert.IsTrue(c3.Re == 1 && c3.Im == -2, c3.ToString());

            c1 = new Complex(10, 15);
            c2 = c1 / 5.0;
            Assert.IsTrue(c2.Re == 2 && c2.Im == 3, c2.ToString());

            c1 = new Complex(1.0, -2.0);
            c2 = 2.0 / c1;
            Assert.IsTrue(c2.Re == 0.4 && c2.Im == 0.8, c2.ToString());

            c1 /= 0.2;
            Assert.IsTrue(c1.Re == 5 && c1.Im == -10, c1.ToString());

            c2.Re = 1;
            c2.Im = 3;
            c1 /= c2;
            Assert.IsTrue(c1.Re == -2.5 && c1.Im == -2.5, c1.ToString());
        }

        [Test]
        public void ParseTest()
        {
            Complex c1 = Complex.Parse("5 +6i");
            Assert.IsTrue(c1.Re == 5 && c1.Im == 6, c1.ToString());

            Complex c2 = Complex.Parse("65 -61j");
            Assert.IsTrue(c2.Re == 65 && c2.Im == -61, c2.ToString());

            Complex c3 = Complex.Parse("+100 -02j");
            Assert.IsTrue(c3.Re == 100 && c3.Im == -2, c3.ToString());

            Complex c4 = Complex.Parse("2 +j");
            Assert.IsTrue(c4.Re == 2 && c4.Im == 1, c4.ToString());

            Complex c5 = Complex.Parse("3 -j");
            Assert.IsTrue(c5.Re == 3 && c5.Im == -1, c5.ToString());

            Complex c6 = Complex.Parse("5");
            Assert.IsTrue(c6.Re == 5 && c6.Im == 0, c6.ToString());

            Complex c7 = Complex.Parse("-78");
            Assert.IsTrue(c7.Re == -78 && c7.Im == 0, c7.ToString());

            Complex c8 = Complex.Parse("j");
            Assert.IsTrue(c8.Re == 0 && c8.Im == 1, c8.ToString());

            Complex c9 = Complex.Parse("-j");
            Assert.IsTrue(c9.Re == 0 && c9.Im == -1, c9.ToString());

            Complex c10 = Complex.Parse("5j");
            Assert.IsTrue(c10.Re == 0 && c10.Im == 5, c10.ToString());

            Complex c11 = Complex.Parse("11j");
            Assert.IsTrue(c11.Re == 0 && c11.Im == 11, c11.ToString());

            Complex c12 = Complex.Parse("-1j");
            Assert.IsTrue(c12.Re == 0 && c12.Im == -1, c12.ToString());

            Complex c13 = Complex.Parse("-23j");
            Assert.IsTrue(c13.Re == 0 && c13.Im == -23, c13.ToString());
        }

        [Test]
        public void ParseTest2()
        {
            Complex.Parse("dsfsd34");
        }

        [Test]
        public void ParseTest3()
        {
            Complex.Parse("+");
        }

        [Test]
        public void ParseTest4()
        {
            Complex.Parse("1 +- 2i");
        }

        [Test]
        public void ExpTest()
        {
            Complex c1 = new Complex(1, 3);
            Complex c2 = Complex.Exp(c1);
            Assert.IsTrue(c2.Abs - Math.Exp(1) < 0.0001 && c2.Arg - 3 < 0.0001, c2.ToString());
        }

        [Test]
        public void PowTest()
        {
            Complex c1 = new Complex(0.5, -Math.Sqrt(3) / 2);
            Complex c2 = Complex.Pow(c1, 20);
            Assert.IsTrue(Math.Abs(c2.Re + 0.5) < 0.0001 && Math.Abs(c2.Im + Math.Sqrt(3) / 2) < 0.0001, c2.ToString());

            Complex c3 = new Complex(3, 2);
            Complex c4 = Complex.Pow(c3, -2);
            Complex c5 = 1 / (c3 * c3);
            Assert.IsTrue(Math.Abs(c4.Re - c5.Re) < 0.0001 && Math.Abs(c4.Im - c5.Im) < 0.0001, c4.ToString());
        }

        [Test]
        public void SinTest()
        {
            Complex x1 = new Complex(0.1, 0.3);
            Complex x2 = new Complex(-0.1, 1.5);
            Complex x3 = new Complex(-0.5, -0.3);
            Complex x4 = new Complex(0.5, -1.2);

            Complex y1 = Complex.Sin(x1);
            Complex y2 = Complex.Sin(x2);
            Complex y3 = Complex.Sin(x3);
            Complex y4 = Complex.Sin(x4);

            Complex y1real = new Complex(0.1044, 0.3030);
            Complex y2real = new Complex(-0.2348, 2.1186);
            Complex y3real = new Complex(-0.5012, -0.2672);
            Complex y4real = new Complex(0.8681, -1.3247);

            string y1text = string.Format("MyCode = {0}; Matlab = {1}",
                y1, y1real);
            string y2text = string.Format("MyCode = {0}; Matlab = {1}",
                y2, y2real);
            string y3text = string.Format("MyCode = {0}; Matlab = {1}",
                y3, y3real);
            string y4text = string.Format("MyCode = {0}; Matlab = {1}",
                y4, y4real);

            Assert.Less(Math.Abs(y1.Re - y1real.Re), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Re - y2real.Re), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Re - y3real.Re), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Re - y4real.Re), 1e-3, y4text);

            Assert.Less(Math.Abs(y1.Im - y1real.Im), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Im - y2real.Im), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Im - y3real.Im), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Im - y4real.Im), 1e-3, y4text);
        }

        [Test]
        public void CosTest()
        {
            Complex x1 = new Complex(0.1, 0.3);
            Complex x2 = new Complex(-0.1, 1.5);
            Complex x3 = new Complex(-0.5, -0.3);
            Complex x4 = new Complex(0.5, -1.2);

            Complex y1 = Complex.Cos(x1);
            Complex y2 = Complex.Cos(x2);
            Complex y3 = Complex.Cos(x3);
            Complex y4 = Complex.Cos(x4);

            Complex y1real = new Complex(1.0401, -0.0304);
            Complex y2real = new Complex(2.3407, 0.2126);
            Complex y3real = new Complex(0.9174, -0.1460);
            Complex y4real = new Complex(1.5890, 0.7237);

            string y1text = string.Format("Y1 MyCode = {0}; Matlab = {1}",
                y1, y1real);
            string y2text = string.Format("Y2 MyCode = {0}; Matlab = {1}",
                y2, y2real);
            string y3text = string.Format("Y3 MyCode = {0}; Matlab = {1}",
                y3, y3real);
            string y4text = string.Format("Y4 MyCode = {0}; Matlab = {1}",
                y4, y4real);

            Assert.Less(Math.Abs(y1.Re - y1real.Re), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Re - y2real.Re), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Re - y3real.Re), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Re - y4real.Re), 1e-3, y4text);

            //Console.WriteLine (x1.Arg);
            Assert.Less(Math.Abs(y1.Im - y1real.Im), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Im - y2real.Im), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Im - y3real.Im), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Im - y4real.Im), 1e-3, y4text);
        }

        [Test]
        public void AsinTest()
        {
            Complex x1 = new Complex(0.1, 0.3);
            Complex x2 = new Complex(-0.1, 1.5);
            Complex x3 = new Complex(-0.5, -0.3);
            Complex x4 = new Complex(0.5, -1.2);

            Complex y1 = Complex.Asin(x1);
            Complex y2 = Complex.Asin(x2);
            Complex y3 = Complex.Asin(x3);
            Complex y4 = Complex.Asin(x4);

            Complex y1real = new Complex(0.0959, 0.2970);
            Complex y2real = new Complex(-0.0554, 1.1960);
            Complex y3real = new Complex(-0.4930, -0.3343);
            Complex y4real = new Complex(0.3157, -1.0553);

            string y1text = string.Format("Y1 MyCode = {0}; Matlab = {1}",
                y1, y1real);
            string y2text = string.Format("Y2 MyCode = {0}; Matlab = {1}",
                y2, y2real);
            string y3text = string.Format("Y3 MyCode = {0}; Matlab = {1}",
                y3, y3real);
            string y4text = string.Format("Y4 MyCode = {0}; Matlab = {1}",
                y4, y4real);

            Assert.Less(Math.Abs(y1.Re - y1real.Re), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Re - y2real.Re), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Re - y3real.Re), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Re - y4real.Re), 1e-3, y4text);

            Assert.Less(Math.Abs(y1.Im - y1real.Im), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Im - y2real.Im), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Im - y3real.Im), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Im - y4real.Im), 1e-3, y4text);
        }

        [Test]
        public void AcosTest()
        {
            Complex x1 = new Complex(0.1, 0.3);
            Complex x2 = new Complex(-0.1, 1.5);
            Complex x3 = new Complex(-0.5, -0.3);
            Complex x4 = new Complex(0.5, -1.2);

            Complex y1 = Complex.Acos(x1);
            Complex y2 = Complex.Acos(x2);
            Complex y3 = Complex.Acos(x3);
            Complex y4 = Complex.Acos(x4);

            Complex y1real = new Complex(1.4749, -0.2970);
            Complex y2real = new Complex(1.6262, -1.1960);
            Complex y3real = new Complex(2.0638, 0.3343);
            Complex y4real = new Complex(1.2551, 1.0553);

            string y1text = string.Format("Y1 MyCode = {0}; Matlab = {1}",
                y1, y1real);
            string y2text = string.Format("Y2 MyCode = {0}; Matlab = {1}",
                y2, y2real);
            string y3text = string.Format("Y3 MyCode = {0}; Matlab = {1}",
                y3, y3real);
            string y4text = string.Format("Y4 MyCode = {0}; Matlab = {1}",
                y4, y4real);

            Assert.Less(Math.Abs(y1.Re - y1real.Re), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Re - y2real.Re), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Re - y3real.Re), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Re - y4real.Re), 1e-3, y4text);

            Assert.Less(Math.Abs(y1.Im - y1real.Im), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Im - y2real.Im), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Im - y3real.Im), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Im - y4real.Im), 1e-3, y4text);
        }

        [Test]
        public void LogTest()
        {
            Complex x1 = new Complex(0.1, 0.3);
            Complex x2 = new Complex(-0.1, 1.5);
            Complex x3 = new Complex(-0.5, -0.3);
            Complex x4 = new Complex(0.5, -1.2);

            Complex y1 = Complex.Log(x1);
            Complex y2 = Complex.Log(x2);
            Complex y3 = Complex.Log(x3);
            Complex y4 = Complex.Log(x4);

            Complex y1real = new Complex(-1.1513, 1.2490);
            Complex y2real = new Complex(0.4077, 1.6374);
            Complex y3real = new Complex(-0.5394, -2.6012);
            Complex y4real = new Complex(0.2624, -1.1760);

            string y1text = string.Format("Y1 MyCode = {0}; Matlab = {1}",
                y1, y1real);
            string y2text = string.Format("Y2 MyCode = {0}; Matlab = {1}",
                y2, y2real);
            string y3text = string.Format("Y3 MyCode = {0}; Matlab = {1}",
                y3, y3real);
            string y4text = string.Format("Y4 MyCode = {0}; Matlab = {1}",
                y4, y4real);

            Assert.Less(Math.Abs(y1.Re - y1real.Re), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Re - y2real.Re), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Re - y3real.Re), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Re - y4real.Re), 1e-3, y4text);

            Assert.Less(Math.Abs(y1.Im - y1real.Im), 1e-3, y1text);
            Assert.Less(Math.Abs(y2.Im - y2real.Im), 1e-3, y2text);
            Assert.Less(Math.Abs(y3.Im - y3real.Im), 1e-3, y3text);
            Assert.Less(Math.Abs(y4.Im - y4real.Im), 1e-3, y4text);
        }

        public static void Main()
        {
            //FourierTest ft = new FourierTest();
            //ft.FFTTest3();

            Complex c = new Complex(0.5, -1.25);
            Complex x1 = Complex.Pow(c, 1);
            Complex x2 = Complex.Pow(c, 2);
        }
    }
}