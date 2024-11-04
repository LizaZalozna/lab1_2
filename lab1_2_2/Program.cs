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

            public TETriangle(TETriangle previous)
            {
                a = previous.a;
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

        class TETriangleF : TETriangle
        {
            public TETriangleF() : base() { }

            public TETriangleF(double a) : base(a) { }

            public TETriangleF(TETriangleF previous) : base(previous) { }

            public override bool Equals(object obj)
            {
                if (obj is TETriangleF other)
                {
                    return this.a == other.a;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return 3 * a.GetHashCode();
            }
        }

        class TEPiramid : TETriangleF
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

            public TEPiramid(TEPiramid previous) : base(previous)
            {
                h = previous.h;
            }

            public override string ToString()
            {
                return $"Правильна трикутна піраміда із ребрами основи {a}, висотою {h}, периметром основи {Perimeter()},\nплощею основи {base.Square()}, площа повної поверхні {Square()} і обє'мом {Volume()}.";
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

        class TEPiramidF : TEPiramid
        {
            public TEPiramidF() : base() { }

            public TEPiramidF(double a, double h) : base(a,h) { }

            public TEPiramidF(TEPiramidF previous) : base(previous) { }

            public override bool Equals(object obj)
            {
                if (obj is TEPiramidF other)
                {
                    return this.a == other.a && this.h == other.h;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return a.GetHashCode() * 3 + h.GetHashCode() * 2 ;
            }
        }
    

        public static void Main()
        {
            HashSet<TETriangle> teTriangles = new HashSet<TETriangle>();
            TETriangle first = new TETriangle(5);
            teTriangles.Add(first);
            TETriangle second = new TETriangle(5);
            Console.WriteLine(teTriangles.Contains(second));

            HashSet<TETriangleF> teTrianglesF = new HashSet<TETriangleF>();
            TETriangleF firstF = new TETriangleF(5);
            teTrianglesF.Add(firstF);
            TETriangleF secondF = new TETriangleF(5);
            Console.WriteLine(teTrianglesF.Contains(secondF));

            HashSet<TEPiramid> tePiramids = new HashSet<TEPiramid>();
            tePiramids.Add(new TEPiramid(2, 4));
            tePiramids.Add(new TEPiramid(2, 1));
            tePiramids.Add(new TEPiramid(2, 6));
            tePiramids.Add(new TEPiramid(2, 3));
            tePiramids.Add(new TEPiramid(2, 10));
            Console.WriteLine(tePiramids.Count());

            HashSet<TEPiramidF> tePiramidsF = new HashSet<TEPiramidF>();
            tePiramidsF.Add(new TEPiramidF(2, 4));
            tePiramidsF.Add(new TEPiramidF(2, 1));
            tePiramidsF.Add(new TEPiramidF(2, 6));
            tePiramidsF.Add(new TEPiramidF(2, 3));
            tePiramidsF.Add(new TEPiramidF(2, 10));
            Console.WriteLine(tePiramidsF.Count());
            Console.ReadKey();
        }
    }
}