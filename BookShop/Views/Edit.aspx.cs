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
            TextBoxName.Text = row["Name"].ToString();
            TextBoxYear.Text = row["Year"].ToString();
            TextBoxpagesCount.Text = row["PageCount"].ToString();
                
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

        protected void EditButton_Click(object sender, EventArgs e)
        {
            bookService.EditBook(
              IdTextBox.Text,
              TextBoxName.Text,
              TextBoxYear.Text,
              TextBoxpagesCount.Text,
              DropDownList1.SelectedItem.Value,
              DropDownList2.SelectedItem.Value);
        }
    }
}