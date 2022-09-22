﻿using DataAccessLayer;
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
            lv_yorumlar.DataSource = dm.YorumListele(true);
            lv_yorumlar.DataBind();
            lv_Makaleler.DataSource = dm.MakaleListele();
            lv_Makaleler.DataBind();
        }

        protected void lv_Makaleler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                if (dm.MakaleSilGuncelle(false,ID))
                {
                    Response.Redirect("adminDefault.aspx");
                }
            }
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName== "aktif")
            {
                if (dm.YorumSil(ID,false))
                {
                    Response.Redirect("YorumIndex.aspx");
                }
            }
            if (e.CommandName == "KaliciSil")
            {
                if (dm.YorumKaliciSil(ID))
                {
                    Response.Redirect("YorumIndex.aspx");
                }
            }
        }
    }
}