using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionApp
{
    public class Fraction
    {
        private int numerator;
        private int denominator;


        public Fraction(int num, int denom)
        {
            this.numerator = num;
            this.denominator = denom;
        }

        public int Numerator
        {
            get
            {
                return this.numerator;
            }
            set
            {
                this.numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                this.denominator = value;
            }
        }

        public decimal ToDecimal()
        {
            return ((decimal)this.numerator / (decimal)this.denominator);
        }

        public Fraction Reduce()
        {
            for (int i = this.numerator; i > 0; i--)
            {
                if(this.denominator % i == 0 && this.numerator % i == 0)
                {
                    return new Fraction(this.numerator / i, this.denominator / i);
                }
            }

            return this;
        }

        private int FindLCD(Fraction f1, Fraction f2)
        {
            int b = Math.Max(f1.denominator, f2.denominator);

            for(int i = 1;i <= 100;i++)
            {
                if(((b* i) % f1.denominator == 0) && ((b*i) % f2.denominator == 0))
                {
                    return (b * i);
                }
            }

            return 0;
        }

        public Fraction Add(Fraction fraction)
        {
            int lcd = FindLCD(this, fraction);
            int d1 = lcd / this.denominator;
            int d2 = lcd / fraction.denominator;

            int num = ((d1 * this.numerator) + (d2 * fraction.numerator));

            return new Fraction(num, lcd);
        }

        public Fraction Multiply(Fraction fraction)
        {
            return new Fraction((this.numerator * fraction.numerator), (this.denominator * fraction.denominator));
        }

        public Fraction Divide(Fraction fraction)
        {
            return this.Multiply(fraction.Reciprocal());
        }

        public Fraction Subtract(Fraction fraction)
        {
            return this.Add(new Fraction(fraction.numerator * -1, fraction.denominator));
        }

        public Fraction Reciprocal()
        {
            return new Fraction(this.denominator, this.numerator);
        }

        public static Fraction FromDecimal(decimal dec)
        {         
            int places = GetDecimalPlaces(dec);

            if (places == 1)
                places = 2;

            int d = (int)Math.Pow(10.0, places);
            int n = (int)(d * dec);

            return new Fraction(n, d);
        }

        private static int GetDecimalPlaces(decimal n)
        {
            n = Math.Abs(n); //make sure it is positive.
            n -= (int)n;     //remove the integer part of the number.
            var decimalPlaces = 0;
            while (n > 0)
            {
                decimalPlaces++;
                n *= 10;
                n -= (int)n;
            }
            return decimalPlaces;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", numerator, denominator);
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return f1.Add(f2);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return f1.Multiply(f2);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return f1.Divide(f2);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return f1.Subtract(f2);
        }

        public static Fraction operator ++(Fraction f1)
        {
            f1.numerator++;
            return f1;
        }

        public static Fraction operator --(Fraction f1)
        {
            f1.numerator--;
            return f1;
        }

        public static Fraction operator ~(Fraction f1)
        {
            return f1.Reciprocal();
        }

        public static Fraction operator !(Fraction f1)
        {
            return f1.Reduce();
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            Fraction f1r = f1.Reduce();
            Fraction f2r = f2.Reduce();
            return (f1r.numerator == f2r.numerator && f1r.denominator == f2r.denominator);
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            Fraction f1r = f1.Reduce();
            Fraction f2r = f2.Reduce();
            return (f1r.numerator != f2r.numerator || f1r.denominator != f2r.denominator);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Fraction))
                return false;

            Fraction f = obj as Fraction;

            Fraction f1r = this.Reduce();
            Fraction f2r = f.Reduce();

            return (f1r.numerator == f2r.numerator && f1r.denominator == f2r.denominator);
        }
    }
}
