using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBillTracker.Controllers
{
    public class ArchiveController : Controller
    {
        // GET: ArchiveController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArchiveController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArchiveController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArchiveController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ArchiveController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArchiveController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ArchiveController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

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
