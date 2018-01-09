using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_4
{
    class Ucgen:Sekil
    {




        //private int x;
        //private int y;
        private int boyut;
        private int yonX = 1;
        private int yonY = -1;


        public Ucgen()
        {

            //x = RastgeleUret.uret(1, 20);
            //y = RastgeleUret.uret(1,10);
            boyut = RastgeleUret.uret(2,8);




        }

        public override  void Animasyon()
        {
            if (x >= 60)
                yonX = -1;
            else if (x == 10)
                yonX = 1;

            if (y >= 20)
                yonY = -1;
            else if (y == 00)
                yonY = 1;


            if (yonX == -1)
                x--;
            else
                x++;

            if (yonY == 1)
                y++;
            else
                y--;


        }

        public override void Ciz()
        {
            for (int i = 0;i<boyut;i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write("*");
                Console.SetCursorPosition(x + i, y+i);
                Console.Write("*");
                Console.SetCursorPosition(x + boyut-1, y+i);
                Console.Write("*");



            }
        }
    }
}
