using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using DataAccessLayer.sql_stuff;

namespace YemekBlog.Admin
{
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e) { tb_KullaniciAdi.Text = ""; }

        protected void lbtn_Giris_Click(object sender, EventArgs e)
        {
            if (dm.NullVeBoslukKontrol(tb_KullaniciAdi.Text) && dm.NullVeBoslukKontrol(tb_Sifre.Text))
            {
                if (dm.ValidEposta(tb_KullaniciAdi.Text))
                {
                    Yoneticiler y = dm.GirisYap(tb_KullaniciAdi.Text, tb_Sifre.Text);
                    if (y != null)
                    {
                        Session["Admin"] = y;
                        Response.Redirect("AdminDefault.aspx");
                    }
                    else
                    {
                        pnl_mesaj.Visible = true;
                        lbl_Hata.Text = "E-posta veya Şifre Hatalı";
                    }
                }
                else
                {
                    pnl_mesaj.Visible = true;
                    lbl_Hata.Text = "E-Posta @ ve .com ifadelerini içermelidir";
                }
            }
            else
            {
                pnl_mesaj.Visible = true;
                lbl_Hata.Text = "E-Posta veya Şifre Boş Bırakılamaz";
            }
        }
    }
}