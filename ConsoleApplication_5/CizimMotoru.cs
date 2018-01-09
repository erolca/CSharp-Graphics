using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication_4
{
    class CizimMotoru
    {
        private Sekil[] sekiller;
        private int ekliSekilSayisi;
        private int maksimumSekilSayisi;



        public CizimMotoru()
        {
            maksimumSekilSayisi = 10;
            sekiller = new Sekil[maksimumSekilSayisi];// referans dizilerini gosteren referans
            ekliSekilSayisi = 0;

        }

        public void SekilEkle(Sekil yeniSekil)
        {
           
            if(ekliSekilSayisi<maksimumSekilSayisi)
            {
                sekiller[ekliSekilSayisi]= yeniSekil;
                ekliSekilSayisi++;

            }
        }
        public void Bekle(int milisaniye)
        {
            Thread.Sleep(milisaniye);
        }

        public void Ciz()
        {
            while(true)
            {

                Console.Clear();
                for(int i=0;i<ekliSekilSayisi;i++)
                {
                    sekiller[i].Animasyon();
                    sekiller[i].Ciz();

                }
                Console.SetCursorPosition(0, 0);
                Bekle(50);
            }
            
        }



    }
}
