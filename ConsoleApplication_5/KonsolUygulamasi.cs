using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LHarfi
{
    public int x;
    public int y;
    private int genislik;
    private int yukseklik;
    public LHarfi()
    {
        x = 25;
        y = 5;
        genislik = 20;
        yukseklik = 15;
      
    }


    public void Goster()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Red;
        
        //Console.SetCursorPosition(10, 10);

        for (int i = 0; i < yukseklik; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write(" ");
        }
        for (int i = 0; i < genislik; i++)
        {
            Console.SetCursorPosition(x + i, y + yukseklik);
            Console.Write(" ");


        }
        Console.ResetColor();

        Console.SetCursorPosition(10, 20);
        Console.WriteLine("Genislik....:{0}", Console.WindowWidth);
        Console.SetCursorPosition(10, 21);
        Console.WriteLine("Yükseklik....:{0}", Console.WindowHeight);



    }


}

