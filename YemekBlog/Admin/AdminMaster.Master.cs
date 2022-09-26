using DataAccessLayer.sql_stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YemekBlog.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                Yoneticiler y = (Yoneticiler)Session["Admin"];
                lbl_info.Text = $"Hoşgeldiniz {y.YetkiAdi} {y.Adi} {y.SoyAdi}";
            }
            else
            {
                Response.Redirect("YoneticiGiris.aspx");
            }
        }

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Response.Redirect("oneticiGiris.aspx");
        }
    }
}