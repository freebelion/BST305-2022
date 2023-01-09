namespace SinifKutuphanesi
{
    public class Dizi<T>
    {
        private int m_elemanSayisi;
        private T[]? m_dizi;

        public Dizi()
        {
            m_elemanSayisi = 0;
            m_dizi = null;
        }

        public Dizi(int esayi)
        {// acaba gelen argümanı kontrol etsek mi?
            if (esayi<1)
            { throw (new ArgumentException("Argüman değeri 1'den düşük olamaz!")); }
            m_dizi = new T[esayi];
        }

        public int ElemanSayisi
        {
            get
            {
                if(m_dizi != null)
                { return m_dizi.Length; }
                else
                { return 0; }
            }
        }

        public T this[int sirano]
        {
            get
            {
                if (m_dizi != null)
                {
                    return m_dizi[sirano];
                }
                throw (new ApplicationException("Dizi null!"));
            }
            set
            {
                if (m_dizi != null)
                {
                    m_dizi[sirano] = value;
                }
                throw (new ApplicationException("Dizi null!"));
            }
        }

        public void Ekle(T yeni)
        {
            if(m_dizi != null)
            {
                T[] yenidizi = new T[ElemanSayisi + 1];
                // bu arada bir şeyler eksik
                for (int i=0; i<ElemanSayisi; i++) 
                { yenidizi[i] = m_dizi[i]; }
                
                yenidizi[ElemanSayisi] = yeni;
                m_dizi = yenidizi;
            }
        }

        public void Ekle(T yeni, int tekrarSayisi)
        {

        }

        public void Ekle(T[] yeniler)
        {

        }
    }
}
