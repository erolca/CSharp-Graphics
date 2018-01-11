using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics6
{
    public partial class MainForm : Form
    {

        int x = 0;
        Timer timer;
        Ball ball;

        public MainForm(int width, int height )
        {
            Width = width;
            Height = height;
            DoubleBuffered = true;
            Paint += MainForm_Paint;
            KeyDown += MainForm_KeyDown;
            timer = new Timer();
            ball = new Ball();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (ball.isCollideWithLine(new Vector(0.0,500), new Vector(600.0,500.0)))
            {
                ball.Reflection("DIKEY");
            }
            if (ball.isCollideWithLine(new Vector(0.0, 100), new Vector(600.0, 100.0)))
            {
                ball.Reflection("DIKEY");
            }
            if (ball.isCollideWithLine(new Vector(10.0, 100), new Vector(10.0, 500.0)))
            {
                ball.Reflection("YATAY");
            }
            if (ball.isCollideWithLine(new Vector(600, 100), new Vector(600.0, 500.0)))
            {
                ball.Reflection("YATAY");
            }

            ball.Move();

            Invalidate();
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //  (new Ball()).draw(e.Graphics);
            ball.draw(e.Graphics);

            e.Graphics.DrawLine(Pens.Red, 0, 500, 600, 500);
            e.Graphics.DrawLine(Pens.Red, 0, 100, 600, 100);
            e.Graphics.DrawLine(Pens.Red, 10, 100, 10, 500);
            e.Graphics.DrawLine(Pens.Red, 600, 100, 600, 500);
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
           //if(e.KeyCode==Keys.Left)
           // {
           //     x -= 10;


           // }
           // if (e.KeyCode == Keys.Right)
           // {
           //     x += 10;

           // }
           
        }

       
    }
}
