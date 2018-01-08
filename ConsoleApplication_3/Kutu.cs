using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUygulamaları_3
{
    class Kutu
    {


        public Kutu(int elemanSayisi)
        {
           mSayılar = new Sayi[elemanSayisi];
            mEklenensayi = 0;
            mrnd = new Random();
        }


        public void Ekle()
        {
            if (mEklenensayi<mSayılar.Length)
            {

                mSayılar[mEklenensayi] = new Sayi(mrnd);
                mEklenensayi++;
            }

        }

        public void Cikar()
        {

            if (mEklenensayi>0)
            {
                mSayılar[mEklenensayi-1] = null;
                mEklenensayi--;

            }

        }

        public void ciz(int x, int y)
        {
            //int x = 20;
            //int y = 10;
            int artis = 10;
            int genislik = artis * mEklenensayi + 2;
            Console.SetCursorPosition(x - 2, y - 2);

            for (int i = 0; i < genislik; i++)
            {
                Console.Write("*");
            }


            for (int i = 0; i < mEklenensayi; i++)
            {
                mSayılar[i].Ciz(x+i*artis,y);

            }

            //sol duvar
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(x - 2, y -2+i);
                Console.Write("*");
                Console.SetCursorPosition(x - 3+genislik, y - 2 + i);
                Console.Write("*");
            }


            //taban
            Console.SetCursorPosition(x - 2, y+4);

            for (int i = 0; i < genislik; i++)
            { 
                Console.Write("*");
            }

        }

        private Sayi[] mSayılar;

        private int mEklenensayi;
        private Random mrnd;


    }
}
