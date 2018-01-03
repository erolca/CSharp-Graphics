using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics2
{
    class AnaPencerem : Form
    {

        public int x;
        public int y = 100;
        public int height;
        public int width;

        bool cizimAktifmi = false;

        Kare karem = new Kare();

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



            karem.width = 100;
            karem.height = 100;


        }

        private void AnaPencerem_MouseUp(object sender, MouseEventArgs e)
        {
            cizimAktifmi = false;
        }

        private void AnaPencerem_MouseDown(object sender, MouseEventArgs e)
        {
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

        }
    }
}
