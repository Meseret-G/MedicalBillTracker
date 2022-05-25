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
        public List<Archive> GetAllArchives()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, 
                               PatientId, 
                               IsOpen
                        FROM [Archive]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Archive> archives = new List<Archive>();
                        while (reader.Read())
                        {
                            Archive archive = new Archive()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                PatientId = reader.GetString(reader.GetOrdinal("PatientId")),
                                IsOpen = reader.GetBoolean(reader.GetOrdinal("IsOpen")),
                            };
                            archives.Add(archive);
                        }
                        return archives;
                    }
                }
            }
        }
                public List<Archive> GetAllArchivesByUID(string uid)
                {
                    using (SqlConnection conn = Connection)
                    {
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = @"
                                        Select *
                                        FROM [Archive]
                                        WHERE PatientId = @uid
                                      ";
                            cmd.Parameters.AddWithValue("@uid", uid);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                List<Archive> patientArchives = new List<Archive>();
                                while (reader.Read())
                                {
                                    Archive patientArchive = new Archive()
                                    {
                                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                        PatientId = reader.GetString(reader.GetOrdinal("PatientId")),
                                        IsOpen = reader.GetBoolean(reader.GetOrdinal("IsOpen")),
                                    };
                                    patientArchives.Add(patientArchive);
                                }
                                return patientArchives;
                            }
                        }
                    }
                }


            }
        }
    

