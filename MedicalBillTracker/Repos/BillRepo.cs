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
                        SELECT Id, Title, [Provider],ImageURL,OutOfPocket, IsArchived
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
                                ImageURL = reader.GetString(reader.GetOrdinal("ImageURL")),
                                OutOfPocket = reader.GetDecimal(reader.GetOrdinal("OutofPocket")),
                                IsArchived = reader.GetBoolean(reader.GetOrdinal("IsArchived")),
                              

                            };
                            bills.Add(bill);
                        }
                        return bills;
                    }
                }
            }
        }

        public Bill? GetBillById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id,Title, [Provider],ImageURL,OutOfPocket, IsArchived
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
                                ImageURL = reader.GetString(reader.GetOrdinal("ImageURL")),
                                OutOfPocket = reader.GetDecimal(reader.GetOrdinal("OutofPocket")),
                                IsArchived = reader.GetBoolean(reader.GetOrdinal("IsArchived")),
                             
                            };
                            return bill;
                        }
                        else return null;   
                        
                    }
                }
            }
        }

        public void AddBill(Bill _bill)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Bill (Title, [Provider],ImageURL,OutOfPocket, IsArchived)
                        OUTPUT INSERTED.ID
                        VALUES (@title, @provider,@imageURL,@outOfPocket, @isArchived);
                    ";
                 
                    cmd.Parameters.AddWithValue("@title", _bill.Title);
                    cmd.Parameters.AddWithValue("@provider", _bill.Provider);
                    cmd.Parameters.AddWithValue("@imageURL", _bill.ImageURL);
                    cmd.Parameters.AddWithValue("@outOfPocket",_bill.OutOfPocket);
                    cmd.Parameters.AddWithValue("@isArchived", _bill.IsArchived);
              


                    cmd.ExecuteNonQuery();
                    
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
                                            IsArchived = @isArchived
                                            
		                                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@title", bill.Title);
                    cmd.Parameters.AddWithValue("@provider", bill.Provider);
                    cmd.Parameters.AddWithValue("@imageURL", bill.ImageURL);
                    cmd.Parameters.AddWithValue("@outOfPocket", bill.OutOfPocket);
                    cmd.Parameters.AddWithValue("@isArchived", bill.IsArchived);
               

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteBill(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM Bill
                        WHERE Id = @id
                    ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        //archieving bills
        public void ArchiveBill(int id, Bill bill)
        {
            //using (SqlConnection conn = Connection)
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = @"
            //           UPDATE Bill 
            //           SET IsArchived = 1

            //            WHERE Id = @id
            //            ";

            //        cmd.Parameters.AddWithValue("@id", Id);


            //        cmd.ExecuteNonQuery();


            //    }
            //}

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
                                            IsArchived = 1
                                            
		                                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@title", bill.Title);
                    cmd.Parameters.AddWithValue("@provider", bill.Provider);
                    cmd.Parameters.AddWithValue("@imageURL", bill.ImageURL);
                    cmd.Parameters.AddWithValue("@outOfPocket", bill.OutOfPocket);
                   


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
                        SELECT * FROM Bill
WHERE
isArchived = 1      
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
                                OutOfPocket = reader.GetDecimal(reader.GetOrdinal("OutOfPocket")),
                                IsArchived = reader.GetBoolean(reader.GetOrdinal("IsArchived")),
                            };
                            bills.Add(bill);
                        }
                    }
                    reader.Close();
                    return bills;
                }
            }
        }

        public void DeleteArchiveBill(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM Bill
                        WHERE IsArchived = 1
                    ";

                    cmd.Parameters.AddWithValue("@id",id );

                    cmd.ExecuteNonQuery();
                }
            }
        }
        //public List<Bill> GetArchivedBills()
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                                Select *
        //                                FROM [Bill]
        //                                WHERE isarchived is true
        //                              ";


        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                List<Bill> patientBills = new List<Bill>();
        //                while (reader.Read())
        //                {
        //                    Bill patientBill = new Bill()
        //                    {
        //                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                        Title = reader.GetString(reader.GetOrdinal("Title")),
        //                        Provider = reader.GetString(reader.GetOrdinal("Provider")),
        //                        ImageURL = reader.GetString(reader.GetOrdinal("ImageURL")),
        //                        OutOfPocket = reader.GetDecimal(reader.GetOrdinal("OutofPocket")),
        //                        IsArchived = reader.GetBoolean(reader.GetOrdinal("IsArchived")),


        //                    };
        //                    patientBills.Add(patientBill);
        //                }
        //                return patientBills;
        //            }
        //        }
        //    }
        //}


    }
}
