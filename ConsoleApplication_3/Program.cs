using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUygulamaları_3
{
   
    class Program
    {
     
        static void Main(string[] args)
        {

            //Sayi yeniSayi = new Sayi();
           

            //oluşturulan ->null içerikli refreans
            Sayi[] sayi = new Sayi[10];
            Random crnd = new Random();
              
            //nesne oluşturuyor
            for (int i = 0; i < 10; i++)
            {
                sayi[i] = new Sayi(crnd);
            }


            Kutu kutu = new Kutu(10);
            while (true)
            {

                //public static bool CursorVisible { get; set; }
                Console.CursorVisible = true; // Initialize the cursor to visible.
                Console.Clear();
                kutu.ciz(10,10);
                var tus = Console.ReadKey();

                if (tus.KeyChar == 'e' || tus.KeyChar == 'E')
                    kutu.Ekle();
                if (tus.KeyChar == 'c' || tus.KeyChar == 'C')
                    kutu.Cikar();
                if (tus.KeyChar == 'q' || tus.KeyChar == 'Q')
                    break;



            }

        }
    }
}
