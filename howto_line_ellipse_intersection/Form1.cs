using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace howto_line_ellipse_intersection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Point LinePt1, LinePt2;

        // Start with a default ellipse and line.
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            LinePt1 = new Point(20, 30);
            LinePt2 = new Point(170, 100);
            EllipsePt1 = new Point(20, 30);
            EllipsePt2 = new Point(ClientSize.Width - 40, ClientSize.Height - 60);
        }

        // Draw the current ellipse and line.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the ellipse.
            using (Pen ellipse_pen = new Pen(Color.Blue))
            {
                // If we're selecting it now,
                // draw it with a dashed line.
                if (SelectingEllipse)
                    ellipse_pen.DashPattern = new float[] { 5, 5 };
                Rectangle ellipse_rect = new Rectangle(
                    EllipsePt1.X, EllipsePt1.Y,
                    EllipsePt2.X - EllipsePt1.X,
                    EllipsePt2.Y - EllipsePt1.Y);
                e.Graphics.DrawEllipse(ellipse_pen, ellipse_rect);
            }

            // Draw the line segment.
            using (Pen line_pen = new Pen(Color.Green))
            {
                // If we're selecting it now,
                // draw it with a dashed line.
                if (SelectingLine)
                    line_pen.DashPattern = new float[] { 5, 5 };
                e.Graphics.DrawLine(line_pen, LinePt1, LinePt2);
            }

            // If we are not selecting anything,
            // draw the points of intersection.
            if (!SelectingEllipse && !SelectingLine)
            {
                Rectangle ellipse_rect = new Rectangle(
                    EllipsePt1.X, EllipsePt1.Y,
                    EllipsePt2.X - EllipsePt1.X,
                    EllipsePt2.Y - EllipsePt1.Y);
                PointF[] points = FindEllipseSegmentIntersections(
                    ellipse_rect, LinePt1, LinePt2,
                    chkSegmentOnly.Checked);
                foreach (PointF pt in points)
                {
                    e.Graphics.DrawEllipse(Pens.Red, pt.X - 3, pt.Y - 3, 6, 6);
                }
            }
        }

        // Let the user select a line.
        private bool SelectingLine = false;
        private void btnSelectLine_Click(object sender, EventArgs e)
        {
            btnSelectLine.Enabled = false;
            btnSelectEllipse.Enabled = false;
            this.MouseDown += SelectLine_MouseDown;
            this.Cursor = Cursors.Cross;
        }
        private void SelectLine_MouseDown(object sender, MouseEventArgs e)
        {
            SelectingLine = true;
            this.MouseDown -= SelectLine_MouseDown;
            this.MouseMove += SelectLine_MouseMove;
            this.MouseUp += SelectLine_MouseUp;

            LinePt1 = e.Location;
            LinePt2 = e.Location;
        }
        private void SelectLine_MouseMove(object sender, MouseEventArgs e)
        {
            LinePt2 = e.Location;
            Refresh();
        }
        private void SelectLine_MouseUp(object sender, MouseEventArgs e)
        {
            SelectingLine = false;
            this.MouseMove -= SelectLine_MouseMove;
            this.MouseUp -= SelectLine_MouseUp;
            this.Cursor = Cursors.Default;
            btnSelectLine.Enabled = true;
            btnSelectEllipse.Enabled = true;
            Refresh();
        }

        // Let the user select an ellipse.
        private bool SelectingEllipse = false;
        private Point EllipsePt1, EllipsePt2;
        private void btnSelectEllipse_Click(object sender, EventArgs e)
        {
            btnSelectLine.Enabled = false;
            btnSelectEllipse.Enabled = false;
            this.MouseDown += SelectEllipse_MouseDown;
            this.Cursor = Cursors.Cross;
        }
        private void SelectEllipse_MouseDown(object sender, MouseEventArgs e)
        {
            SelectingEllipse = true;
            this.MouseDown -= SelectEllipse_MouseDown;
            this.MouseMove += SelectEllipse_MouseMove;
            this.MouseUp += SelectEllipse_MouseUp;

            EllipsePt1 = e.Location;
            EllipsePt2 = e.Location;
        }
        private void SelectEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            EllipsePt2 = e.Location;
            Refresh();
        }
        private void SelectEllipse_MouseUp(object sender, MouseEventArgs e)
        {
            SelectingEllipse = false;
            this.MouseMove -= SelectEllipse_MouseMove;
            this.MouseUp -= SelectEllipse_MouseUp;
            this.Cursor = Cursors.Default;
            btnSelectLine.Enabled = true;
            btnSelectEllipse.Enabled = true;
            Refresh();
        }

        // Find the points of intersection between
        // an ellipse and a line segment.
        private PointF[] FindEllipseSegmentIntersections(RectangleF rect, PointF pt1, PointF pt2, bool segment_only)
        {
            // If the ellipse or line segment are empty, return no intersections.
            if ((rect.Width == 0) || (rect.Height == 0) ||
                ((pt1.X == pt2.X) && (pt1.Y == pt2.Y)))
                return new PointF[] { };

            // Make sure the rectangle has non-negative width and height.
            if (rect.Width < 0)
            {
                rect.X = rect.Right;
                rect.Width = -rect.Width;
            }
            if (rect.Height < 0)
            {
                rect.Y = rect.Bottom;
                rect.Height = -rect.Height;
            }

            // Translate so the ellipse is centered at the origin.
            float cx = rect.Left + rect.Width / 2f;
            float cy = rect.Top + rect.Height / 2f;
            rect.X -= cx;
            rect.Y -= cy;
            pt1.X -= cx;
            pt1.Y -= cy;
            pt2.X -= cx;
            pt2.Y -= cy;

            // Get the semimajor and semiminor axes.
            float a = rect.Width / 2;
            float b = rect.Height / 2;

            // Calculate the quadratic parameters.
            float A = (pt2.X - pt1.X) * (pt2.X - pt1.X) / a / a +
                      (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y) / b / b;
            float B = 2 * pt1.X * (pt2.X - pt1.X) / a / a +
                      2 * pt1.Y * (pt2.Y - pt1.Y) / b / b;
            float C = pt1.X * pt1.X / a / a + pt1.Y * pt1.Y / b / b - 1;

            // Make a list of t values.
            List<float> t_values = new List<float>();

            // Calculate the discriminant.
            float discriminant = B * B - 4 * A * C;
            if (discriminant == 0)
            {
                // One real solution.
                t_values.Add(-B / 2 / A);
            }
            else if (discriminant > 0)
            {
                // Two real solutions.
                t_values.Add((float)((-B + Math.Sqrt(discriminant)) / 2 / A));
                t_values.Add((float)((-B - Math.Sqrt(discriminant)) / 2 / A));
            }

            // Convert the t values into points.
            List<PointF> points = new List<PointF>();
            foreach (float t in t_values)
            {
                // If the points are on the segment (or we
                // don't care if they are), add them to the list.
                if (!segment_only || ((t >= 0f) && (t <= 1f)))
                {
                    float x = pt1.X + (pt2.X - pt1.X) * t + cx;
                    float y = pt1.Y + (pt2.Y - pt1.Y) * t + cy;
                    points.Add(new PointF(x, y));
                }
            }

            // Return the points.
            return points.ToArray();
        }

        // Redraw.
        private void chkSegmentOnly_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
