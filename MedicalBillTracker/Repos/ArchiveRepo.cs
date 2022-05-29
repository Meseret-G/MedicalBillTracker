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
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                IsOpen = reader.GetBoolean(reader.GetOrdinal("IsOpen")),
                            };
                            archives.Add(archive);
                        }
                        return archives;
                    }
                }
            }
        }
                public List<Archive> GetAllArchivesByFirebaseKeyId(int patientId)
                {
                    using (SqlConnection conn = Connection)
                    {
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = @"
                                        Select *
                                        FROM [Archive]
                                        WHERE PatientId = @firebaseKeyId
                                      ";
                            cmd.Parameters.AddWithValue("@firebaseKeyId", patientId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                List<Archive> patientArchives = new List<Archive>();
                                while (reader.Read())
                                {
                                    Archive patientArchive = new Archive()
                                    {
                                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                        PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                        IsOpen = reader.GetBoolean(reader.GetOrdinal("IsOpen")),
                                        //FirebaseKeyId = reader.GetString(reader.GetOrdinal(" FirebaseKeyId")),
                                    };
                                    patientArchives.Add(patientArchive);
                                }
                                return patientArchives;
                            }
                        }
                    }
                }

        public int AddNewArchive(int patientId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO [Archive]
                                        (PatientId, IsOpen)
                                        OUTPUT INSERTED.ID
                                        VALUES (@patientId, @isOpen)
                                        ";
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.Parameters.AddWithValue("@isOpen", true);

                    int id = (int)cmd.ExecuteScalar();

                    return id;
                }
            }
        }

        public Archive GetOpenArchiveByFirebaseKeyId(int patientId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        Select Id, PatientId, IsOpen
                                        FROM [Archive]
                                        WHERE PatientId = @firebaseKeyId AND isOpen = 1
                                      ";
                    cmd.Parameters.AddWithValue("@firebaseKeyId", patientId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Archive patientArchive = new Archive()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                IsOpen = reader.GetBoolean(reader.GetOrdinal("IsOpen")),
                            };
                            return patientArchive;
                        }
                        return null;
                    }
                }
            }
        }
        public void CloseArchive(int archiveId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE [Archive]
                        SET isOpen = 0
                        WHERE Id = @archiveId";

                    cmd.Parameters.AddWithValue("@archiveId", archiveId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
    

