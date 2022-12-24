namespace VektorProgram
{
    class Vektor
    {
        private double[] m_bilesenler;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vektor v1 = new Vektor();
            Vektor v2 = new Vektor(3.5, 7.2, -5.9);

            v1[0] = 1.0; v1[1] = -1.0; v1[2] = 0.5;

            Vektor v3 = v1 + v2;
            Console.WriteLine("{0} + {1} = {2}");
        }
    }
}