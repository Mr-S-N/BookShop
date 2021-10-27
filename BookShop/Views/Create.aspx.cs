using BookShop.Extensions;
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
            this.FillDropDownList(ddlAuthors, bookService.GetAllAuthors());
            this.FillDropDownList(ddlGenres, bookService.GetAllGenres());
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