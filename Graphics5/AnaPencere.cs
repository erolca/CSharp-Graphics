using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics5
{
    class AnaPencere:Form
    {

        Homer h;
        Random rnd= new Random();

        public AnaPencere(int genislik,int yukseklik)
        {

            Width = genislik;
            Height = yukseklik;
            //resim = Image.FromFile("mc_motors.jpeg");
            DoubleBuffered = true;
            h = new Homer();


            KeyDown += AnaPencere_KeyDown;
            Paint += AnaPencere_Paint;
            


        }

        private void AnaPencere_KeyDown(object sender, KeyEventArgs e)
        {

            // Pencere = new AnaPencere(Width, Height);
            Form Pencere = sender as Form;
            

            //if (e.KeyCode == Keys.Space)
            //    MessageBox.Show("Merhaba");

            
            

            switch (e.KeyCode)
            {
                case Keys.A:      h.SolaGit(Pencere);    break;
                case Keys.D:      h.SagaGit(Pencere);    break;
                case Keys.W:      h.YukarıGit(Pencere);  break;
                case Keys.Z:      h.AsagiGit(Pencere);   break;
                case Keys.Space:  h = new Homer(){ X = rnd.Next(1, 500), Y = rnd.Next(1, 400) }; break;
            }


            Invalidate();


        }

        private void AnaPencere_Paint(object sender, PaintEventArgs e)
        {
            h.Ciz(e.Graphics);
        }
    }
}
