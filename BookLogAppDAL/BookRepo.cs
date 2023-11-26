using BookLogAppInterfaces;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data;
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

        #region book data functions
        public void CreateBook(string title, string author, string summary, string isbn)
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
                        command.Parameters.Add("@Title", SqlDbType.VarChar).Value = title;
                        command.Parameters.Add("@Author", SqlDbType.VarChar).Value = author;
                        command.Parameters.Add("@Summary", SqlDbType.VarChar).Value = summary;
                        command.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = isbn;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception and rethrow a custom exception or handle it as needed
                throw new ApplicationException("Error occurred while creating the book", ex);
            }
        }


        public List<BookDTO> GetBooks()
        {
            List<BookDTO> bookList = new List<BookDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"SELECT Id, Title, Author, Summary, ISBN FROM Books;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookList.Add(new BookDTO
                            {
                                ID = Convert.ToInt32(reader["Id"]),
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Summary = reader["Summary"].ToString(),
                                ISBN = reader["ISBN"].ToString()
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new ApplicationException("Error occurred while retrieving books", ex);
            }

            return bookList;
        }


        public void UpdateBook(int id, string title, string author, string summary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"UPDATE Books
                           SET Title=@Title,
                               Summary=@Summary,
                               Author=@Author
                           WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@Title", SqlDbType.VarChar).Value = title;
                        command.Parameters.Add("@Summary", SqlDbType.VarChar).Value = summary;
                        command.Parameters.Add("@Author", SqlDbType.VarChar).Value = author;
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        int affectedRows = command.ExecuteNonQuery();
                        if (affectedRows == 0)
                        {
                            //log and handle the situation when no rows are affected
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new ApplicationException("Error occurred in updating the book", ex);
            }
        }


        public BookDTO GetBookById(int id)
        {
            BookDTO bookDTO = null;  //initialize to null, remains null if no book found
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"SELECT Id, Title, Author, Summary, ISBN FROM Books WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) //if a book is found
                            {
                                bookDTO = new BookDTO
                                {
                                    ID = Convert.ToInt32(reader["Id"]),
                                    Title = reader["Title"].ToString(),
                                    Author = reader["Author"].ToString(),
                                    Summary = reader["Summary"].ToString(),
                                    ISBN = reader["ISBN"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new ApplicationException("Error occurred in retrieving the book", ex);
            }

            return bookDTO; //if no book found=null, if book found return BookDTO
        }

        public void DeleteBook(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"DELETE FROM Books WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        int affectedRows = command.ExecuteNonQuery();
                        if (affectedRows == 0)
                        {
                            // Log and handle the situation when no rows are affected
                            // This means no book was found with the given ID
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error occurred in deleting the book", ex);
            }
        }

        #endregion

    }
}
