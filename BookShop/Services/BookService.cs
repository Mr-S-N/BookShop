using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookShop.Services
{
    public class BookService
    {
        private readonly string ConnectionString;

        public BookService()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public DataTable GetAllBooks()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SelectAllBooks", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                  
                connection.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBook(string Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SelectBookById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                connection.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
        }

        public DataTable GetAllAuthors()
        {
            return GetAllData("SelectAllAuthors");
        }

        public DataTable GetAllGenres()
        {
            return GetAllData("SelectAllGenres");
        }

        public void CreateBook(string Name, string Year, string PageCount, string AuthorId,string GenreID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateBook", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Name", Name));
                cmd.Parameters.Add(new SqlParameter("@Yaer", Year));
                cmd.Parameters.Add(new SqlParameter("@PageCount", PageCount));
                cmd.Parameters.Add(new SqlParameter("@AuthorId", AuthorId));
                cmd.Parameters.Add(new SqlParameter("@GenreID", GenreID));
                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void EditBook(string bookId, string Name, string Year, string PageCount, string AuthorId, string GenreID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateBook", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@BookId", bookId));
                cmd.Parameters.Add(new SqlParameter("@Name", Name));
                cmd.Parameters.Add(new SqlParameter("@Yaer", Year));
                cmd.Parameters.Add(new SqlParameter("@PageCount", PageCount));
                cmd.Parameters.Add(new SqlParameter("@AuthorId", AuthorId));
                cmd.Parameters.Add(new SqlParameter("@GenreID", GenreID));
                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }


        private DataTable GetAllData(string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(name, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
        }
    }
}

