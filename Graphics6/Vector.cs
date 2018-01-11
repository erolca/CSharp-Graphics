using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics6
{
    class Vector
    {
        public Vector(double v)
        {
        }
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector normalize()
        {
            double length = Math.Sqrt(x * x + y * y);

            return new Vector(x / length, y / length);
        }

        public double length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector operator *(Vector v1, float sayi)
        {
            return new Vector(v1.x * sayi, v1.y * sayi);
        }

        public static Vector operator /(Vector v1, float sayi)
        {
            return new Vector(v1.x / sayi, v1.y / sayi);
        }



        public double x;
        public double y;

    }
}
