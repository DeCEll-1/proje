using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YemekBlog.Admin
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Kategori_Ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_KategoriAdi.Text))
            {
                if (dm.UniqueKategori(tb_KategoriAdi.Text))
                {
                    Kategoriler k = new Kategoriler();
                    k.KategoriAdi = tb_KategoriAdi.Text;
                    k.IsDeleted = false;
                    if (dm.KategoriEkle(k))
                    {
                        Response.Redirect("AdminDefault.aspx");
                    }
                }
                else
                {
                    lbl_message.Visible = true;
                    lbl_message.Text = "Lütfen Daha Önce Girilmemiş Bir Kategori Adı Giriniz";
                }
            }
            else
            {
                lbl_message.Visible = true;
                lbl_message.Text = "Lütfen Geçerli Bir Kategori Adı Giriniz";
            }
        }
    }
}