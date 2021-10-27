using BookShop.Services;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class _Default : Page
    {
        private readonly BookService bookService = new BookService();

        protected void Page_Load(object sender, EventArgs e)
        {
            RepeatInformation.DataSource = bookService.GetAllBooks();
            RepeatInformation.DataBind();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            string bookId = ((Button)sender).CommandArgument.ToString();

            Response.Redirect($"Edit.aspx?BookId={bookId}");
        }
    }
}