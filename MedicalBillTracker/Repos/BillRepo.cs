using MedicalBillTracker.Models;
using System.Data.SqlClient;

namespace MedicalBillTracker.Repos
{
    public class BillRepo : IBillRepo
    {
        private readonly IConfiguration _config;

        public BillRepo(IConfiguration config)
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
        public List<Bill> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Title, [Provider],ImageURL,OutOfPocket, IsOpen
                        FROM Bill";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Bill> bills = new List<Bill>();
                        while (reader.Read())
                        {
                            Bill bill = new Bill()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Provider = reader.GetString(reader.GetOrdinal("Provider")),
                                //ServiceDate = reader.GetDateTime(reader.GetOrdinal("ServiceDate")),
                                ImageURL = reader.GetString(reader.GetOrdinal("ImageURL")),
                                OutOfPocket = reader.GetDecimal(reader.GetOrdinal("OutofPocket")),
                                IsOpen = reader.GetBoolean(reader.GetOrdinal("IsOpen"))                        
                            };
                            bills.Add(bill);
                        }
                        return bills;
                    }
                }
            }
        }

        public Bill? GetById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id,Title, [Provider],ImageURL,OutOfPocket, IsOpen
                        FROM Bill
                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Bill bill = new Bill()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Provider = reader.GetString(reader.GetOrdinal("Provider")),
                                //ServiceDate = reader.GetDateTime(reader.GetOrdinal("ServiceDate")),
                                ImageURL = reader.GetString(reader.GetOrdinal("ImageURL")),
                                OutOfPocket = reader.GetDecimal(reader.GetOrdinal("OutofPocket")),
                                IsOpen = reader.GetBoolean(reader.GetOrdinal("IsOpen"))
                            };
                            return bill;
                        }
                        else return null;
                    }
                }
            }
        }

        public void AddBill(Bill bill)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Bill (Title, [Provider],ImageURL,OutOfPocket, IsOpen)
                        OUTPUT INSERTED.ID
                        VALUES (@title, @provider,@imageURL,@outOfPocket, @isOpen);
                    ";
                 
                    cmd.Parameters.AddWithValue("@title", bill.Title);
                    cmd.Parameters.AddWithValue("@provider", bill.Provider);
                    cmd.Parameters.AddWithValue("@imageURL", bill.ImageURL);
                    cmd.Parameters.AddWithValue("@outOfPocket", bill.OutOfPocket);
                    cmd.Parameters.AddWithValue("@isOpen", bill.IsOpen);
                  
                    int id = (int)cmd.ExecuteScalar();

                    bill.Id = id;
                }
            }
        }
        public void UpdateBill(int id, Bill bill)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Bill
                                        SET Title = @title,
	                                        Provider = @provider,
	                                        ImageURL = @imageURL,
	                                        OutOfPocket = @outOfPocket,
	                                        IsOpen = @isOpen
		                                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@title", bill.Title);
                    cmd.Parameters.AddWithValue("@provider", bill.Provider);
                    cmd.Parameters.AddWithValue("@imageURL", bill.ImageURL);
                    cmd.Parameters.AddWithValue("@outOfPocket", bill.OutOfPocket);
                    cmd.Parameters.AddWithValue("@isOpen", bill.IsOpen);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
