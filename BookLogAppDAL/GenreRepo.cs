using BookLogAppInterfaces;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogAppDAL
{
    public class GenreRepo : IGenreRepo
    {
        private string GetConnString(string connName = @"Server=(localdb)\mssqllocaldb;Database=BookLogApp;Trusted_Connection=True;")
        {
            return connName;
        }

        #region genre data functions
        public void CreateGenre(string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"INSERT INTO Genre (Name) 
                           VALUES (@Name);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception and rethrow a custom exception or handle it as needed
                throw new ApplicationException("Error occurred while creating the genre", ex);
            }
        }


        public List<GenreDTO> GetGenres()
        {
            List<GenreDTO> genreList = new List<GenreDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"SELECT Id, Name FROM Genre;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                genreList.Add(new GenreDTO
                                {
                                    ID = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new ApplicationException("Error occurred while retrieving genres", ex);
            }

            return genreList;
        }


        public void UpdateGenre(int id, string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"UPDATE Genre
                           SET Name=@Name
                           WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
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
                throw new ApplicationException("Error occurred in updating the genre", ex);
            }
        }


        public GenreDTO GetGenreById(int id)
        {
            GenreDTO genreDTO = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"SELECT Id, Name FROM Genre WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                genreDTO = new GenreDTO
                                {
                                    ID = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new ApplicationException("Error occurred in retrieving the genre", ex);
            }

            return genreDTO;
        }

        public void DeleteGenre(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();

                    using(SqlTransaction transaction = connection.BeginTransaction()) 
                    {
                        string sqlDeleteRelations = @"DELETE FROM Books_Genre WHERE GenreId=@Id";
                        using (SqlCommand command = new SqlCommand(sqlDeleteRelations, connection, transaction))
                        {
                            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            command.ExecuteNonQuery();
                        }

                        string sqlDeleteGenre = @"DELETE FROM Genre WHERE Id=@Id";

                        using (SqlCommand command = new SqlCommand(sqlDeleteGenre, connection, transaction))
                        {
                            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error occurred in deleting the Genre", ex);
            }
        }

        public void CreateBooksGenreRelation(int bookId, int genreId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"INSERT INTO Books_Genre (BookId, GenreId) 
                           VALUES (@BookId, @GenreId);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@BookId", SqlDbType.Int).Value = bookId;
                        command.Parameters.Add("@GenreId", SqlDbType.Int).Value = genreId;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error occurred while creating record", ex);
            }
        }

        public void DeleteBooksGenreRelationByBookId(int bookId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"DELETE FROM Books_Genre WHERE BookId = @BookId;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@BookId", SqlDbType.Int).Value = bookId;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error occurred while deleting book-genre relations", ex);
            }
        }


        #endregion

    }
}



