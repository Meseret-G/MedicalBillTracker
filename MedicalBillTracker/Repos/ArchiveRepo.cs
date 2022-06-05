//using MedicalBillTracker.Models;
//using System.Data.SqlClient;

//namespace MedicalBillTracker.Repos
//{
//    public class ArchiveRepo : IArchiveRepo     
//    {
//        private readonly IConfiguration _config;

//        public ArchiveRepo(IConfiguration config)
//        {
//            _config = config;
//        }

//        public SqlConnection Connection
//        {
//            get
//            {
//                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
//            }
//        }


//        public void ArchiveBills(int Id)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                        INSERT INTO Archive (Id)
//                        VALUES (@id);
//                     ";

//                    cmd.Parameters.AddWithValue("@id", Id);

//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }


   


//    }
//}
