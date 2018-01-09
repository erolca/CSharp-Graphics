using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_4
{
    class Program
    {
        static void Main(string[] args)
        {

            CizimMotoru motor = new CizimMotoru();
            Kare k1 = new Kare();
            motor.SekilEkle(k1);
  
           motor.SekilEkle(new Ucgen());
            motor.SekilEkle(new Cizgi());


            motor.Ciz();


        }
    }
}
