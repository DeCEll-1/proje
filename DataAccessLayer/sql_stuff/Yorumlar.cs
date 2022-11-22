using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorumlar
    {
        public int ID { get; set; }
        public int MakaleID { get; set; }
        public int KullaniciID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime YorumTarihi { get; set; }
        public int? YorumLike { get; set; }
        public bool IsDeleted { get; set; }
        public string KullaniciAdi { get; set; }
    }
}
