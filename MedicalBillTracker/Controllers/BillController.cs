using MedicalBillTracker.Models;
using MedicalBillTracker.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBillTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : Controller
    {
        private readonly IBillRepo _billRepo;

        public BillController(IBillRepo billRepo)
        {
            _billRepo = billRepo;
        }

        // GET: BillController
        [HttpGet]
        public IActionResult Index()
        {
            List<Bill> bills = _billRepo.GetAll();
            if (bills == null) return NotFound();
            return Ok(bills);
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bill = _billRepo.GetBillById(id);
            if (bill == null) return NotFound();
            return Ok(bill);
        }

        // POST api/<BillController>
        [HttpPost]
        public IActionResult PostBill( Bill newBill)
        {
            if (newBill == null)
            {
                return NotFound();
            }
            else
            {
                _billRepo.AddBill(newBill);
                return Ok(newBill);
            }
        }

        // PATCH: api/<BillController>/Edit/5
        [HttpPut("Edit/{id}")]
        public IActionResult UpdateBill(int id, [FromBody] Bill billObj)
        {
            try
            {
                _billRepo.UpdateBill(id, billObj);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // DELETE api/<BillController>/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            _billRepo.DeleteBill(id);

        }

        //// Archieving Methods
        [HttpPut("Archive/{billId}")]
        public IActionResult ArchiveBill(int billId, [FromBody] Bill bill)
        {
            //editing exiting bill property (isArchived) to true
            try
            {
                _billRepo.ArchiveBill(billId,bill);
                return Ok();
            }
            catch
            {
             return BadRequest();   
            }
           
        }


        [HttpGet("Archive")]
        public List<Bill> Get()
        {
            return _billRepo.GetArchiveBills();
        }

        [HttpDelete("Archive/Delete/{id}")]
        public void DeleteBillFromArchive(int id)
        {
            _billRepo.DeleteArchiveBill(id);

        }

        // http put/ArchiveBill (bill id)
        // call repo to archive bill(billId)
        // update isarchived to true


        //[HttpGet(/"PatientArchive")]
        //public IActionResult GetUsersArchiveBills()
        //{
        ////    // return all their archived bills (isAchieved == true)
        //var userArchive = _billRepo.GetArchivedBills();
        //    if (userArchive != null)
        //    {
        //        return Ok(userArchive);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

    }
}
