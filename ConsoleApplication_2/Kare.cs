using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUygulamaları_2
{
    class Kare
    {
        public Kare(/*int boyut*/)
        {
            // this.boyut = boyut;
            this.boyut = Rastgele.uret(3, 8);
            renk = (ConsoleColor)Rastgele.uret(1, 15);
            x = Rastgele.uret(1, 40);
            y = Rastgele.uret(1, 10);

        }

        public void ciz()
        {
            ConsoleColor OncekiRenk = Console.ForegroundColor;
            Console.ForegroundColor = renk; // ConsoleColor.Blue;

            Console.SetCursorPosition(x, y);

            for (int i = 0; i < boyut; i++)
                Console.Write("*");

            Console.SetCursorPosition(x, y + boyut - 1);

            for (int i = 0; i < boyut; i++)
                Console.Write("*");

            for (int i = 0; i < boyut; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("*");
                Console.SetCursorPosition(x + boyut - 1, y + i);
                Console.Write("*");
            }
            Console.ForegroundColor = OncekiRenk;
        }

        public bool SagSinir(int sagsinir)
        {

            return false;   
        }

        public void SolaGit()
        {
            x -= 1;

        }

        public void SagaGit()
        {

            x += 1;

        }



        public void BoyutAta(int boyut)
        {
            this.boyut = boyut;
        }

        public void RenkAta(ConsoleColor renk)
        {
            this.renk = renk;
        }

        private ConsoleColor renk;
        private int x;
        private int y;
        private int boyut;
    }
}
