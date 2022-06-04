using MedicalBillTracker.Models;
using MedicalBillTracker.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBillTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveController : Controller
    {
        private readonly IArchiveRepo _archiveRepo;
        public ArchiveController(IArchiveRepo archiveRepo)
        {
            _archiveRepo = archiveRepo;
        }
        // POST: ArchiveController
// Add to Archive
        [HttpPost("{id}")]
        public IActionResult Post(string id)
        {
            var billId = int.Parse(id);
            _archiveRepo.ArchiveBills(billId);
            return Ok(billId);
        }
        // GET: all archived bills
        [HttpGet]
        public List<Bill> Get()
        {
            return _archiveRepo.GetArchiveBills();
        }
 
       // POST: ArchiveController/Create
      
        // GET: ArchiveController/Edit/5
        
    }
}
