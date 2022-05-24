using MedicalBillTracker.Models;
using MedicalBillTracker.Repos;
using Microsoft.AspNetCore.Http;
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


    }
}
