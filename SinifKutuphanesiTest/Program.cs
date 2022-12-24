using SinifKutuphanesi;

namespace SinifKutuphanesiTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            // başlangıçta boş olan bir dizi
            Dizi<int> d1 = new Dizi<int>();
            d1.Ekle(3);
            d1.Ekle(4);
            d1[2] = 5; //???nasıl yapsak ???

            // Başlangıçta belli sayıda elemanı olan bir dizi
            Dizi<double> d2 = new Dizi<double>(12);
            const double MAX = 1000;
            for(int i=0; i<d2.ElemanSayisi; i++)
            {
                d2[i] = MAX * rnd.NextDouble();
            }

            Console.WriteLine("Başlangıçtaki d2 Elemanları:");
            for (int i = 0; i < d2.ElemanSayisi; i++)
            {
                Console.Write("{0} ", d2[i]);
            }
            Console.WriteLine("\n\n");

            double sayi = MAX * rnd.NextDouble();
            d2.Ekle(3, sayi);

            Console.WriteLine("Araya eleman eklendikten sonra d2 Elemanları:");
            for (int i = 0; i < d2.ElemanSayisi; i++)
            {
                Console.Write("{0} ", d2[i]);
            }
            Console.WriteLine("\n\n");

            d2.Cikar(8); // sıra nosu verilen elemanı aradan çıkart
            Console.WriteLine("Aradan eleman çıkartıldıktan sonra d2 Elemanları:");
            for (int i = 0; i < d2.ElemanSayisi; i++)
            {
                Console.Write("{0} ", d2[i]);
            }
            Console.WriteLine("\n\n");
        }
    }
}