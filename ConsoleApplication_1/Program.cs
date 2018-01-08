using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUygulamaları
{
    class Program
    {
        static void Main(string[] args)
        {

            Kare yenikare = new Kare(10);
            yenikare.RenkAta(ConsoleColor.DarkGreen);
           // yenikare.BoyutAta(5);
            yenikare.ciz();

        }
    }
}
