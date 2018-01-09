using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_4
{
    class Kare : Sekil
    {

        //private int x;
        //private int y;
        private int genislik;
        private int yon;



        public Kare()
        {
            yon = 1;
            genislik = RastgeleUret.uret(5, 8);




        }

        public override void Animasyon()
        {
            if (x >= 80)
                yon = -1;
            else if (x == 0)
                yon = 1;

           
            if (yon == 1)
                x++;
            else
                x--;

        }

        public override void Ciz()
        {
           
            Console.SetCursorPosition(x, y);

            for (int i = 0; i < genislik; i++)
                Console.Write("*");

            Console.SetCursorPosition(x, y + genislik - 1);

            for (int i = 0; i < genislik; i++)
                Console.Write("*");

            for (int i = 0; i < genislik; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("*");
                Console.SetCursorPosition(x + genislik - 1, y + i);
                Console.Write("*");
            }

        }
    }
}
