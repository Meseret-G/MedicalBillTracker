using MedicalBillTracker.Models;
using System.Data.SqlClient;

namespace MedicalBillTracker.Repos
{
    public class PatientRepo : IPatientRepo
    {
        private readonly IConfiguration _config;

        public PatientRepo(IConfiguration config)
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
        public void CreatePatient(Patient patient)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO Patient ([Name], Email)
                                        OUTPUT INSERTED.Id
                                        VALUES (@name,  @email)
                                        ";
                    cmd.Parameters.AddWithValue("@name", patient.Name);
                    cmd.Parameters.AddWithValue("@email", patient.Email);
                    //cmd.Parameters.AddWithValue("@firebaseKeyId", patient.FirebaseKeyId);

                    int id = (int)cmd.ExecuteScalar();
                    patient.Id = id;
                 
                }
            }
        }

        public Patient GetPatientByEmail(string email)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT * FROM Patient
                                        WHERE Email = @email
                                        ";
                    cmd.Parameters.AddWithValue("@email", email);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Patient patient = new Patient
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            FirebaseKeyId = reader.GetString(reader.GetOrdinal("FirebaseKeyId")),
                        };
                        return patient;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public Patient GetPatientByFirebaseKeyId(string firebaseKeyId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT * FROM Patient
                                        WHERE FirebaseKeyId = @firebaseKeyId
                                        ";
                    cmd.Parameters.AddWithValue("@firebaseKeyId", firebaseKeyId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Patient patient = new Patient
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            FirebaseKeyId = reader.GetString(reader.GetOrdinal("FirebaseKeyId")),
                        };
                        return patient;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public bool CheckPatientExists(string firebaseKeyId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT Id, [Name], Email, FirebaseKeyID FROM Patient
                                        WHERE FirebaseKeyId = @firebaseKeyId
                                        ";
                    cmd.Parameters.AddWithValue("@firebaseKeyId", firebaseKeyId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
            }
        }


    }
}
