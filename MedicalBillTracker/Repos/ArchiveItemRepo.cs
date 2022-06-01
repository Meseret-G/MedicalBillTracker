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
        // Get all Archived Bills by patientId

        public List<Bill> GetAllPatientArchives(int patientId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT ai.patientId as ArchivePatientId,
                        b.Id as Id,
                        b.Title,
                        b.Provider,
                        b.Date
                        b.ImageURL,
                        b.OutOfPocket,
                        b.IsOpen
                        FROM ArchiveItem as ai
                        LEFT JOIN Bill as b
                        ON ai.PatientId = b.PatientId
                     ";

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Bill> bills = new List<Bill>();
                    while (reader.Read())
                    {
                        if (reader["PatientId"] != DBNull.Value)
                        {
                            Bill bill = new Bill
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Provider = reader.GetString(reader.GetOrdinal("Provider")),
                                BillDate = reader.GetDateTime(reader.GetOrdinal("BillDate")),
                                ImageURL = reader.GetString(reader.GetOrdinal("ImageURL")),
                                OutOfPocket = reader.GetDecimal(reader.GetOrdinal("OutOfPocket")),
                                IsOpen = reader.GetBoolean(reader.GetOrdinal("IsOpen")),

                            };
                            bills.Add(bill);
                        }
                    }
                    reader.Close();
                    return bills;
                }
            }
        }
        //public List<ArchiveItem> GetAllArchives()
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                              SELECT 
        //                              id, patientId, billId
        //                              FROM ArchiveItem
        //                              ";
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            List<ArchiveItem> archiveItems = new List<ArchiveItem>();
        //            while (reader.Read())
        //            {
        //                ArchiveItem archive = new ArchiveItem()
        //                {
        //                    Id = reader.GetInt32(reader.GetOrdinal("id")),
        //                    PatientId = reader.GetInt32(reader.GetOrdinal("patientId")),
        //                    BillId = reader.GetInt32(reader.GetOrdinal("billId")),

        //                };

        //                archiveItems.Add(archive);
        //            }
        //            reader.Close();

        //            return archiveItems;
        //        }
        //    }
        //}

        public void AddToArchive(int billId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO ArchiveItem (BillId)
                        VALUES (@billId, @patientId);
                     ";

                    cmd.Parameters.AddWithValue("@billid", billId);
               
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveFromArchive(int id)
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

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool BillExistInArchive(int Id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT * FROM ArchiveItem
                        WHERE Id = @id
                    ";

                    cmd.Parameters.AddWithValue("@id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    bool found = false;
                    while (reader.Read())
                    {
                        var archiveItemId = reader.GetInt32(reader.GetOrdinal("Id"));
                        if (archiveItemId == Id)
                        {
                            found = true;
                        }
                    }
                    reader.Close();
                    return found;
                }
            }
        }


    }
}
