using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace BookShop
{
    public partial class About : Page
    {
        private readonly string ConnectionString = "Server=(localDb)\\xz;Database=BookShop;Trusted_Connection=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SelectAllAuthors", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();

                cmd.CommandText = "SelectAllGenres";
                adpt.SelectCommand = cmd;
                dt = new DataTable();
                adpt.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataBind();
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "ID";
                DropDownList2.DataBind();
            }
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateBook", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Name", TextBoxName.Text));
                cmd.Parameters.Add(new SqlParameter("@Yaer", TextBoxYear.Text));
                cmd.Parameters.Add(new SqlParameter("@PageCount", TextBoxpagesCount.Text));
                cmd.Parameters.Add(new SqlParameter("@AuthorId", DropDownList1.SelectedItem.Value));
                cmd.Parameters.Add(new SqlParameter("@GenreID", DropDownList2.SelectedItem.Value));
                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}