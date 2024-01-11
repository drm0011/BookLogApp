using DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using BookLogAppInterfaces;

namespace BookLogAppDAL
{
    public class JournalRepo:IJournalRepo
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
        public int GetJournalEntryIdForBook(int bookId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"SELECT TOP 1 Id FROM JournalEntries WHERE BookId = @BookId ORDER BY Id DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@BookId", SqlDbType.Int).Value = bookId;

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error occurred in retrieving the entry ID", ex);
            }

            return 0; 
        }
        public void UpsertJournalEntry(string entry, int bookId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnString()))
                {
                    connection.Open();
                    string sql = @"
                IF EXISTS (SELECT 1 FROM JournalEntries WHERE BookId = @BookId)
                    UPDATE JournalEntries SET Entry = @Entry WHERE BookId = @BookId;
                ELSE
                    INSERT INTO JournalEntries (Entry, BookId) VALUES (@Entry, @BookId);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@Entry", SqlDbType.VarChar).Value = entry;
                        command.Parameters.Add("@BookId", SqlDbType.Int).Value = bookId;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error occurred while updating or creating entry", ex);
            }
        }

    }
}
