using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_4
{
    class Cizgi : Sekil
    {

        private int x;
        private int y;
        private int uzunluk;
        private int yon;

        public Cizgi()
        {
            yon = 1;
            x = RastgeleUret.uret(1, 20);
            y = RastgeleUret.uret(10, 10);
            uzunluk = RastgeleUret.uret(10, 15);

        }


        public void Animasyon()
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

        public void Ciz()
        {
            Console.SetCursorPosition(x,y);
            for(int i=0;i<uzunluk;i++)
            {

                Console.Write("*");

            }
        }
    }
}
