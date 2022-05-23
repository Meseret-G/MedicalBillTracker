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
            var bill = _billRepo.GetById(id);
            if (bill == null) return NotFound();
            return Ok(bill);
        }

        // POST api/<BillController>

        [HttpPost]
        public IActionResult PostBill([FromBody] Bill newBill)
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

    }
}
