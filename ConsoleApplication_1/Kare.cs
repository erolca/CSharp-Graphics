using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUygulamaları
{
    class Kare
    {
        public Kare(int boyut)
        {
            this.boyut = boyut;
        }

        public void ciz()
        {
            ConsoleColor OncekiRenk = Console.ForegroundColor;
            Console.ForegroundColor = renk; // ConsoleColor.Blue;

            for (int i=0; i < boyut; i++)
                Console.WriteLine("*");
            Console.SetCursorPosition(0, boyut-1);
            for (int i = 0; i < boyut; i++)
                Console.Write("*");

            for (int i=0;i<boyut;i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("*");
                Console.SetCursorPosition(boyut-1, i);
                Console.Write("*"); 
            }
            Console.ForegroundColor = OncekiRenk;
        }


        public void BoyutAta(int boyut)
        {
            this.boyut = boyut;
        }

        public void RenkAta(ConsoleColor renk)
        {
            this.renk = renk;
        }

        private   ConsoleColor renk;
        private int boyut;
    }
}
