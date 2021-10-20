using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace BookShop
{
    public partial class Contact : Page
    {
        private readonly string ConnectionString = "Server=(localDb)\\xz;Database=BookShop;Trusted_Connection=True";

        protected void Page_Load(object sender, EventArgs e)
        {
           string bookId = Request.QueryString["BookId"];

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SelectBookById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                cmd.Parameters.Add(new SqlParameter("@Id", bookId));

                SqlDataReader reader = cmd.ExecuteReader();

                IdTextBox.Text = bookId;
                while (reader.Read())
                {
                    TextBoxName.Text = reader["Name"].ToString();
                    TextBoxYear.Text = reader["Year"].ToString();
                    TextBoxpagesCount.Text = reader["PageCount"].ToString();
                }
                reader.Close();

                cmd.Parameters.Clear();
                cmd.CommandText = "SelectAllAuthors";
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

        protected void EditButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateBook", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@BookId", IdTextBox.Text));
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