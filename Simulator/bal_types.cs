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

    /// <summary>
    /// Класс массива типа int,
    /// чтоб можно было использовать set и get, а так же индексы
    /// </summary>
    public class IntegerIndex
    {
        private int[] _source;
        public int Lenght { get { return _source.Length; } }

        public int this[int index]
        {
            get { return _source[index]; }
            set { _source[index] = value; }
        }

        public IntegerIndex(int size)
        {
            _source = new int[size];
        }

        public IntegerIndex(int[] value)
        {
            _source = new int[value.Length];
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

        public DoubleIndex itemss = new DoubleIndex(6);

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

        //public DoubleIndex Items
        //{
        //    set
        //    {
        //        for (int i = 0; i < itemss.Lenght; i++)
        //            itemss[i] = value[i];

        //        DoubleToTOrbVec();
        //    }
        //    get
        //    {
        //        TOrbVecToDouble();
        //        return itemss;
        //    }
        //}
    }

    public class TXYZ
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public DoubleIndex itemss = new DoubleIndex(3);

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

        //public DoubleIndex Items

        //{
        //    set
        //    {
        //        for (int i = 0; i < itemss.Lenght; i++)
        //            itemss[i] = value[i];

        //        DoubleToTXYZ();
        //    }
        //    get
        //    {
        //        TXYZTpDouble();
        //        return itemss;
        //    }
        //}
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

        public DoubleIndex itemss = new DoubleIndex(6);

        //public DoubleIndex Items
        //{
        //    set
        //    {
        //        for (int i = 0; i < itemss.Lenght; i++)
        //            itemss[i] = value[i];

        //        Metod4();
        //        Metod3();
        //    }
        //    get
        //    {
        //        return itemss;
        //    }
        //}

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

        public DoubleIndex itemss = new DoubleIndex(6);

        //public DoubleIndex Items
        //{
        //    set
        //    {
        //        for (int i = 0; i < itemss.Lenght; i++)
        //            itemss[i] = value[i];

        //        DoubleToTSpher6d();
        //    }
        //    get
        //    {
        //        TSpher6dToDouble();
        //        return itemss;
        //    }
        //}

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

        public DoubleIndex itemss = new DoubleIndex(6);

        //public DoubleIndex Items
        //{
        //    set
        //    {
        //        for (int i = 0; i < itemss.Lenght; i++)
        //            itemss[i] = value[i];

        //        DoubleToTSpher6d();
        //    }
        //    get
        //    {
        //        TSpher6dToDouble();
        //        return itemss;
        //    }
        //}

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

        public DoubleIndex itemss = new DoubleIndex(6);

        //public DoubleIndex Items
        //{
        //    set
        //    {
        //        for (int i = 0; i < itemss.Lenght; i++)
        //            itemss[i] = value[i];

        //        DoubleToTSpher6d();
        //    }
        //    get
        //    {
        //        TSpher6dToDouble();
        //        return itemss;
        //    }
        //}

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
        //private readonly Encoding ANSI = Encoding.GetEncoding(1252);
        private readonly Encoding ANSI = Encoding.ASCII;

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
        /// <returns>возвращает в байтах</returns>
        public byte GetAnsiByte()
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

        public TTLELine(int size = 70)
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

    public class TTLETypeEx
    {
        public int SatID { get; set; }

        private TTLELine[] TLE;

        public TTLETypeEx()
        {
            TLE = new TTLELine[2];
            TLE[0] = new TTLELine();
            TLE[1] = new TTLELine();
        }

        /// <summary>
        /// Установить занчение переменной TLE
        /// </summary>
        /// <param name="i">Индекс</param>
        /// <param name="value">Значение</param>
        public void SetTLE(int i, TTLELine value)
        {
            TLE[i] = value;
        }

        /// <summary>
        /// Получить значение TLE
        /// </summary>
        /// <param name="i">Индекс </param>
        /// <returns></returns>
        public TTLELine GetTLE(int i)
        {
            return TLE[i];
        }
    }

    public class TSGP_Data
    {
        public double Epoch { get; set; }           // Материал из файла
        public double Julian_Epoch { get; set; }   // Юлианская дата
        public double Xno { get; set; }             // Среднее движение, рад / мин
        public double Bstar { get; set; }           // Коэффициент трения
        public double Xincl { get; set; }           // наклон
        public double Eo { get; set; }              // эксцентриситет
        public double Xmo { get; set; }             // означает аномалию
        public double Omegao { get; set; }          // аргумент перигея
        public double Xnodeo { get; set; }          // Прямое восхождение по восходящему узлу
        public double Xndt2o { get; set; }          // Первая производная от среднего движения рад / мин ^ 2
        public double Xndd6o { get; set; }          // Второй раз производная от среднего движения radmin ^ 3
        public int Ideep { get; set; }              // 0 - период <225 мин, 1 период> 225 мин

        public IntegerIndex Catnr = new IntegerIndex(4);
        public IntegerIndex Elset = new IntegerIndex(2);
    }

    public class TAdditionalSatData
    {
        public string Identifier { get; set; }
        public string LaunchName { get; set; }
        public string SatName { get; set; }
        public string LaunchOrg { get; set; }
        public string LaunchDate { get; set; }

        public double RCS { get; set; }
        public double Magnitude { get; set; }
    }

    public class TAdditionalSatDataFull
    {
        public int NoradNum { get; set; }

        public string InternationalDesignator { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string LaunchOrg { get; set; }
        public string LaunchDate { get; set; }
        public string OrbitStatus { get; set; }
        public string DateOfOrbitStatusChange { get; set; }
        public string OrbitType { get; set; }

        public bool Operational { get; set; }
        public bool ParamsFilled { get; set; }
        public string Name3 { get; set; }
        public string Country { get; set; }
        public string Operator { get; set; }
        public string SatType { get; set; }

        public double A { get; set; }
        public double E { get; set; }
        public double I { get; set; }
        public double LaunchMass { get; set; }
        public double DryMass { get; set; }
        public double Power { get; set; }

        public string LaunchSite { get; set; }
        public string LaunchVehicle { get; set; }
        public string Comments { get; set; }

        public AnsiChar BigComments = new AnsiChar(128);
    }

    public class TNonNoradDBItem
    {
        public double[] NoradVec;
        public double DragTerm { get; set; }
        public double RefTimeJD1957 { get; set; }
        public string Name { get; set; }
    }

    public class TNonNoradDBItemArray
    {
        private TNonNoradDBItem[] date;

        /// <summary>
        /// количество элементов
        /// </summary>
        /// <param name="size"></param>
        public TNonNoradDBItemArray(int size = 1)
        {
            date = new TNonNoradDBItem[size];

            for (int i = 0; i < size; i++)
                date[i] = new TNonNoradDBItem();
        }

        public TNonNoradDBItem this[int index]
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

    public class TMeasurementData
    {
        public double Declination { get; set; }
        public double RightAscension { get; set; }
        public double Elevation { get; set; }
        public double Azimuth { get; set; }
        public double Time { get; set; }
        public double DeclSp { get; set; }
        public double RASp { get; set; }

        public double VD { get; set; }      // доплеровская скорость

        public double Magnitude { get; set; }
    }

    public class TMeasurementDataArray
    {
        private TMeasurementData[] date;

        /// <summary>
        /// количество элементов
        /// </summary>
        /// <param name="size"></param>
        public TMeasurementDataArray(int size = 1)
        {
            date = new TMeasurementData[size];

            for (int i = 0; i < size; i++)
                date[i] = new TMeasurementData();
        }

        public TMeasurementData this[int index]
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

    public class tObserverParameters
    {
        public int O_type { get; set; } // 0 - радар, 1 - телескоп
        public double H { get; set; }
        public double F { get; set; }
        public double L { get; set; }

        public TXYZ XYZPGSK { get; set; }

        public double MinElev { get; set; }

        public double MaxRange { get; set; }
        public double ElevPrec { get; set; }
        public double AzPrec { get; set; }
        public double RangePrec { get; set; }
        public double VelPrec { get; set; }
        public double AccelPrec { get; set; }
        public double AzVelPrec { get; set; }
        public double ElVelPrec { get; set; }
        public double ElevFOV { get; set; }
        public double AzFOV { get; set; }

        public double RaPrec { get; set; }
        public double DecPrec { get; set; }
        public double SunAng { get; set; }
        public double FOV { get; set; }
    }

    public class TBlipsData
    {
        public double Time { get; set; }
        public double RightAscension { get; set; }
        public double Declination { get; set; }
        public double PrecRA { get; set; }
        public double PrecDecl { get; set; }
        public double Dist { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public double DayTime { get; set; }
        public int DayNr { get; set; }
        public double JD { get; set; }
        public bool Exclude { get; set; }

        public TXYZ XyzRad { get; set; }
        public bool XyzRadSet { get; set; }
    }

    public class TBlipsDataArray
    {
        private TBlipsData[] date;

        /// <summary>
        /// количество элементов
        /// </summary>
        /// <param name="size"></param>
        public TBlipsDataArray(int size = 1)
        {
            date = new TBlipsData[size];

            for (int i = 0; i < size; i++)
                date[i] = new TBlipsData();
        }

        public TBlipsData this[int index]
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

    public class TBlipsDataArray2D
    {
        private TBlipsData[,] date;

        /// <summary>
        /// Количество элементов в матрице
        /// </summary>
        /// <param name="size1">Строки</param>
        /// <param name="size2">Столбци</param>
        public TBlipsDataArray2D(int size1 = 1, int size2 = 1)
        {
            date = new TBlipsData[size1, size2];

            for (int i = 0; i < size1; i++)
                for (int j = 0; j < size2; j++)
                    date[i, j] = new TBlipsData();
        }

        public TBlipsData this[int index1, int index2]
        {
            get
            {
                return date[index1, index2];
            }
            set
            {
                date[index1, index2] = value;
            }
        }
    }

    public class TCPFBlipsData
    {
        public double Jd1957 { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class TCPFBlipsDataArray
    {
        private TCPFBlipsData[] date;

        /// <summary>
        /// количество элементов
        /// </summary>
        /// <param name="size"></param>
        public TCPFBlipsDataArray(int size = 1)
        {
            date = new TCPFBlipsData[size];

            for (int i = 0; i < size; i++)
                date[i] = new TCPFBlipsData();
        }

        public TCPFBlipsData this[int index]
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

    public class TSimpleBlipsData
    {
        public double Jd1957 { get; set; }
        public double Ra { get; set; }
        public double Dec { get; set; }
        public double SigRa { get; set; }
        public double SigDec { get; set; }
    }

    public class TSimpleBlipsDataArray
    {
        private TSimpleBlipsData[] date;

        /// <summary>
        /// количество элементов
        /// </summary>
        /// <param name="size"></param>
        public TSimpleBlipsDataArray(int size = 1)
        {
            date = new TSimpleBlipsData[size];

            for (int i = 0; i < size; i++)
                date[i] = new TSimpleBlipsData();
        }

        public TSimpleBlipsData this[int index]
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
        private const double WZ = 0.7292115855E-4;
        private const double ALFA = 1 / 298.25;
        private const double AE = 6378.137;
        private const double JD2000 = 15341.5;              // Юлианская дата 1 января 2000 г. 12:00:00 с 31 декабря 1957 г. 00:00:00
        private const double J2000 = 2451545.0;             // Юлианская дата 1 января 2000 г. 12:00:00 от н.э.
        private const double J1991_25 = 2448349.0625;
        private const double J1957 = 2436203.5;             // Юлианская дата 31 декабря 1957 г. 00:00:00 от н.э.
        private const double J0000 = 1721060.25;            // Юлианская дата 0.1.1 00:00:00
        private const double JD2MJD = 2400000.5;

        private const double GM = 3.986004418e14;           // EGM96
        private const double GM_km = GM / 1000000000;
        private const double MUM = GM_km;
        private const double MU = MUM;
        private const double R0km = 6378.137;               // экваториальный радиус WGS'84
        private const double R0 = 6378137;                  // WGS'84
        private const double RSun = 1390600;
        private const double R3km = 6378.136;
        private const double Q = 4.65e-6;                   // Н/(m^2)
        private const double EarthMajorSemiAxis = 149597887.5;
        private const double KDiffuse = 1.44;
        private const double KMirror = 1.0f;
        private const double LightSpeed = 299792.458;       // км/с
        private const double EarthRotSpeed = 7.292115e-5;   // рад / с WGS'84
        private const double AEarth = 6378.137;             // WGS'84
        private const double EEarth = 1 / 298.257223560;    // WGS'84
        private const double Mu_sol = GM_km * 1.989e30 / 5.9764e24;
        private const double Mu_lun = GM_km * 7.350e22 / 5.9764e24;
        private const double Twopi = 2 * Math.PI;
        private const double R_g = 180 / Math.PI;
        private const double G_r = 1 / R_g;
        private const double Sr = 696000.0;                 // Солнечный радиус - километры (IAU 76)
        private const double AU = 1.49597870691E8;          // Астрономическая единица измерения - километры (IAU 76)
        private const double Xmnpda = 1440.0f;              // Минут в день
        private const double Secday = Xmnpda * 60;          // Секунд в день
        private const double Omega_E = 1.00273790934;       // вращения Земли за звездный день (непостоянный)
        private const double Omega_ER = Omega_E * Twopi;    // Вращение Земли, радианы в звездный день
        private const double Xkmper = 6378.137;             // Экваториальный радиус Земли - километры (WGS '84)
        private const double Eflat = 1 / 298.257223563;     // Земля выравнивание (WGS '84)
        private const double Ge = 398600.4418;              // Гравитационная постоянная Земли (WGS '84)

        public static double Sqr(double t1)
        {
            return t1 * t1;
        }

        public static void Magnitude(ref double[] v)
        {
            v[3] = Math.Sqrt(Sqr(v[0]) + Sqr(v[1]) + Sqr(v[2]));
        }

        public static double Dot(double[] v1, double[] v2)
        {
            return v1[1] * v2[1] + v1[2] * v2[2] + v1[3] * v2[3];
        }

        public static void TLELineCRC(string line1, ref int crc)
        {
            crc = 0;
            for (int i = 1; i < line1.Length; i++)
            {
                int temp = Encoding.ASCII.GetBytes(line1)[i];
                if (temp == 45)
                    crc++;
                else
                {
                    if ((temp >= 48) && (temp <= 57))
                    {
                        crc = crc + temp - 48;
                    }
                }
            }

            crc = crc % 10;
        }

        /// <summary>
        /// Формирует строку с символом в указаном количестве
        /// и дополняет её строкой
        /// </summary>
        /// <param name="aString">Строка в конце</param>
        /// <param name="aCharCount">Количество повторений символа aChar    </param>
        /// <param name="aChar">Повторяющийся символ</param>
        /// <returns></returns>
        public static string CwLeftPad(string aString, int aCharCount, AnsiChar aChar)
        {
            string temp = "";
            byte[] temp1 = new byte[1];
            temp1[0] = aChar.GetAnsiByte();
            for (int i = 1; i < aCharCount; i++)
            {
                temp += Encoding.ASCII.GetString(temp1);
            }

            temp += aString;
            return temp;
        }

        /// <summary>
        /// Перевод даты в Юлианском календаре в Гирогианский
        /// </summary>
        /// <param name="julianDate">размер отсчётов</param>
        /// <returns></returns>
        public static DateTime FromJulian(double julianDate)
        {
            return new DateTime(
              checked((long)((julianDate - 1721425.5) * TimeSpan.TicksPerDay)),
              DateTimeKind.Utc);
        }

        /// <summary>
        /// Выделение из числа дрорбной части
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double Frac(double val)
        {
            int full = (int)val;
            return (val - full);
        }

        public static void EncodeNoradOrb2TLE(double epoch_jd_bc, TNoradOrb ord, double bstar, int norad_number, ref string line1, ref string line2)
        {
            DateTime dt = new DateTime();
            int year;
            double day;
            string bstar_str, bstar_sign, exp_sign, ts;
            double tmp;
            int exp;
            int crc;

            dt = FromJulian(epoch_jd_bc);

            line1 = "";
            line1 += "1 ";          // Номер строки данных элемента
            line1 += String.Format("{0:00000}U", norad_number);  // Номер спутника, классификация (U = не классифицировано)
            line1 += "00";          // Международный указатель (последние две цифры года запуска)
            line1 += "000";         // Международный указатель (Стартовый номер года)
            line1 += "A   ";        // Международный указатель (Часть запуска)

            // NOAA 14
            // 1 23455U 94089A   97320.90946019  .00000140  00000-0  10191-3 0  2621
            // 2 23455  99.0090 272.6745 0008546 223.1686 136.8816 14.11711747148495

            year = dt.Year;
            year %= 100;
            line1 += String.Format("{0:00}", year);             // Эпоха года (последние две цифры года)
            line1 += String.Format("{0:000}", dt.DayOfYear);    // День эпохи

            ts = String.Format("{}", Frac(dt))
        }
    }
}