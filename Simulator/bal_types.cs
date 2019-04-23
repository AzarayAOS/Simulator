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
    public class DoubleIndex
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

        public DoubleIndex(double[] value)
        {
            _source = new double[value.Length];

            _source = value;
        }
    }

    public class TOrbVec
    {
        public double P { get; set; }
        public double K { get; set; }
        public double Q { get; set; }
        public double I { get; set; }
        public double Omega { get; set; }
        public double U { get; set; }

        private DoubleIndex itemss = new DoubleIndex(6);

        #region Конструкторы

        /// <summary>
        /// Принимает отдельные переменные
        /// </summary>
        /// <param name="P"></param>
        /// <param name="K"></param>
        /// <param name="Q"></param>
        /// <param name="I"></param>
        /// <param name="Omega"></param>
        /// <param name="U"></param>
        public TOrbVec(double P, double K, double Q, double I, double Omega, double U)
        {
            this.P = P;
            this.K = K;
            this.Q = Q;
            this.I = I;
            this.Omega = Omega;
            this.U = U;

            DoubleToTOrbVec();
        }

        /// <summary>
        /// Принимает массив занчений и раскидывает его по переменным
        /// </summary>
        /// <param name="value"></param>
        public TOrbVec(double[] value)
        {
            itemss = new DoubleIndex(value);
            TOrbVecToDouble();
        }

        #endregion Конструкторы

        #region Перекидывание значений из одного блока переменных в другой

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

        #endregion Перекидывание значений из одного блока переменных в другой

        public DoubleIndex Items
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

    public class TXYZ
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        private DoubleIndex itemss = new DoubleIndex(3);

        #region Конструкторы

        /// <summary>
        ///  Принимает отдельные переменные
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public TXYZ(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            TXYZTpDouble();
        }

        /// <summary>
        /// Принимает массив занчений
        /// </summary>
        /// <param name="value"></param>
        public TXYZ(double[] value)
        {
            itemss = new DoubleIndex(value);
            DoubleToTXYZ();
        }

        #endregion Конструкторы

        #region Перекидывание значений из одного блока переменных в другой

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

        #endregion Перекидывание значений из одного блока переменных в другой

        public DoubleIndex Items

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

    public class TXYZVxVyVz
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double VX { get; set; }
        public double VY { get; set; }
        public double VZ { get; set; }

        public TXYZ Pos, Vel;

        private DoubleIndex itemss = new DoubleIndex(6);

        public DoubleIndex Items
        {
            set
            {
                for (int i = 0; i < itemss.Lenght; i++)
                    itemss[i] = value[i];

                Metod4();
                Metod3();
            }
            get
            {
                return itemss;
            }
        }

        #region Методы перекидывания значений из одного блока переменных в другой

        // Будет 4 процедуры переноса значений между тремя видами хранения данных
        // данные хранятся в переменных X, Y, Z , VX, Vy, VZ типа double
        // в переменных Pos и Vel типа TXYZ
        // и в массиве itemss типа double
        // Каждая их процедур будет определять направление переноса значений,
        // которые будут вызываться в определенном порядке.
        // 1 -- из переменных X, Y, Z , VX, Vy, VZ в Pos и Vel типа TXYZ
        // 2 -- из переменных X, Y, Z , VX, Vy, VZ в массив itemss
        // 3 -- из переменных Pos и Vel типа TXYZ в переменные X, Y, Z , VX, Vy, VZ
        // 4 -- из массива itemss в Pos и Vel типа TXYZ
        // При приходе значения в переменные X, Y, Z , VX, Vy, VZ -- вызываются 1,2
        // При приходе значения в переменные Pos и Vel типа TXYZ  -- вызываются 3,2
        // При приходе значения в переменные массива itemss       -- вызываются 4,3

        /// <summary>
        /// из переменных X, Y, Z , VX, Vy, VZ в Pos и Vel типа TXYZ
        /// </summary>
        private void Metod1()
        {
            Pos = new TXYZ(X, Y, Z);
            Vel = new TXYZ(VX, VY, VZ);
        }

        /// <summary>
        /// из переменных X, Y, Z , VX, Vy, VZ в массив itemss
        /// </summary>
        private void Metod2()
        {
            itemss[0] = X;
            itemss[1] = Y;
            itemss[2] = Z;
            itemss[3] = VX;
            itemss[4] = VY;
            itemss[5] = VZ;
        }

        /// <summary>
        /// из переменных Pos и Vel типа TXYZ в переменные X, Y, Z , VX, Vy, VZ
        /// </summary>
        private void Metod3()
        {
            X = Pos.X;
            Y = Pos.Y;
            Z = Pos.Z;

            VX = Vel.X;
            VY = Vel.Y;
            VZ = Vel.Z;
        }

        /// <summary>
        ///  из массива itemss в Pos и Vel типа TXYZ
        /// </summary>
        private void Metod4()
        {
            Pos = new TXYZ(itemss[0], itemss[1], itemss[2]);
            Vel = new TXYZ(itemss[3], itemss[4], itemss[5]);
        }

        #endregion Методы перекидывания значений из одного блока переменных в другой

        #region Конструкторы

        /// <summary>
        /// Принимает отдельные переменные
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="VX"></param>
        /// <param name="VY"></param>
        /// <param name="VZ"></param>
        public TXYZVxVyVz(double X, double Y, double Z, double VX, double VY, double VZ)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;

            this.VX = VX;
            this.VY = VY;
            this.VZ = VZ;

            Metod1();
            Metod2();
        }

        /// <summary>
        /// Принимает два типа TXYZ
        /// </summary>
        /// <param name="Pos">Pos</param>
        /// <param name="Vel">Vel</param>
        public TXYZVxVyVz(TXYZ Pos, TXYZ Vel)
        {
            this.Pos = Pos;
            this.Vel = Vel;

            Metod3();
            Metod2();
        }

        /// <summary>
        /// Принимает массив значений
        /// </summary>
        /// <param name="val"></param>
        public TXYZVxVyVz(double[] val)
        {
            itemss = new DoubleIndex(val);

            Metod4();
            Metod3();
        }

        #endregion Конструкторы
    }

    public class TSpher6d
    {
        public double Ra { get; set; }
        public double Dec { get; set; }
        public double R { get; set; }
        public double Vra { get; set; }
        public double Vdec { get; set; }
        public double Vr { get; set; }

        private DoubleIndex itemss = new DoubleIndex(6);

        public DoubleIndex Items
        {
            set
            {
                for (int i = 0; i < itemss.Lenght; i++)
                    itemss[i] = value[i];

                DoubleToTSpher6d();
            }
            get
            {
                TSpher6dToDouble();
                return itemss;
            }
        }

        #region Перекидывание значений из одного блока переменных в другой

        private void DoubleToTSpher6d()
        {
            Ra = itemss[0];
            Dec = itemss[1];
            R = itemss[2];
            Vra = itemss[3];
            Vdec = itemss[4];
            Vr = itemss[5];
        }

        private void TSpher6dToDouble()
        {
            itemss[0] = Ra;
            itemss[1] = Dec;
            itemss[2] = R;
            itemss[3] = Vra;
            itemss[4] = Vdec;
            itemss[5] = Vr;
        }

        #endregion Перекидывание значений из одного блока переменных в другой

        #region Конструкторы

        /// <summary>
        /// Передаются параметры отдельно
        /// </summary>
        /// <param name="Ra"></param>
        /// <param name="Dec"></param>
        /// <param name="R"></param>
        /// <param name="Vra"></param>
        /// <param name="Vdec"></param>
        /// <param name="Vr"></param>
        public TSpher6d(double Ra, double Dec, double R, double Vra, double Vdec, double Vr)
        {
            this.Ra = Ra;
            this.Dec = Dec;
            this.R = R;
            this.Vra = Vra;
            this.Vdec = Vdec;
            this.Vr = Vr;

            TSpher6dToDouble();
        }

        /// <summary>
        /// Передают массив параметров
        /// </summary>
        /// <param name="val"></param>
        public TSpher6d(double[] val)
        {
            itemss = new DoubleIndex(val);
            DoubleToTSpher6d();
        }

        #endregion Конструкторы
    }

    public class TIOrb
    {
        public double A { get; set; }   // большая полуось
        public double E { get; set; }   // эксцентриситет
        public double I { get; set; }   // наклон
        public double Ap { get; set; }  // аргумент перигея
        public double Ra { get; set; }  // Прямое восхождение восходящего узла
        public double V { get; set; }   // Истинная аномалия

        private DoubleIndex itemss = new DoubleIndex(6);

        public DoubleIndex Items
        {
            set
            {
                for (int i = 0; i < itemss.Lenght; i++)
                    itemss[i] = value[i];

                DoubleToTSpher6d();
            }
            get
            {
                TSpher6dToDouble();
                return itemss;
            }
        }

        #region Перекидывание значений из одного блока переменных в другой

        private void DoubleToTSpher6d()
        {
            A = itemss[0];
            E = itemss[1];
            I = itemss[2];
            Ap = itemss[3];
            Ra = itemss[4];
            V = itemss[5];
        }

        private void TSpher6dToDouble()
        {
            itemss[0] = A;
            itemss[1] = E;
            itemss[2] = I;
            itemss[3] = Ap;
            itemss[4] = Ra;
            itemss[5] = V;
        }

        #endregion Перекидывание значений из одного блока переменных в другой

        #region Конструкторы

        /// <summary>
        /// Передаются параметры отдельно
        /// </summary>
        /// <param name="A"></param>
        /// <param name="E"></param>
        /// <param name="I"></param>
        /// <param name="Ap"></param>
        /// <param name="Ra"></param>
        /// <param name="V"></param>
        public TIOrb(double A, double E, double I, double Ap, double Ra, double V)
        {
            this.A = A;
            this.E = E;
            this.I = I;
            this.Ap = Ap;
            this.Ra = Ra;
            this.V = V;

            TSpher6dToDouble();
        }

        /// <summary>
        /// Передают массив параметров
        /// </summary>
        /// <param name="val"></param>
        public TIOrb(double[] val)
        {
            itemss = new DoubleIndex(val);
            DoubleToTSpher6d();
        }

        #endregion Конструкторы
    }

    public class TNoradOrb
    {
        public double Mm { get; set; }  // среднее движение, рад / мин
        public double I { get; set; }   // наклон
        public double E { get; set; }   // эксцентриситет
        public double Ma { get; set; }  // означает аномалию
        public double Ap { get; set; }  // аргумент перигея
        public double Ra { get; set; }  // Прямое восхождение по восходящему узлу

        private DoubleIndex itemss = new DoubleIndex(6);

        public DoubleIndex Items
        {
            set
            {
                for (int i = 0; i < itemss.Lenght; i++)
                    itemss[i] = value[i];

                DoubleToTSpher6d();
            }
            get
            {
                TSpher6dToDouble();
                return itemss;
            }
        }

        #region Перекидывание значений из одного блока переменных в другой

        private void DoubleToTSpher6d()
        {
            Mm = itemss[0];
            E = itemss[1];
            I = itemss[2];
            Ma = itemss[3];
            Ap = itemss[4];
            Ra = itemss[5];
        }

        private void TSpher6dToDouble()
        {
            itemss[0] = Mm;
            itemss[1] = E;
            itemss[2] = I;
            itemss[3] = Ma;
            itemss[4] = Ap;
            itemss[5] = Ra;
        }

        #endregion Перекидывание значений из одного блока переменных в другой

        #region Конструкторы

        /// <summary>
        /// Передаются параметры отдельно
        /// </summary>
        /// <param name="Mm"></param>
        /// <param name="E"></param>
        /// <param name="I"></param>
        /// <param name="Ma"></param>
        /// <param name="Ap"></param>
        /// <param name="Ra"></param>
        public TNoradOrb(double Mm, double I, double E, double Ma, double Ap, double Ra)
        {
            this.Mm = Mm;
            this.E = I;
            this.I = E;
            this.Ma = Ma;
            this.Ap = Ap;
            this.Ra = Ra;

            TSpher6dToDouble();
        }

        /// <summary>
        /// Передают массив параметров
        /// </summary>
        /// <param name="val"></param>
        public TNoradOrb(double[] val)
        {
            itemss = new DoubleIndex(val);
            DoubleToTSpher6d();
        }

        #endregion Конструкторы
    }

    public class TRFL
    {
        public double R { get; set; }
        public double F { get; set; }
        public double L { get; set; }

        public TRFL(double R, double F, double L)
        {
            this.R = R;
            this.F = F;
            this.L = L;
        }
    }

    public class TMeasurementDate
    {
        public double Time { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double JD { get; set; }

        #region Конструкторы

        public TMeasurementDate(double time, int day, int month, int year, double JD)
        {
            this.Time = time;
            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.JD = JD;
        }

        public TMeasurementDate(TMeasurementDate TM)
        {
            this.Time = TM.Time;
            this.Day = TM.Day;
            this.Month = TM.Month;
            this.Year = TM.Year;
            this.JD = TM.JD;
        }

        #endregion Конструкторы
    }

    public class TMeasurementCycle
    {
        private TMeasurementDate start;

        public TMeasurementDate Start
        {
            get
            {
                return start;
            }
            set
            {
                start = new TMeasurementDate(value);
            }
        }

        private TMeasurementDate stop;

        public TMeasurementDate Stop
        {
            get
            {
                return stop;
            }
            set
            {
                stop = new TMeasurementDate(value);
            }
        }

        public double Step { get; set; }

        #region Конструкторы

        public TMeasurementCycle(TMeasurementDate start, TMeasurementDate stop, double step)
        {
            this.start = new TMeasurementDate(start);
            this.stop = new TMeasurementDate(stop);
            this.Step = step;
        }

        public TMeasurementCycle(TMeasurementCycle TM)
        {
            this.start = TM.Start;
            this.stop = TM.Stop;
            this.Step = TM.Step;
        }

        #endregion Конструкторы
    }

    /// <summary>
    /// Класс, способный хранить значения
    /// и в формате UTF и в формате ANSI
    /// а так же осуществлять первод из первой во второй
    /// </summary>
    public class AnsiChar
    {
        private readonly Encoding ANSI = Encoding.GetEncoding(1252);
        private readonly Encoding UTF8 = Encoding.UTF8;

        private byte[] utf8_bytes, ansi_bytes;

        public AnsiChar(int size = 1)
        {
            utf8_bytes = new byte[size];
            ansi_bytes = new byte[size];
        }

        /// <summary>
        /// Занесение строки (1 символ) в формате UTF8
        /// а затем конвертация в ansi
        /// </summary>
        /// <param name="s">Символ для кодирования</param>
        public void SetUTF8(string s)
        {
            if (s.Length == 1)
            {
                utf8_bytes = UTF8.GetBytes(s);
                UtfToAnsi();
            }
        }

        /// <summary>
        /// вернуть символ в формате ansi
        /// </summary>
        /// <returns></returns>
        public byte GetAnsi()
        {
            return ansi_bytes[0];
        }

        /// <summary>
        /// конвертация
        /// </summary>
        private void UtfToAnsi()
        {
            ansi_bytes = Encoding.Convert(UTF8, ANSI, utf8_bytes);
        }
    }

    /// <summary>
    /// Класс, руализующий массив класса AnsiChar
    /// </summary>
    public class TTLELine
    {
        private AnsiChar[] date;

        public TTLELine(int size = 1)
        {
            date = new AnsiChar[size];

            for (int i = 0; i < size; i++)
                date[i] = new AnsiChar();
        }

        public AnsiChar this[int index]
        {
            get
            {
                return date[index];
            }
            set
            {
                date[index] = value;
            }
        }
    }

    public static class bal_types
    {
    }
}