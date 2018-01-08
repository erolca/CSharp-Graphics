using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleUygulamaları_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Kare YeniKare = new Kare();

            while (true)
            {
                Console.Clear();
                
                //YeniKare.SolaGit();
                YeniKare.ciz();
                YeniKare.SagaGit();
                Thread.Sleep(300);
            }

        }
    }
}
