using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class Kullaniciler
    {
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public DateTime UyelikTarihi { get; set; }
        public DateTime DogunTarihi { get; set; }//DogunTarihi
        public string OzelSoru { get; set; }
        public bool IsDeleted { get; set; }
    }
}
