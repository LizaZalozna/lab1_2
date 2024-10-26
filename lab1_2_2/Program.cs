using System;

namespace lab1_2_2
{
    class Program
    {
        class TETriangle
        {
            private double a_;

            public double a
            {
                get { return a_; }
                set
                {
                    if (value >= 0) a_ = value;
                    else a_ = 1;
                }
            }

            public TETriangle()
            {
                a = 3;
            }

            public TETriangle(double a)
            {
                this.a = a;
            }

            public TETriangle(TETriangle previousTETriangle)
            {
                a = previousTETriangle.a;
            }

            public override string ToString()
            {
                return $"Рівносторонній трикутник зі сторонами {a}, периметром {Perimeter()}, площею {Square()}.";
            }

            public static TETriangle Input()
            {
                Console.WriteLine("Введіть довжину сторони:");
                double a = double.Parse(Console.ReadLine());
                return new TETriangle(a);
            }

            public double Perimeter()
            {
                return 3 * a;
            }

            public double Square()
            {
                return Math.Pow(a, 2) * Math.Sqrt(3) / 4;
            }

            public static bool AreEquals(TETriangle first, TETriangle second)
            {
                if (first.a == second.a) return true;
                else return false;
            }

            public static TETriangle operator *(TETriangle triangle, double factor)
            {
                return new TETriangle(triangle.a * factor);
            }

            public static TETriangle operator *(double factor, TETriangle triangle)
            {
                return new TETriangle(factor * triangle.a);
            }
        }

        class TEPiramid : TETriangle
        {
            private double h_;
            public double h
            {
                get { return h_; }
                set
                {
                    if (value >= 0) h_ = value;
                    else h_ = 1;
                }
            }

            public TEPiramid() : base()
            {
                h = 3;
            }

            public TEPiramid(double a, double h) : base(a)
            {
                this.h = h;
            }

            public TEPiramid(TEPiramid previousTEPiramid) : base(previousTEPiramid)
            {
                h = previousTEPiramid.h;
            }

            public override string ToString()
            {
                return $"Правильна трикутна піраміда із ребрами основи {a}, висотою {h}, периметром основи {Perimeter()},\nплощею основи {Square()}, площа повної поверхні {PSquare()} і обє'мом {Volume()}.";
            }

            public static TEPiramid Input()
            {
                Console.WriteLine("Введіть довжину сторони і висоти:");
                string[] data = Console.ReadLine().Trim().Split();
                double a = double.Parse(data[0]);
                double h = double.Parse(data[1]);
                return new TEPiramid(a, h);
            }

            public static bool AreEquals(TEPiramid first, TEPiramid second)
            {
                if (first.a == second.a && first.h == second.h) return true;
                else return false;
            }

            public double Ap()
            {
                return Math.Sqrt(Math.Pow(h, 2) + Math.Pow(Math.Tan(Math.PI / 6) * a / 2, 2));
            }

            new public double Square()
            {
                return Perimeter() * Ap() / 2 + Square();
            }

            public double Volume()
            {
                return h * Square() / 3;
            }

            public static TEPiramid operator *(TEPiramid piramid, double factor)
            {
                return new TEPiramid(piramid.a * factor, piramid.h * factor);
            }

            public static TEPiramid operator *(double factor, TEPiramid piramid)
            {
                return new TEPiramid(factor * piramid.a, factor * piramid.h);
            }
        }

        public static void Main()
        {

            Console.ReadKey();
        }
    }
}