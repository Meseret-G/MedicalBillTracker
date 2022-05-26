using FirebaseAdmin.Auth;
using MedicalBillTracker.Models;
using MedicalBillTracker.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBillTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientRepo _patientRepo;

        public PatientController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        // GET: PatientController

        [HttpPost]
        public IActionResult PostPatient([FromBody] Patient newPatient)
        {
            if (newPatient == null)
            {
                return NotFound();
            }
            else
            {
                _patientRepo.CreatePatient(newPatient);
                return Ok(newPatient);
            }
        }
        // GET api/<PatientController>/Email/5
        [HttpGet("Email/{email}")]
        public IActionResult GetPatientByEmail(string email)
        {
            Patient patient = _patientRepo.GetPatientByEmail(email);

            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // GET api/<PatientController>/5
        [HttpGet("UID/{uid}")]
        public IActionResult GetPatientByUID(string uid)
        {
            Patient patient = _patientRepo.GetPatientByUID(uid);

            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
       
        [Authorize]
        [HttpGet("Auth")]
        public async Task<IActionResult> PostAsync([FromHeader] string idToken)
        {
            FirebaseToken decoded = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
            var token = User.FindFirst(Claim => Claim.Type == "user_id");
            var uid = decoded.Uid;
            bool patientExists = _patientRepo.PatientExists(uid);
            if (!patientExists)
            {
                Patient userFromToken = new Patient()
                {
                    Name = (string)decoded.Claims.GetValueOrDefault("name"),
                    Email = (string)decoded.Claims.GetValueOrDefault("email"),
                    UID = uid,
                };

                int patientId = _patientRepo.CreatePatient(userFromToken);
                return Ok($"Patient Created ID={patientId}");

            }
            return Ok("Patient Exists");

        }

    }
}
      



    

