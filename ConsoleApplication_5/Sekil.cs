using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_4
{
    abstract class Sekil
    {
        protected int x;
        protected int y;
        public Sekil()
        {

            x = RastgeleUret.uret(10, 20);
            y = RastgeleUret.uret(10, 10);


        }


        public abstract void Animasyon();
       public abstract void Ciz();
    }
}
