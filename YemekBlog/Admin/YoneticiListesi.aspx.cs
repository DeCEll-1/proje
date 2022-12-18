using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YemekBlog.Admin
{
    public partial class YoneticiListesi : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yoneticiler.DataSource = dm.YoneticiListele(false);
            lv_yoneticiler.DataBind();
        }

        protected void lv_yoneticiler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
    }
}