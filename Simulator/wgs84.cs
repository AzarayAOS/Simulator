using System;

namespace Simulator
{
    internal static class wgs84
    {
        private const bool Wgs_84 = true;
        private const double a84 = 6378.137;            //экваториальный радиус -большая п/ось WGS-84
        private const double b84 = 6356.752315245;      //полярный радиус -малая п/ось WGS-84
        private const double ab84 = 1 / 298.257223563;  //0.0033523298693{1/298.3}; {(a-b)/a Сжатие в WGS-84}
        private const double ee84 = 1 - 0.0033523298693 * 0.0033523298693;// Квадрат эксцентриситета = 1-sqr(b/a)
                                                                          // Внимание!! геодезические широта и долгота в градусах !!!!!


        private const double rg = 57.2957795130;        // коэффициент в радианах

        private static readonly double r3 = 6371.11;

        /// <summary>
        /// Перевод из системы WGS-84 в декартову систему координат. 
        /// Возвращаемые знгачения через переменные X, Y, Z
        /// </summary>
        /// <param name="Hw"></param>
        /// <param name="Fwg"></param>
        /// <param name="Lwg"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        private static void wgs84_XYZ(double Hw, double Fwg, double Lwg, ref double X, ref double Y, ref double Z)
        {
            double N;
            double cf, sf, cl, sl;

            sf = Math.Sin(Fwg / rg);
            cf = Math.Cos(Fwg / rg);

            sl = Math.Sin(Lwg / rg);
            cl = Math.Cos(Lwg / rg);

            N = a84 / Math.Sqrt(1 - ee84 * Math.Pow(sf, 2));

            Z = (N * (1 - ee84) + Hw) * sf;
            X = (N + Hw) * cf * cl;
            Y = (N + Hw) * cf * sl;

        }

        /// <summary>
        /// Перевод из системы WGS-84 в геоцентр. СК
        /// </summary>
        /// <param name="Hz"></param>
        /// <param name="Fzg"></param>
        /// <param name="R"></param>
        /// <param name="F"></param>
        private static void wgs84_Rf(double Hz, double Fzg, ref double R, ref double F)
        {
            double N;
            double cf, sf;
            double Z;


            if (Wgs_84)
            {
                sf = Math.Sin(Fzg / rg);
                cf = Math.Cos(Fzg / rg);

                N = a84 / Math.Sqrt(1 - ee84 * Math.Pow(sf, 2));

                Z = (N * (1 - ee84) + Hz) * sf;
                R = Math.Sqrt(Math.Pow((N + Hz), 2) + Math.Pow(Z, 2));
                F = Math.Asin(Z / R);

            }
            else
            {
                R = r3 + Hz;
                F = Fzg / rg;
            }

        }

        /// <summary>
        /// Перевод из геоцентр. СК в WGS-84
        /// </summary>
        /// <param name="r"></param>
        /// <param name="f"></param>
        /// <param name="Hz"></param>
        /// <param name="Fzg"></param>
        private static void RF_wgs84(double r, double f, ref double Hz, ref double Fzg)
        {
            double sf, cf, N, Z;
            double rw, fw;
            int ni;

            if (r == 0)
            {
                Hz = 0;
                Fzg = 0;
                return;
            }

            Hz = r - r3;
            Fzg = f;


            ni = 0;

            do
            {
                if (!Wgs_84)
                {
                    break;
                }

                sf = Math.Sin(Fzg / rg);
                cf = Math.Cos(Fzg / rg);

                N = a84 / Math.Sqrt(1 - ee84 * Math.Pow(sf, 2));
                Z = (N * (1 - ee84) + Hz) * sf;

                rw = Math.Sqrt(Math.Pow((N + Hz) * cf, 2) + Math.Pow(Z, 2));
                fw = Math.Asin(Z / rw);

                Hz = Hz - (rw - r);
                Fzg = Fzg - (fw - f);
                ni++;


            } while (Math.Abs(rw - r) < 1e-8);

            Fzg = Fzg * rg;

        }

        /// <summary>
        /// Перевод из XYZ в WGS-84
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="Hw"></param>
        /// <param name="Fwg"></param>
        /// <param name="Lwg"></param>
        private static void XYZ_wgs84(double X, double Y, double Z, ref double Hw, ref double Fwg, ref double Lwg)
        {
            double p, ro, s, u, v;
            double f, e2, ep2, r2, r, ee2, ff, g, c, q, tmp, zo;
            double sqrZ = Math.Pow(Z, 2);
            f = 1 - b84 / a84;

            e2 = 2 * f - Math.Pow(f, 2);                // первый эксцентриситет в квадрате
            ep2 = f * (2 - f) / (Math.Pow(1 - f, 2));   // второй эксцентриситет в квадрате

            r2 = Math.Pow(X, 2) + Math.Pow(Y, 2);
            r = Math.Sqrt(r2);
            ee2 = Math.Pow(a84, 2) + Math.Pow(b84, 2);
            ff = 54 * Math.Pow(b84, 2) * sqrZ;

            g = r2 + (1 - e2) * sqrZ - e2 * ee2;
            c = (e2 * e2 * ff * r2) / (Math.Pow(g, 3));
            s = Math.Pow(1 + c + Math.Sqrt(c * c + 2 * c), 1 / 3);
            p = ff / (3 * Math.Pow(s + 1 / s + 1, 2) * g * g);
            q = Math.Sqrt(1 + 2 * e2 * e2 * p);

            ro = -(e2 * p * r) / (1 + q) + Math.Sqrt((a84 * a84 / 2) *
                (1 + 1 / q) - ((1 - e2) * p * sqrZ) /
                (q * (1 + q)) - p * r2 / 2);

            tmp = Math.Pow(r - e2 * ro, 2);
            u = Math.Sqrt(tmp + sqrZ);
            v = Math.Sqrt(tmp + (1 - e2) * sqrZ);
            zo = (Math.Pow(b84, 2) * Z) / (a84 * v);

            Hw = u * (1 - Math.Pow(b84, 2) / (a84 * v)) * 1000;
            Fwg = Math.Atan((Z + ep2 * zo) / r) * 180 / Math.PI;
            Lwg = Math.Atan2(Y, X) * 180 / Math.PI;


        }

    }
}
