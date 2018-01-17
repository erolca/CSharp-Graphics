using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace howto_find_circle_intersection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The circles.
        List<PointF> Centers = new List<PointF>();
        List<float> Radii = new List<float>();

        // The index of a new circle we are drawing.
        int NewCircle = -1;

        // Remove all circles.
        private void btnClear_Click(object sender, EventArgs e)
        {
            Centers = new List<PointF>();
            Radii = new List<float>();
            this.Invalidate();
        }

        // Draw the circles.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Find the intersection of all circles.
            Region intersection = FindCircleIntersections(Centers, Radii);

            // Draw the region.
            if (intersection != null)
            {
                e.Graphics.FillRegion(Brushes.LightGreen, intersection);
            }

            // Draw the circles.
            for (int i = 0; i < Centers.Count; i++)
            {
                e.Graphics.DrawEllipse(Pens.Blue,
                    Centers[i].X - Radii[i], Centers[i].Y - Radii[i],
                    2 * Radii[i], 2 * Radii[i]);
            }
        }

        // Start drawing a new circle.
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Centers.Add(e.Location);
            Radii.Add(0);
            NewCircle = Centers.Count - 1;
        }

        // Update the new circle.
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewCircle < 0) return;
            float dx = e.X - Centers[NewCircle].X;
            float dy = e.Y - Centers[NewCircle].Y;
            Radii[NewCircle] = (float)Math.Sqrt(dx * dx + dy * dy);
            this.Invalidate();
        }

        // Finish drawing a new circle.
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // If the radius is 0, remove the new circle.
            if (Radii[NewCircle] < 1)
            {
                Centers.RemoveAt(NewCircle);
                Radii.RemoveAt(NewCircle);
            }

            NewCircle = -1;
            this.Invalidate();
        }

        // Find the intersection of all of the circles.
        private Region FindCircleIntersections(List<PointF>centers, List<float>radii)
        {
            if (centers.Count < 1) return null;

            // Make a region.
            Region result_region = new Region();
            
            // Intersect the region with the circles.
            for (int i = 0; i < centers.Count; i++)
            {
                using (GraphicsPath circle_path = new GraphicsPath())
                {
                    circle_path.AddEllipse(
                        centers[i].X - radii[i], centers[i].Y - radii[i],
                        2 * radii[i], 2 * radii[i]);
                    result_region.Intersect(circle_path);
                }
            }

            return result_region;
        }
    }
}
