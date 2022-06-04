using MedicalBillTracker.Models;
using System.Data.SqlClient;

namespace MedicalBillTracker.Repos
{
    public class ArchiveRepo : IArchiveRepo     
    {
        private readonly IConfiguration _config;

        public ArchiveRepo(IConfiguration config)
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


        public void ArchiveBills(int Id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Archive (Id)
                        VALUES (@id);
                     ";

                    cmd.Parameters.AddWithValue("@id", Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Bill> GetArchiveBills()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT a.Id as ArchiveBillId,
                        b.Id as BillId,
                        b.Title,
                        b.Provider,
                        b.ImageURL,
                        b.OutOfPocket
                        FROM Archive as a
                        LEFT JOIN Bill as b
                        ON a.Id = b.BillId
                     ";

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Bill> bills = new List<Bill>();
                    while (reader.Read())
                    {
                        if (reader["Id"] != DBNull.Value)
                        {
                            Bill bill = new Bill
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Provider = reader.GetString(reader.GetOrdinal("Provider")),
                                ImageURL = reader.GetString(reader.GetOrdinal("ImageURL")),
                                OutOfPocket = reader.GetDecimal(reader.GetOrdinal("OutOfPocket"))
                            };
                            bills.Add(bill);
                        }
                    }
                    reader.Close();
                    return bills;
                }
            }
        }



    }
}
