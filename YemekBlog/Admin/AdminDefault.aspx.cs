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
    public partial class AdminDefault : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yorumlar.DataSource = dm.YorumListele(false);
            lv_yorumlar.DataBind();
            lv_Makaleler.DataSource = dm.MakaleListele();
            lv_Makaleler.DataBind();
        }

        protected void lv_Makaleler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            Makaleler makaleler = dm.GetMakale(ID);
            if (e.CommandName == "AktifEt")
            {
                bool a = makaleler.IsDeleted;
                if (a)
                {
                    if (dm.MakaleSilGuncelle(false, ID))
                    {
                        Response.Redirect("adminDefault.aspx");
                    }
                }
                else
                {
                    if (dm.MakaleSilGuncelle(true, ID))
                    {
                        Response.Redirect("adminDefault.aspx");
                    }
                }
            }
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName== "Aktif")
            {
                if (dm.YorumSil(ID,true))
                {
                    Response.Redirect("AdminDefault.aspx");
                }
            }
            if (e.CommandName == "KaliciSil")
            {
                if (dm.YorumKaliciSil(ID))
                {
                    //Response.Redirect("AdminDefault.aspx");
                }
            }
        }
    }
}