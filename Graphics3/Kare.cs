﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2
{
    class Kare
    {
       public int x;
       public int y;
       public int width;
       public int height;

        public Kare()
        {
            x = y = 0;
            height = width = 0;
        }

        public  void Ciz(Graphics cizimaraci)
        {
            cizimaraci.DrawRectangle(Pens.Blue,x,y,width,height);


        }

    }
}
