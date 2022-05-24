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
        public int CreatePatient(Patient patient)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO Patient ([Name], Email, [UID])
                                        OUTPUT INSERTED.Id
                                        VALUES (@name, @email, @uid)
                                        ";
                    cmd.Parameters.AddWithValue("@name", patient.Name);
                    cmd.Parameters.AddWithValue("@email", patient.Email);
                    cmd.Parameters.AddWithValue("@uid", patient.UID);

                    int id = (int)cmd.ExecuteScalar();

                    return id;
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
                            UID = reader.GetString(reader.GetOrdinal("UID")),
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


    }
}
