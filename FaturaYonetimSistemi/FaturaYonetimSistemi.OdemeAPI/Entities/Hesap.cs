namespace FaturaYonetimSistemi.OdemeAPI.Entities
{
    public class Hesap
    {
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long TCNo { get; set; }
        public string HesapNo { get; set; }
        public decimal HesapBakiye { get; set; }
        public string KartNo { get; set; }
        public decimal Limit { get; set; }
        public decimal Borc { get; set; }


    }
}
