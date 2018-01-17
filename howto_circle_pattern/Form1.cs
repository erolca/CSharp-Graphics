using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace howto_circle_pattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picCanvas.Image = DrawPattern(
                picCanvas.ClientSize.Width,
                picCanvas.ClientSize.Height);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            picCanvas.Image = DrawPattern(
                picCanvas.ClientSize.Width,
                picCanvas.ClientSize.Height);
        }

        // Draw the pattern.
        private Bitmap DrawPattern(int wid, int hgt)
        {
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                float margin = 10;
                float diameter1 = (hgt - margin) / 5f;
                float diameter2 = (wid - margin) / (float)(1 + 2 * Math.Sqrt(3));
                float diameter = Math.Min(diameter1, diameter2);

                float radius = diameter / 2f;
                float cx = wid / 2f;
                float cy = hgt / 2f;

                // Find the center circle's center.
                List<PointF> centers = new List<PointF>();
                centers.Add(new PointF(cx, cy));

                // Add the other circles.
                for (int ring_num = 0; ring_num < 2; ring_num++)
                {
                    float ring_radius = diameter * (ring_num + 1);
                    double theta = Math.PI / 2.0;
                    double dtheta = Math.PI / 3.0;
                    for (int i = 0; i < 6; i++)
                    {
                        double x = cx + ring_radius * Math.Cos(theta);
                        double y = cy + ring_radius * Math.Sin(theta);
                        centers.Add(new PointF((float)x, (float)y));
                        theta += dtheta;
                    }
                }

                // Fill and outline the circles.
                foreach (PointF center in centers)
                {
                    float x = center.X - radius;
                    float y = center.Y - radius;
                    gr.FillEllipse(Brushes.LightBlue, x, y, diameter, diameter);
                    gr.DrawEllipse(Pens.Blue, x, y, diameter, diameter);
                }

                // Connect the circle centers.
                int num_circles = centers.Count;
                for (int i = 0; i < num_circles; i++)
                {
                    for (int j = i + 1; j < num_circles; j++)
                    {
                        gr.DrawLine(Pens.Blue, centers[i], centers[j]);
                    }
               }
            }

            return bm;
        }
    }
}
