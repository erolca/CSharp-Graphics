using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics6
{
    class Math2D
    {
        public static double dotProduct(Vector v1, Vector v2)
        {
            Vector v3 = v1.normalize();
            Vector v4 = v2.normalize();

            return v3.x * v4.x + v3.y * v4.y;


        }
    }
}
