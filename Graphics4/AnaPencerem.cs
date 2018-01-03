using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Graphics2
{
    class AnaPencerem : Form
    {
        public int x=0;
        public int y = 0;
        public int height=0;
        public int width=0;

        bool cizimAktifmi = false;

        int maxSekilSayisi = 100;
        int sekilsayisi = 0;
        Kare karem = new Kare();
        Sekil[] sekiller;

        Sekil aktifSekil = null;
        Random rnd = new Random();

        public AnaPencerem(int width, int height)
        {
            DoubleBuffered = true;
            Height = height;
            Width = width;
            Text = "Ana Pencere";
            Paint += AnaPencerem_Paint;
            MouseMove += AnaPencerem_MouseMove;
            MouseDown += AnaPencerem_MouseDown;
            MouseUp += AnaPencerem_MouseUp;

            sekiller = new Sekil[maxSekilSayisi]; // olusturulan sadece referans....
            //for (int i = 0; i < maxKareSayisi; i++)
            //{
            //    kareler[i] = new Kare(); // Oulşturulan referanlar için -> nesneler olusturuluyoruz....
            //    kareler[i].x = 50 * i;
            //    kareler[i].y = 30 * i;
            //    kareler[i].width = 50 ;
            //    kareler[i].height = 50;

            //}



         


        }

        private void AnaPencerem_MouseUp(object sender, MouseEventArgs e)
        {

            cizimAktifmi = false;
            if (sekilsayisi <= maxSekilSayisi)
            {
                sekiller[sekilsayisi] = aktifSekil;
                sekilsayisi++;
                          }
            else
            {
                sekilsayisi = 0;
            }
            Invalidate();
           
        }

        private void AnaPencerem_MouseDown(object sender, MouseEventArgs e)
        {
            int sayi = rnd.Next(1, 100);

            if (sayi % 3 == 0)
            {
                aktifSekil = new Kare();
            }
            else if(sayi % 3 == 1)           
            {
                aktifSekil = new Daire();
            }
            else if (sayi % 3 == 2)
            {
                aktifSekil = new Dikdörtgen();
            }

            // karem = new Kare();// bunu eklemek zorundayız,eklemesek bütün  dizler aynı referansı gosterecek
            cizimAktifmi = true;
            aktifSekil.X = e.X;
            aktifSekil.Y = e.Y;
            Invalidate();

        }

        private void AnaPencerem_MouseMove(object sender, MouseEventArgs e)
        {

            if (cizimAktifmi)
            {
                aktifSekil.BitisAta(e.X, e.Y);
                Invalidate();
            }
        }

        private void AnaPencerem_Paint(object sender, PaintEventArgs e)
        {
            Graphics cizimAraci = e.Graphics;
           
           if  (aktifSekil!=null)
                aktifSekil.Ciz(cizimAraci);


            for (int i = 0; i < maxSekilSayisi; i++)
            {
                if (sekiller[i]!=null)
                {
                sekiller[i].Ciz(cizimAraci);
            }
                
            }


        }
    }
}
