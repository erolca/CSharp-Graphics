using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUygulamaları_2
{
    class Rastgele
    {
        static Random rnd = null;

        public  static int uret(int min, int max)
        {
            if (rnd == null)
                rnd = new Random();

            return rnd.Next(min,max);
        }

    }
}
