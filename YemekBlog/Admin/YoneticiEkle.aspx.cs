using DataAccessLayer;
using DataAccessLayer.sql_stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YemekBlog.Admin
{
    public partial class YoneticiEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rbtn_Admin.Checked = true;
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Yoneticiler y = new Yoneticiler();
            if (dm.NullVeBoslukKontrol(tb_Adi.Text))
            {
                y.Adi = tb_Adi.Text;
            }
            else
            {
                Pnl_hata.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }

            if (dm.NullVeBoslukKontrol(tb_Soyad.Text))
            {
                y.SoyAdi = tb_Soyad.Text;
            }
            else
            {
                Pnl_hata.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }

            if (dm.NullVeBoslukKontrol(tb_KullaniciAdi.Text))
            {
                y.KullaniciAdi = tb_KullaniciAdi.Text;
            }
            else
            {
                Pnl_hata.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }
            if (dm.NullVeBoslukKontrol(tb_DogumTarihi.Text))
            {
                y.DogunTarihi = Convert.ToDateTime(tb_DogumTarihi.Text);
            }

            y.UyelikTarihi = DateTime.Now.Date;

            if (dm.NullVeBoslukKontrol(tb_Eposta.Text))
            {
                if (dm.ValidEposta(tb_Eposta.Text))
                {
                    if (dm.UniqueEposta(tb_Eposta.Text))
                    {
                        y.Eposta = tb_Eposta.Text;
                    }
                    else
                    {
                        Pnl_hata.Visible = true;
                        lbl_message.Text = "Eposta Zaten Kayıtlı";
                    }
                }
                else
                {

                    Pnl_hata.Visible = true;
                    lbl_message.Text = "Eposta @ ve .com Içermelidir";
                }
            }
            else
            {
                Pnl_hata.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }
            if (dm.NullVeBoslukKontrol(tb_Sifre.Text))
            {
                y.Sifre = tb_Sifre.Text;
            }
            else
            {
                Pnl_hata.Visible = true;
                lbl_message.Text = "Değer Boş Bırakılamaz";
            }
            if (rbtn_Admin.Checked)
            {
                y.YetkiID = 1;
            }
            else
            {
                y.YetkiID = 2;
            }
            if (dm.YoneticiEkle(y))
            {
                Response.Redirect("AdminDefault.aspx");
            }
            else
            {
                Pnl_hata.Visible = true;
                lbl_message.Text = "Bir Hata İle Karşılaşıldı Lütfen Tekrar Deneyiniz";
            }
        }
    }
}