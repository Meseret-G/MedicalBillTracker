
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

        // Create new patient
        // GET: PatientController 

        [HttpPost]
        public IActionResult PostPatient(Patient newpatient)
        {
            if (newpatient == null)
            {
                return NotFound();
            }
            else
            {
                _patientRepo.CreatePatient(newpatient);
                return Ok(newpatient);
            }
        }

        // Get a Patient by their firebaseKey  

        // GET api/<PatientController>/5
        [HttpGet("Patient/{firebaseKeyId}")]
        public ActionResult GetPatientByFirebaseKeyId(string firebaseKeyId)
        {
            Patient patient = _patientRepo.GetPatientByFirebaseKeyId(firebaseKeyId);

            if (patient == null)
            {

                return NotFound();
            }
            else
            {
                return Ok(patient);
            }
        }

//Authentication 
       [Authorize]   
        [HttpGet("Auth")]
        public async Task<IActionResult> GetUserAuthStatus()
        {
            string uid = User.FindFirst(claim => claim.Type == "user_id").Value;
            bool patientexists = _patientRepo.CheckPatientExists(uid);
            if (!patientexists)
            {
                Patient userFromToken = new Patient()
                {
                    Name = User.Identity.Name,
                    FirebaseKeyId = uid,
                };

                _patientRepo.CreatePatient(userFromToken);
                return Ok();
            }
            Patient patientExists = _patientRepo.GetPatientByFirebaseKeyId(uid);
            return Ok(patientExists);
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

    }
}
      



    

