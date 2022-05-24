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

    }
}
