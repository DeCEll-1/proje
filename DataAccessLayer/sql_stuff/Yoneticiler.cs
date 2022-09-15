using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.sql_stuff
{
    public class Yoneticiler
    {
        public int ID { get; set; }
        public int YetkiID { get; set; }
        public string Adi { get; set; }
        public string SoyAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public DateTime UyelikTarihi { get; set; }
        public DateTime DogunTarihi { get; set; }
        public bool IsDeleted { get; set; }
    }
}
