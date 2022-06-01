
using MedicalBillTracker.Models;
using MedicalBillTracker.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBillTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveItemController : Controller
    {
       
        private readonly IArchiveItemRepo _archiveItemRepo;
     
        public ArchiveItemController(IArchiveItemRepo archiveItemRepo)
        {
            _archiveItemRepo = archiveItemRepo;
          
        }



        // GET: api/<AllArchiveItems>
        //[HttpGet]
        //public IActionResult GetAllEvents()
        //{
        //    List<ArchiveItem> archives = _archiveItemRepo.GetAllArchives();
        //    if (archives == null) return NotFound();
        //    return Ok(archives);
        //}

        // GET: api/Archive
        [HttpGet]
        public List<Bill> GetAllArchives(int patientId)
        {
            return _archiveItemRepo.GetAllPatientArchives(patientId);
        }

        // DELETE: api/Archive/Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_archiveItemRepo.BillExistInArchive(id))
            {
                return NotFound();
            }
            else
            {
                _archiveItemRepo.RemoveFromArchive(id);
                return NoContent();
            }
        }

        // POST: api/Archive 

        [HttpPost("{id}")]
        public IActionResult Post(string id)
        {
            var billId = int.Parse(id);
            _archiveItemRepo.AddToArchive(billId);
            return Ok(billId);
        }


    }
}
