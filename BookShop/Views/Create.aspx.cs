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
            DropDownList1.DataSource = bookService.GetAllAuthors();
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();

            DropDownList2.DataSource = bookService.GetAllGenres();
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "ID";
            DropDownList2.DataBind();
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            bookService.CreateBook(
                TextBoxName.Text,
                TextBoxYear.Text,
                TextBoxpagesCount.Text,
                DropDownList1.SelectedItem.Value,
                DropDownList2.SelectedItem.Value);
        }
    }
}