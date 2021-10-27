using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Extensions
{
    public static class PageExtensions
    {
        public static void FillDropDownList(this Page page, ref DropDownList ddl, DataTable dT)
        {
            ddl.DataSource = dT;
            ddl.DataBind();
            ddl.DataTextField = "Name";
            ddl.DataValueField = "ID";
            ddl.DataBind();
        }
    }
}