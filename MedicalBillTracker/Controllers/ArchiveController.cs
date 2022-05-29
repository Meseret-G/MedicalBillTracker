
using MedicalBillTracker.Models;
using MedicalBillTracker.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBillTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveController : Controller
    {
        private readonly IArchiveItemRepo _archiveItemRepo;
        private readonly IArchiveRepo _archiveRepo;
     



        public ArchiveController(IArchiveRepo archiveRepo, IArchiveItemRepo archiveItemRepo)
        {
            _archiveRepo = archiveRepo;
            _archiveItemRepo = archiveItemRepo;


        }

        //[Authorize]
        //[HttpPost("Add")]
        //public IActionResult AddForReview([FromBody] ArchiveItem item)
        //{
        //    var uid = User.FindFirst(Claim => Claim.Type == "user_id").Value.ToString();
        //    var archive = _archiveRepo.GetOpenArchiveByFirebaseKeyId(id);
        //    if (archive == null)
        //    {
        //        int id = _archiveRepo.AddNewArchive(uid);
        //        item.ArchiveId = id;
        //        _archiveItemRepo.AddArchiveItem(item);
        //        return Ok(item);

        //    }
        //    else
        //    {
        //        item.ArchiveId = archive.Id;
        //        ArchiveItem? existingItem = _archiveItemRepo.ArchiveItemExists(item.BillId, item.ArchiveId);
        //        if (existingItem == null)
        //        {
        //            _archiveItemRepo.AddArchiveItem(item);
        //            return Ok(item);
        //        }
        //        else
        //        {
        //            return Ok(existingItem);
        //        }

        //    }
        //}


        //// GET: api/<ArchiveController>/Review

        //[Authorize]
        //[HttpGet("Review")]
        //public IActionResult GetReview()
        //{
        //    //var uid = User.FindFirst( "user_id").Value.ToString();
        //    var archive = _archiveRepo.GetOpenArchiveByFirebaseKeyId(patientId);
        //    if (archive != null)
        //    {
        //        var archiveId = archive.Id;
        //        Review review = new Review()
        //        {
        //            ReviewItems = _archiveItemRepo.GetAllItemsByArchiveId(archiveId),
        //            ReviewId = archive.Id
        //        };

        //        return Ok(review);
        //    }
        //    else
        //    {
        //        int newArchiveId = _archiveRepo.AddNewArchive(patientId);
        //        Review reivew = new Review()
        //        {
        //            ReviewItems = new List<Bill>(),
        //            ReviewId = newArchiveId
        //        };

        //        return Ok(reivew);
        //    }
        //}



        // GET: ArchiveController/Patient/UID
        //[Authorize]
        //[HttpGet("Patient")]
        //public IActionResult GetArchiveByFirebaseKeyId()
        //{
        //    var uid = User.FindFirst(Claim => Claim.Type == "user_id").Value.ToString();
        //    List<Archive>? patientArchives = _archiveRepo.GetAllArchivesByFirebaseKeyId(uid);
        //    if (patientArchives == null) return NotFound();
        //    return Ok(patientArchives);
        //}



       // [Authorize]
        // GET api/<ArchiveController>/5
        [HttpGet("Close/{id}")]
        public IActionResult CloseArchive(int id)
        {
            try
            {
                _archiveRepo.CloseArchive(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }



        // DELETE api/<OrderController>/5
        //[Authorize]
        [HttpDelete("DeleteReviewItem/{id}")]
        public void Delete(int id)
        {
            _archiveItemRepo.DeleteArchiveItem(id);
        }
    }
}
