using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2
{
    class Daire:Sekil
    {
        private int cap;
        public override void BitisAta(int bx, int by)
        {
            cap = bx - X;
        }

        public override void Ciz(Graphics cizimAraci)
        {
            cizimAraci.DrawEllipse(Pens.Red,X,Y, cap, cap);
        }
    }
}
