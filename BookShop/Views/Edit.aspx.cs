using BookShop.Extensions;
using BookShop.Services;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class Edit : Page
    {
        private readonly BookService bookService = new BookService();
        protected void Page_Load(object sender, EventArgs e)
        {
           string bookId = Request.QueryString["BookId"];

            var dt = bookService.GetBook(bookId);
            DataRow row = dt.Rows[0];
            txName.Text = row["Name"].ToString();
            txYear.Text = row["Year"].ToString();
            txPagesCount.Text = row["PageCount"].ToString();

            this.FillDropDownList(ddlAuthors, bookService.GetAllAuthors());
            this.FillDropDownList(ddlGenres, bookService.GetAllGenres());
        }


        protected void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                bookService.EditBook(
                  txId.Text,
                  txName.Text,
                  txYear.Text,
                  txPagesCount.Text,
                  ddlAuthors.SelectedItem.Value,
                  ddlGenres.SelectedItem.Value);

                ClientScript.RegisterStartupScript(this.GetType(), "ShowUpdate", "ShowUpdate('" + true + "');", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ShowUpdate", "ShowUpdate('" + false + "');", true);
            }
        }
    }
}