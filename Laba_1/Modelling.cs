using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    class Modelling
    {
        public int Length;
        public double[] R_i = null;
        public double[] Z_i = null;
        public double[] T_k = null;

        public double Lambda;
        double studentNumber = 8;

        public int[] XCoord = null;



        public int[] N = null;
        public int[] MinMax = null;


        public double[] Pi = null;
        public double[] NotPi = null;
        public Modelling(int length, Random rnd)
        {
            Length = length;

            R_i = GetRnd(rnd);
            Z_i = new double[Length];
            T_k = new double[Length];
            Lambda = GetLambda(10);
        }

        public double[] GetRnd(Random rnd)
        {
            double[] tmp = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                tmp[i] = rnd.NextDouble();
            }
            return tmp;
        }

        public double GetLambda(double lambdaNumber)
        {
            return lambdaNumber * (studentNumber + 1) / (studentNumber + 4);
        }
        public double[] GetInterval(double lambda, double[] rndNum)
        {
            double[] tmp = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                tmp[i] = (-1 / lambda * Math.Log(rndNum[i]));
            }
            return tmp;
        }

        public double[] GetMometns(double[] Z)
        {
            double[] tmp = new double[Length];
            double min = 0;

            for (int i = 0; i < Length; i++)
            {
                tmp[i] = 0;
                for (int j = 0; j <= i; j++)
                {
                    tmp[i] += Z[j];
                }
                tmp[i] += min;
            }
            return tmp;
        }


        public int[] GetXCoord(double[] T)
        {
            int max = (int)Math.Ceiling(T[T.Length - 1]);
            int a = 0, b = 1;
            int[] tmp = new int[max];

            for (int i = 0; i < max; i++)
            {
                tmp[i] = 0;
                for (int j = 0; j < Length; j++)
                {
                    if (T[j] >= a && T[j] < b)
                    {
                        tmp[i]++;
                    }
                }
                a = b;
                b++;
            }

            return tmp;
        }


        public void CallNumber(int[] Coord)
        {
            var max = Coord.Max();
            var n = new int[max];
            double[] tmpPI = new double[max];
            NotPi = new double[max];
            var minMax = new int[max];
            for (var i = 0; i < max; i++)
            {
                n[i] = 0;
                for (var j = 0; j < Coord.Length; j++)
                {
                    if (i == Coord[j])
                    {
                        n[i]++;
                    }
                }
                minMax[i] = i;
            }
            N = n;
            MinMax = minMax;

            for (var i = 0; i < max; i++)
            {
                tmpPI[i] = (Math.Pow(Lambda, i) / factorial(i)) * Math.Exp(-Lambda);
            }
            Pi = tmpPI;

            double summ = 0;
            for (int i = 0; i < N.Length; i++)
            {
                summ += N[i];
            }

            for (int i = 0; i < N.Length; i++)
            {
                NotPi[i] = N[i] / summ;
            }
        }
        int factorial(int numb)
        {
            int result = 1;
            for (int i = numb; i > 1; i--)
            {
                result *= i;
            }
            return result;
        }
    }
}
