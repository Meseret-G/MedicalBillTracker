using MedicalBillTracker.Models;
using System.Data.SqlClient;

namespace MedicalBillTracker.Repos
{
    public class ArchiveItemRepo : IArchiveItemRepo
    {
        private readonly IConfiguration _config;

        public ArchiveItemRepo(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        // Get all bills by ArchiveID
        public List<Bill> GetAllItemsByArchiveId(int archiveId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT a.Id,b.Title, b.Provider, b.ImageURL, b.OutOfPocket, b.IsOpen , a.archiveId,
                        FROM ArchiveItem as a
                        LEFT JOIN Bill as b
                        on b.Id = a.BillId
                        WHERE a.ArchiveId = @archiveId";

                    cmd.Parameters.AddWithValue("@archiveId", archiveId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Bill> list = new List<Bill>();
                        while (reader.Read())
                        {
                            Bill item = new Bill
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Provider = reader.GetString(reader.GetOrdinal("Provider")),
                                ImageURL = reader.GetString(reader.GetOrdinal("ImageURL")),
                                OutOfPocket = reader.GetDecimal(reader.GetOrdinal("OutOfPocket")),
                                IsOpen = reader.GetBoolean(reader.GetOrdinal("IsOpen")),
                       
                            };

                            list.Add(item);
                        }
                        return list;
                    }
                }
            }
        }

        public void AddArchiveItem(ArchiveItem item)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO ArchiveItem (BillId, ArchiveId)
                        VALUES (@billId, @archiveId);
                    ";

                    cmd.Parameters.AddWithValue("@billId", item.BillId);
                    cmd.Parameters.AddWithValue("@archiveId", item.ArchiveId);
                  
                    int id = (int)cmd.ExecuteNonQuery();

                    item.Id = id;
                }
            }
        }

        public ArchiveItem ArchiveItemExists(int billId, int archiveId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, BillId, ArchiveId
                        FROM ArchiveItem
                        WHERE BillId = @billId AND ArchiveId = @archiveId";

                    cmd.Parameters.AddWithValue("@billId", billId);
                    cmd.Parameters.AddWithValue("@archiveId", archiveId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ArchiveItem item = new ArchiveItem()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                ArchiveId = reader.GetInt32(reader.GetOrdinal("ArchiveId")),
                                BillId = reader.GetInt32(reader.GetOrdinal("BillId")),
                            
                            };
                            return item;
                        }
                        else return null;
                    }
                }
            }
        }

        public void DeleteArchiveItem(int archiveItemId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE
                        FROM ArchiveItem
                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", archiveItemId);

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
