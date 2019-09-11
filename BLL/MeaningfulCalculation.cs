using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace BLL
{


    public static class magic
    {
        public static int minstat = 20;
        public static int maxstat = 125;
        public static int minrange = -5;
        public static int maxrange = 5;
    }
    //public class KnightBLL
    //{
    //    public int Dex { get; set; }
    //    public int Pre { get; set; }
    //    public int Str { get; set; }
    //    public int Con { get; set; }
    //    public KnightBLL Clone()
    //    {
    //        KnightBLL other = new KnightBLL()
    //        {
    //            Dex = this.Dex,
    //            Pre = this.Pre,
    //            Str = this.Str,
    //            Con = this.Con
    //        };
    //        return other;
    //    }
    //}
    public class MeaningFull
    {
       
        public KnightBLL k1 { get; set; }
        public KnightBLL k2 { get; set; }
        public KnightBLL WinnerKnight { get; set; }
        public string Result { get; set; }

        public int Winner { get; set; }

        public MeaningFull(KnightBLL KnightOne, KnightBLL KnightTwo, int seed = 0)
        {
            k1 = KnightOne;
            k2 = KnightTwo;
           
            if (seed == 0)
            {
                Rand = new Random();
            }
            else
            {
                Rand = new Random(seed);
            }
        }
        Random Rand;

        public int Roll(int low, int high)
        {
            return Rand.Next(low, high + 1);
        }

        public int Roll()
        {
            return Roll(1, 40);
        }

        int k1DexRoll;
        int k1PrecRoll;
        int k1StrRoll;
        int k1ConRoll;

        int k2DexRoll;
        int k2PrecRoll;
        int k2StrRoll;
        int k2ConRoll;

        int p1k1Dex;
        int p1k2Dex;
        int p1k1Prec;
        int p1k2Prec;

        int p2k1str;
        int p2k2str;
        //int p2checksk1tr;
        //int p2checkk2str;
        //int p2checkk1con;
        //int p2checkk2con;

        int p3;

        int checkp1(int minroll, int maxroll,
                    int minret, int maxret,
                    int value1, int value2)
        {
            int truerange = maxroll - minroll + 1;
            int actualrange = maxret - minret + 1;
            int actualvalue = value1 - value2;
            double multiplier = actualrange / ((1.0) * truerange);
            return (int)((actualvalue * multiplier) + (actualrange / 1.5));
        }

        int checkp2(int a, int b)
        {
            if (a > b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        void Phase1()
        {
            k1DexRoll = Roll();
            k1PrecRoll = Roll();
            k1StrRoll = Roll();
            k1ConRoll = Roll();

            k2DexRoll = Roll();
            k2PrecRoll = Roll();
            k2StrRoll = Roll();
            k2ConRoll = Roll();

            p1k1Dex = checkp1(magic.minstat, magic.maxstat, magic.minrange, magic.maxrange,
                k1.Dexterity + k1DexRoll, k2.Precision + k2PrecRoll);

            p1k2Dex = checkp1(magic.minstat, magic.maxstat, magic.minrange, magic.maxrange,
                k2.Dexterity + k2DexRoll, k1.Precision + k1PrecRoll);

            p1k1Prec = checkp1(magic.minstat, magic.maxstat, magic.minrange, magic.maxrange,
                k1.Precision + k1PrecRoll, k2.Dexterity + k2DexRoll);

            p1k2Prec = checkp1(magic.minstat, magic.maxstat, magic.minrange, magic.maxrange,
                k2.Precision + k2PrecRoll, k1.Dexterity + k1DexRoll);

        }

        int A;
        int B;
        int C;
        int D;

        void Phase2()
        {
            p2k1str = checkp2(A = (k1.Strength + p1k1Prec + k1StrRoll),
               D = (k2.Constitution + p1k2Dex + k2ConRoll));

            p2k2str = checkp2(B = (k2.Strength + p1k2Prec + k2StrRoll),
               C = (k1.Constitution + p1k1Dex + k1ConRoll));
        }

        int Phase3(StringBuilder sb)
        {
            switch (p2k1str + p2k2str)
            {
                case (0):
                    sb.Append(@"<p>Draw</p>");
                    return 0;
                case (1):

                    sb.Append(((p2k1str == 1) ? "K1" : "K2") + @"<p>Declared Winner</p>");
                    return 1;
                default:
                    int k1dmg = checkp1(magic.minstat, magic.maxstat, magic.minrange, magic.maxrange, A, D) - 3;
                    int k2dmg = checkp1(magic.minstat, magic.maxstat, magic.minrange, magic.maxrange, B, C) - 3;
                    k1.Constitution = k1.Constitution - k1dmg;
                    k2.Constitution = k2.Constitution - k2dmg;
                    sb.AppendFormat(@"<p>K1 takes {0} Damage, cons now {1}</p>", k1dmg, k1.Constitution);
                    sb.AppendFormat(@"<p>K2 takes {0} Damage, con now {1}</p>", k2dmg, k2.Constitution);
                    if (k1.Constitution < 0 && k2.Constitution < 0)
                    {
                        sb.Append("<p>Both Die</p>");
                        return -1;
                    }
                    else if (k1.Constitution >= 0 && k2.Constitution >= 0) return 0;
                    else if (k1.Constitution >= 0)
                    {
                        sb.Append("<p>K1 declared winner</p>");
                        WinnerKnight = k1;
                        return 1;
                    }
                    sb.Append(@"<p>K2 declared winner</p>");
                    WinnerKnight = k2;
                    return 2;
            }
        }

        int doOneJoust(StringBuilder sb)
        {
            Phase1();
            Phase2();
            return Phase3(sb);

        }

        public void Joust()
        {
            StringBuilder sb = new StringBuilder();
            int A;

            while (0 == (A = doOneJoust(sb)))
            {

            }
            this.Result = sb.ToString();
            //return sb.ToString();

        }

    }
}

