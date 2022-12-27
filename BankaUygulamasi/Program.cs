namespace BankaUygulamasi
{
    class Hesap
    {
        private static uint _hesapSayisi = 0;
        protected decimal _bakiye;
        private uint _no;

        public uint No
        { get { return _no; } }

        public decimal Bakiye
        { get { return _bakiye; } }

        public Hesap()
        {
            _hesapSayisi++;
            _no = _hesapSayisi;
            _bakiye = 0;
        }

        public void ParaYatir(decimal tutar)
        {
            _bakiye += tutar;
        }

        public virtual void ParaCek(decimal tutar)
        {
            if (_bakiye >= tutar)
            { _bakiye -= tutar; }
        }
    }

    class KrediliHesap : Hesap
    {
        private static decimal _EksiLimit = -1000;

        public override void ParaCek(decimal tutar)
        {
            if (_bakiye - tutar >= _EksiLimit)
            { _bakiye -= tutar; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hesap> hesaplar = new List<Hesap>();

            Hesap h;

            for (int i = 0; i < 3; i++)
            {
                h = new Hesap();
                hesaplar.Add(h);
            }

            for (int i = 0; i < 3; i++)
            {
                h = new KrediliHesap();
                hesaplar.Add(h);
            }

            string? cevap;
            int no;
            bool bEkle;
            decimal tutar;
            const double MAXTUTAR = 10000;
            Random rnd = new Random();
            System.Globalization.CultureInfo trcl =
                new System.Globalization.CultureInfo("tr-TR");

            Console.WriteLine("Rasgele işlem yaptırmak için ENTER'a basın");
            while (true)
            {// Bilinçli yazılmış sonsuz döngü
                cevap = Console.ReadLine(); // possible bug here!
                if (!String.IsNullOrEmpty(cevap)) break;

                // Listeden rasgele bir hesap seç
                no = rnd.Next(hesaplar.Count);
                h = hesaplar[no];
                // Rasgele bir tutar belirle
                tutar = (decimal)Math.Round(MAXTUTAR * rnd.NextDouble(), 2);
                // Para eklenecek mi çekilecek mi, onu seç
                bEkle = (rnd.Next() % 2) != 0;
                if (bEkle)
                {
                    Console.WriteLine("{0} nolu hesaba {1:0.00} TL eklenecek",
                        h.No, tutar);
                    h.ParaYatir(tutar);
                    Console.WriteLine("{0} nolu hesap bakiyesi: {1}",
                        h.No, h.Bakiye.ToString("C", trcl));
                }
                else
                {
                    Console.WriteLine("{0} nolu hesaptan {1} TL çekilecek",
                        h.No, tutar);
                    h.ParaCek(tutar);
                    Console.WriteLine("{0} nolu hesap bakiyesi: {1} TL",
                        h.No, h.Bakiye.ToString("C", trcl));
                }

                for (int i = 0; i < hesaplar.Count; i++)
                { Console.Write("{0,12}", hesaplar[i].Bakiye.ToString("C", trcl)); }
                Console.WriteLine();
            }
        }
    }
}