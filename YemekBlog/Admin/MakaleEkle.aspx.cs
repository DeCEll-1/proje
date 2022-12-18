using DataAccessLayer;
using DataAccessLayer.sql_stuff;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YemekBlog.Admin
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_Kategori.DataSource = dm.KategoriListele(0);
                ddl_Kategori.DataBind();

            }
        }

        protected void lbtn_submit_Click(object sender, EventArgs e)
        {
            if (tb_Content.Text != "" || tb_list.Text != "" || tb_baslik.Text != "")
            {
                Makaleler m = new Makaleler();
                m.Baslik = tb_baslik.Text;
                m.KategoriID = Convert.ToInt32(ddl_Kategori.SelectedItem.Value);
                m.Ozet = tb_list.Text;
                m.Tamicerik = tb_Content.Text;
                m.IsDeleted = !cb_confirm.Checked;
                m.YuklemeTarihi = DateTime.Now;
                Yoneticiler y = (Yoneticiler)Session["Admin"];
                m.YoneticiID = y.ID;
                m.Okundu = 0;

                    if (fu_min.HasFile)
                {
                    FileInfo fi = new FileInfo(fu_max.FileName);
                    string fileName = "";
                    foreach (char item in fi.Name)
                    {
                        if (item != '.')
                        {
                            fileName += item;
                        }
                        else
                        {
                            break;
                        }
                    }
                    fileName += Guid.NewGuid().ToString();
                    fileName += fi.Extension;
                    m.ThumbnailAdi = fileName;
                }
                else
                {
                    m.TamResimAdi = "Sad.png";
                }

                if (fu_max.HasFile)
                {
                    FileInfo fi = new FileInfo(fu_max.FileName);
                    string fileName = "";
                    foreach (char item in fi.Name)
                    {
                        if (item != '.')
                        {
                            fileName += item;
                        }
                        else
                        {
                            break;
                        }
                    }
                    fileName += Guid.NewGuid().ToString();
                    fileName += fi.Extension;
                    m.TamResimAdi = fileName;
                }
                else
                {
                    m.TamResimAdi = "Sad.png";
                }

                if (dm.MakaleEkle(m))
                {
                    Response.Redirect("AdminDefault.aspx");
                }
                else
                {
                    pnl_Hata.Visible = true;
                    lbl_Hata.Text = "Bir Hata Oluştu";
                }
            }
            else
            {
                pnl_Hata.Visible = true;
                lbl_Hata.Text = "Lütfen Bütün Kutuları Doldurun";
            }



        }
    }
}