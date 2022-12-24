using System.Runtime.CompilerServices;

namespace KesirProgram
{
    public class Kesir
    {
        private int _pay;
        private int _payda;

        public Kesir()
        {
            _pay = 0;
            _payda = 1;
        }

        public Kesir(int p, int q)
        {
            this.Pay = p;
            this.Payda = q;
        }

        public double Oran
        { get { return (double) _pay / _payda; } }

        public int Pay
        {
            get { return _pay; }
            set { _pay = value; }
        }

        public int Payda
        {
            get { return _payda; }
            set
            {
                if (value < 0)
                {
                    _payda = -value;
                    _pay = -_pay;
                }
                else if (value > 0)
                { _payda = value; }
                else
                {
                    throw (new ArgumentException("Payda değeri 0 olamaz!"));
                }
            }
        }

        public static explicit operator double(Kesir k)
        {
            return k.Oran;
        }

        public override string ToString()
        {
            return "[" + _pay.ToString() + "/" + _payda.ToString() + "]";
        }

        public static Kesir operator + (Kesir k1, Kesir k2)
        {
            Kesir sonuc = new Kesir();
            sonuc.Pay = k1.Pay * k2.Payda + k1.Payda * k2.Pay;
            sonuc.Payda = k1.Payda * k2.Payda;
            return sonuc;
        }

        public static Kesir operator * (Kesir k1, Kesir k2)
        {
            return new Kesir();
        }

        public static bool operator < (Kesir k1, Kesir k2)
        {
            // henüz yazmadık
            return true;
        }

        public static bool operator > (Kesir k1, Kesir k2)
        {
            // henüz yazmadık
            return true;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Kesir k1; //boş referans değişken tanımı
            k1 = new Kesir(); //boş nesne oluşturuyoruz
            k1.Pay = 1; k1.Payda = 2;

            Console.WriteLine("{0}={1}",
                k1, (double)k1);

            Kesir k2 = new Kesir(3, 5); //argümanlarla nesne oluşturuyoruz
            Console.WriteLine("{0}={1}",
                k2, (double)k2);

            Kesir k3 = k1 + k2;
            Console.WriteLine("{0}+{1}={2}={3}",
                k1, k2, k3, (double)k3);
        }
    }
}