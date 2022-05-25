using MedicalBillTracker.Models;
using MedicalBillTracker.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBillTracker.Controllers
{
    public class ArchiveController : Controller
    {
      
        private readonly IArchiveRepo _archiveRepo;

        public ArchiveController(IArchiveRepo archiveRepo)
        {
            _archiveRepo = archiveRepo;
         
        }

        // GET: ArchiveController/ Need to be fixed after authentication
        //[HttpGet("Patient")]
        //public IActionResult GetArchiveByUID()
        //{
        //    List<Archive>? patientArchives = _archiveRepo.GetAllArchivesByUID();
        //    if (patientArchives == null) return NotFound();
        //    return Ok(patientArchives);
        //}

       
        

    
       
        

    
        // POST: ArchiveController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
