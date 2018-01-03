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

        int maxKareSayisi = 100;
        int karesayisi = 0;
        Kare karem = new Kare();
        Kare[] kareler;
      

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

            kareler = new Kare[maxKareSayisi]; // olusturulan sadece referans....
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
            if (karesayisi<= maxKareSayisi)
            {
                kareler[karesayisi] = karem;
                karesayisi++;
                          }
            else
            {
                karesayisi = 0;
            }
            Invalidate();
           
        }

        private void AnaPencerem_MouseDown(object sender, MouseEventArgs e)
        {
            karem = new Kare();// bunu eklemek zorundayız,eklemesek bütün  dizler aynı referansı gosterecek
            cizimAktifmi = true;
            karem.x = e.X;
            karem.y = e.Y;
            Invalidate();

        }

        private void AnaPencerem_MouseMove(object sender, MouseEventArgs e)
        {

            if (cizimAktifmi)
            {
                karem.width = e.X - karem.x;
                karem.height = e.Y - karem.y;
                Invalidate();
            }
        }

        private void AnaPencerem_Paint(object sender, PaintEventArgs e)
        {
            Graphics cizimAraci = e.Graphics;
            karem.Ciz(cizimAraci);


            for (int i = 0; i < maxKareSayisi; i++)
            {
                if (kareler[i]!=null)
                {
                kareler[i].Ciz(cizimAraci);
            }
                
            }


        }
    }
}
