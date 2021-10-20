using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Server=(localDb)\\xz;Database=BookShop;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SelectAllBooks", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();

                RepeatInformation.DataSource = cmd.ExecuteReader();
                RepeatInformation.DataBind();
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            string bookId = ((Button)sender).CommandArgument.ToString();

            Response.Redirect($"Edit.aspx?BookId={bookId}");
        }
    }
}