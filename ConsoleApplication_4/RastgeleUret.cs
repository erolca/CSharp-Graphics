using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication_4
{
    class RastgeleUret
    {
        static Random rnd = null;

        public static int uret(int min, int max)
        {
            if (rnd == null)
                rnd = new Random();

            return rnd.Next(min, max);
        }

    }
}
