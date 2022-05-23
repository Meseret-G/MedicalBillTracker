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
        // GET api/<PaperController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bill = _billRepo.GetById(id);
            if (bill == null) return NotFound();
            return Ok(bill);
        }


        // GET: BillController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //GET: BillController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: BillController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        // public ActionResult Create(IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }

        //GET: BillController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //POST: BillController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: BillController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: BillController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
