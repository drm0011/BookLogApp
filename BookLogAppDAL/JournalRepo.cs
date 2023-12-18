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
    public class JournalRepo
    {
        private string GetConnString(string connName = @"Server=(localdb)\mssqllocaldb;Database=BookLogApp;Trusted_Connection=True;")
        {
            return connName;
        }

        public JournalDTO GetEntryAndBookById(int id, int bookId) 
        {
            JournalDTO journalDTO = null;  
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"SELECT Id, BookId, Entry FROM JournalEntries WHERE Id = @Id AND BookId=@BookId";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        command.Parameters.Add("@BookId", SqlDbType.Int).Value = bookId;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                journalDTO = new JournalDTO
                                {
                                    ID = Convert.ToInt32(reader["Id"]),
                                    BookID = Convert.ToInt32(reader["BookId"]),
                                    Entry = reader["Entry"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error occurred in retrieving the entry", ex);
            }

            return journalDTO; 
        }
    }
}
