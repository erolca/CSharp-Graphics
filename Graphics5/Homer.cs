using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics5
{
    class Homer
    {
        Image resim;
        int x;
        int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Homer()
        {
            resim = Image.FromFile("mc_motors.jpeg");

        }

        public void SolaGit(Form Pencere)
        {
            X -= 10;
            if (X <= 0)
                X = 0;
        }

        public void SagaGit(Form Pencere)
        {
            X += 10;
            if (X > Pencere.Width)
                X = Pencere.Width;
                
        }

        public void YukarıGit(Form Pencere)
        {
            Y -= 10;
            if (Y <= 0)
                Y = 0;
        }

        public void AsagiGit(Form Pencere)
        {
            Y += 10;
            if (Y > Pencere.Height)
                Y = Pencere.Width;
        }





        public void Ciz(Graphics g)
        {

            g.DrawImage(resim, X, Y, 128, 128);
           

        }


    }
}
