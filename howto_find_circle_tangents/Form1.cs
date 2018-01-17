using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace howto_find_circle_tangents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The last point clicked.
        PointF PointClicked = new PointF(-1, -1);

        // Redraw on resize.
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Draw the circle, point, and tangent lines.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the circle.
            float radius = Math.Min(
                this.ClientSize.Width / 6f,
                this.ClientSize.Height / 6f);
            float cx = this.ClientSize.Width - radius - 20;
            float cy = this.ClientSize.Height - radius - 20;
            e.Graphics.FillEllipse(Brushes.LightBlue,
                cx - radius, cy - radius,
                2 * radius, 2 * radius);
            e.Graphics.DrawEllipse(Pens.Blue,
                cx - radius, cy - radius,
                2 * radius, 2 * radius);

            if (PointClicked.X < 0) return;

            // Find the tangents.
            PointF pt1, pt2;
            if (FindTangents(new PointF(cx, cy), radius,PointClicked,
                out pt1, out pt2))
            {
                e.Graphics.DrawLine(Pens.Green, PointClicked, pt1);
                e.Graphics.DrawLine(Pens.Green, PointClicked, pt2);
            }


            // Draw the point.
            e.Graphics.FillEllipse(Brushes.Pink,
                PointClicked.X - 3, PointClicked.Y - 3,
                7, 7);
            e.Graphics.DrawEllipse(Pens.Red,
                PointClicked.X - 3, PointClicked.Y - 3,
                7, 7);
        }

        // Save the clicked point.
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Save the point.
            PointClicked = new PointF(e.X, e.Y);

            // Redraw.
            this.Invalidate();
        }

        // Find the tangent points for this circle and external point.
        // Return true if we find the tangents, false if the point is
        // inside the circle.
        private bool FindTangents(PointF center, float radius,
            PointF external_point, out PointF pt1, out PointF pt2)
        {
            // Find the distance squared from the
            // external point to the circle's center.
            double dx = center.X - external_point.X;
            double dy = center.Y - external_point.Y;
            double D_squared = dx * dx + dy * dy;
            if (D_squared < radius * radius)
            {
                pt1 = new PointF(-1, -1);
                pt2 = new PointF(-1, -1);
                return false;
            }

            // Find the distance from the external point
            // to the tangent points.
            double L = Math.Sqrt(D_squared - radius * radius);

            // Find the points of intersection between
            // the original circle and the circle with
            // center external_point and radius dist.
            FindCircleCircleIntersections(
                center.X, center.Y, radius,
                external_point.X, external_point.Y, (float)L,
                out pt1, out pt2);

            return true;
        }

        // Find the points where the two circles intersect.
        private int FindCircleCircleIntersections(
            float cx0, float cy0, float radius0,
            float cx1, float cy1, float radius1,
            out PointF intersection1, out PointF intersection2)
        {
            // Find the distance between the centers.
            float dx = cx0 - cx1;
            float dy = cy0 - cy1;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if (dist < Math.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if ((dist == 0) && (radius0 == radius1))
            {
                // No solutions, the circles coincide.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else
            {
                // Find a and h.
                double a = (radius0 * radius0 -
                    radius1 * radius1 + dist * dist) / (2 * dist);
                double h = Math.Sqrt(radius0 * radius0 - a * a);

                // Find P2.
                double cx2 = cx0 + a * (cx1 - cx0) / dist;
                double cy2 = cy0 + a * (cy1 - cy0) / dist;

                // Get the points P3.
                intersection1 = new PointF(
                    (float)(cx2 + h * (cy1 - cy0) / dist),
                    (float)(cy2 - h * (cx1 - cx0) / dist));
                intersection2 = new PointF(
                    (float)(cx2 - h * (cy1 - cy0) / dist),
                    (float)(cy2 + h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
            }
        }
    }
}
