using BookShop.Services;
using System;
using System.Web.UI;

namespace BookShop
{
    public partial class Create : Page
    {
        private readonly BookService bookService = new BookService();
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            bookService.CreateBook(
                txName.Text,
                txYear.Text,
                txPagesCount.Text,
                ddlAuthors.SelectedItem.Value,
                ddlGenres.SelectedItem.Value);
        }
    }
}