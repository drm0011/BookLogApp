using BookLogAppInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppDAL
{
    public class BookRepo:IBookRepo
    {
        private string GetConnString(string connName = @"Server=(localdb)\mssqllocaldb;Database=BookLogApp;Trusted_Connection=True;")
        {
            return connName;
        }

        public void CreateBook(string title, string author, string summary, int isbn)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();

                    string sql = @"INSERT INTO Books (Title, Author, Summary, ISBN) 
                           VALUES (@Title, @Author, @Summary, @ISBN);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Author", author);
                        command.Parameters.AddWithValue("@Summary", summary);
                        command.Parameters.AddWithValue("@ISBN", isbn);

                        command.ExecuteNonQuery(); // Execute the SQL command
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                throw;
            }
        }


    }
}
