using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DrawCurve
{
    public partial class Form1 : Form
    {
        private List<Point> Points = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            MouseClick += Form1_MouseClick;
            Paint += Form1_Paint;

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Points.Add(e.Location);
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the points.
            foreach (Point point in Points)
                e.Graphics.FillEllipse(Brushes.Black,
                    point.X - 3, point.Y - 3, 5, 5);
            if (Points.Count < 2) return;

            // Draw the curve.
            e.Graphics.DrawCurve(Pens.Red, Points.ToArray());
        }

       
        // Start a new point list.
        private void mnuCurveNew_Click(object sender, EventArgs e)
        {
            Points = new List<Point>();
            Refresh();
        }

        
    }
}
