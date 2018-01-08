using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUygulamaları_3
{
    class Sayi
    {
        public Sayi(Random rnd )
        {
            //Random rnd = new Random();
            mDeger = rnd.Next(1,100);
       }

        public void Ciz(int x, int y)
        {

            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 8; i++)
            {
                Console.Write("*");
            }
            Console.SetCursorPosition(x, y+1);
            Console.Write("* ");

            Console.Write("{0,-4}",mDeger);

            Console.Write(" *");

            Console.SetCursorPosition(x, y+2);
            for (int i = 0; i < 8; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();



        }


        private int mDeger;
    }
}
