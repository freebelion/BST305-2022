namespace CizgiProgram
{
    class Nokta
    {
        /* 
         * Önceki bir projedeki Nokta sınıf tanımını
           hazır kullanıyoruz.
           "Kodların yeniden kullanımı" (code reuse)
           nesneye yönelik programlamanın ikinci
           önemli prensibidir.
        */
        private double m_x;
        private double m_y;

        public Nokta()
        {
            this.m_x = 0;
            this.m_y = 0;
        }

        public Nokta(double initx, double inity)
        {
            this.m_x = initx;
            this.m_y = inity;
        }

        public double X
        {
            get { return m_x; }
            set
            {
                this.m_x = value;
            }
        }

        public double Y
        {
            get { return m_y; }
            set
            {
                this.m_y = value;
            }
        }

        /// <summary>
        /// Bu fonksiyon noktanın orijine uzaklığını hesaplar
        /// </summary>
        public double Uzaklik
        {
            get { return Math.Sqrt(m_x * m_x + m_y * m_y); }
        }

        public static double AraUzaklik(Nokta n1, Nokta n2)
        {
            return Math.Pow(n1.X - n2.X, 2) + Math.Pow(n1.Y - n2.Y, 2);
        }

        public override string ToString()
        { return "[" + m_x.ToString("0.000") + " | " + m_y.ToString("0.000") + "]"; }
    }

    class Cizgi
    {
        // Bu bir "sarıcı sınıf" (wrapper class) tanımıdır.
        /* Bu sınıf aslında aşağıda gizli tanımlanmış
           m_noktalar koleksiyonuna nokta ekleme/çıkarma
           işlemlerinde aracılık edecektir.
        */
        private List<Nokta> m_noktalar;

        /* Aşağıdaki "boş kurucu fonksiyon" (default constructor)
           yalnızca boş bir noktalar koleksiyonu oluşturacaktır.
        */
        public Cizgi()
        { m_noktalar = new List<Nokta>(); }

        public void Ekle(Nokta n)
        { m_noktalar.Add(n); }

        public void BasaEkle(Nokta n)
        {
            m_noktalar.Insert(0, n);
        }

        public int NoktaSayisi
        {
            get { return m_noktalar.Count; }
        }

        public Nokta this[int sirano]
        {// Bu bir eleman erişim işlemcisi, yani "indexer"
            get 
            { // gerekli kontrolleri ekleyin
                return m_noktalar[sirano]; 
            }
            set
            {// gerekli kontrolleri ekleyin
                m_noktalar[sirano] = value;
            }
        }

        public double ToplamUzunluk
        {
            get
            {
                return 0;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Cizgi c1 = new Cizgi();

            Nokta n = new Nokta(3, 4);
            Console.WriteLine("Nokta{0} orijine uzaklığı: {1}",
                n, n.Uzaklik);

            c1.Ekle(n); // n noktasını çizgiye ekle
            Console.WriteLine("Çizgide şu an {0} adet nokta var.", c1.NoktaSayisi);
            for (int i = 0; i < 5; i++)
            {
                n = new Nokta(10 * rnd.NextDouble(), 10 * rnd.NextDouble());
                c1.Ekle(n); // n noktasını çizgiye ekle
                Console.WriteLine("Çizgide şu an {0} adet nokta var.", c1.NoktaSayisi);
                Console.WriteLine("Nokta{0} orijine uzaklığı: {1}",
                    n, n.Uzaklik);
            }
        }
    }
}