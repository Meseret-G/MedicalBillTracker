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

        // Create new patient
        // GET: PatientController 

        [HttpPost]
        public ActionResult PostPatient(Patient newpatient)
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
        public ActionResult GetPatientByFirebaseId(string firebaseKeyId)
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




        [Authorize]
        [HttpGet("Auth")]
       
        public async Task<IActionResult> PostAsync([FromHeader] string idToken)

        {
            
            //string uid = User.FindFirst(claim => claim.Type == "user_id").Value;
                FirebaseToken decoded = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                var token = User.FindFirst(Claim => Claim.Type == "user_id");
                var uid = decoded.Uid;
                bool patientexists = _patientRepo.PatientExists(uid);
            if (!patientexists)
            {
                Patient userFromToken = new Patient()
                {
                    Name = (string)decoded.Claims.GetValueOrDefault("name"),
                    Email = (string)decoded.Claims.GetValueOrDefault("email"),
                    FirebaseKeyId = uid,
                };

                int patientId = _patientRepo.CreatePatient(userFromToken);
                return Ok($"Customer Created ID={patientId}");

            }
            return Ok("Customer Exists");

        }
        //        Patient patientFromToken = new Patient()
        //        {
        //            Name = User.Identity.Name,
        //            FirebaseKeyId = uid,
        //        };

        //     _patientRepo.CreatePatient(patientFromToken);
        //        return Ok();

        //    }
        //    Patient existingPatient = _patientRepo.GetPatientByFirebaseKeyId(uid);
        //    return Ok(existingPatient);

        //}

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
      



    

