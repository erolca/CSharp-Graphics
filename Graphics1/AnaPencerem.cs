using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Graphics
{
    class AnaPencerem:Form
    {
        public int width;
        public int height;
        public int x;
        public int y;

        public AnaPencerem(int width, int height)
        {
            DoubleBuffered = true;
            Height = height;
            Width = width;
            Text = "Ana Pencere";
            Paint += AnaPencerem_Paint;
            MouseMove += AnaPencerem_MouseMove;
            MouseDown += AnaPencerem_MouseDown;
        }

        private void AnaPencerem_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y ;
            Invalidate();

        }

        private void AnaPencerem_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "X : " + e.X +" "+ " Y: " + e.Y;
            width = e.X - x;
            height = e.Y - y;
            Invalidate();

        }

        private void AnaPencerem_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics cizimaraci = e.Graphics;

            cizimaraci.DrawRectangle(Pens.Blue,x,y,width,height);

            //

            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();

            Pen myPen = new Pen(System.Drawing.Color.Red, 5);
            Rectangle myRectangle = new Rectangle(20, 20, 250, 200);
           
            graphicsObj.DrawRectangle(myPen, myRectangle);

            myPen = new Pen(System.Drawing.Color.Green, 5);
            myRectangle = new Rectangle(20, 20, 250, 200);
            graphicsObj.DrawEllipse(myPen, myRectangle);

        }
    }
}
