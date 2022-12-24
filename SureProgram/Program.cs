using System.Security.Cryptography;

namespace SureProgram
{
    class Sure
    {
        private int _saat, _dakika, _saniye;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Sure s1 = new Sure();
            s1.Dakika = 24;
            s1.Saat = 2;
            s1.Saniye = 41;
            Console.WriteLine("{0} = {1:0.00} Saat = {2} Saniye",
                s1, s1.ToplamSaat, s1.ToplamSaniye);
        }
    }
}