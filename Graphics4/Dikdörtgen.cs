using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2
{
    class Dikdörtgen:Sekil
    {
        private int width;
        private int height;

        public override void BitisAta(int bx, int by)
        {
            width = bx - X;
            height = by - Y;
        }

        public override void Ciz(Graphics cizimAraci)
        {
            cizimAraci.DrawEllipse(Pens.Red, X, Y, width, height);
        }

    }
}
