using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics6
{
    class Ball : IDrawable,IMovable
    {

        public Ball()
        {
            //x = 0;
            //y = 0;
            radius = 40;
            pos = new Vector(50.0, 200.0);
            direction = new Vector(1f,1f);
        }

        public void Reflection(string Yon)
        {

            if (Yon== "YATAY")
            {

                direction.x = -direction.x;
            }

            if (Yon == "DIKEY")
            {

                direction.y = -direction.y;
            }


        }
        public void draw(Graphics grp)
        {
            grp.FillEllipse(Brushes.Red, (int)pos.x,(int)pos.y, radius, radius);
        }

        public void Move()
        {
            pos = pos + direction;
            
            //x += (int)direction.x;
            //y += (int)direction.y;
        }

        public bool isCollideWithLine(Vector p1, Vector p2)
        {
            
            Vector center = new Vector(pos.x+radius,pos.y+radius);

            Vector v1 = p2 - p1;
            Vector v2 = center - p1;
             
            double alpha = Math.Acos(Math2D.dotProduct(v1,v2));

            double v2Length = v2.length();
            double distance = v2Length * Math.Sign(alpha);

            if (distance < radius)
                return true;


            return false;
        }

        //public int x;
        //public int y;
        public int radius;
        public Vector pos;
        public Vector direction;

    }
}
