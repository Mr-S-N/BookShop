using BookShop.Services;
using System;
using System.Data;
using System.Web.UI;

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

            ddlAuthors.DataSource = bookService.GetAllAuthors();
            ddlAuthors.DataBind();
            ddlAuthors.DataTextField = "Name";
            ddlAuthors.DataValueField = "ID";
            ddlAuthors.DataBind();

            ddlGenres.DataSource = bookService.GetAllGenres();
            ddlGenres.DataBind();
            ddlGenres.DataTextField = "Name";
            ddlGenres.DataValueField = "ID";
            ddlGenres.DataBind();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            bookService.EditBook(
              txId.Text,
              txName.Text,
              txYear.Text,
              txPagesCount.Text,
              ddlAuthors.SelectedItem.Value,
              ddlGenres.SelectedItem.Value);
        }
    }
}