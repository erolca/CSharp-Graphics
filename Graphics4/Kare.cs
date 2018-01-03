using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2
{
    class Kare:Sekil
    {
     
       public int width;
       public int height;

        public Kare()
        {
          
         width = 0;
        }

        public override void BitisAta(int bx, int by)
        {
            width = bx - X;
        }

        public  override void Ciz(Graphics cizimaraci)
        {
            cizimaraci.DrawRectangle(Pens.Blue,X,Y,width, width);


        }

    }
}
