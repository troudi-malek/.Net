using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class InfirmierController : Controller
    {
        readonly IService<Infirmier> InfirmierService;
        public InfirmierController(IService<Infirmier> InfirmierService)
        {
            this.InfirmierService = InfirmierService;
        }
        // GET: InfirmierController
        public ActionResult Index()
        {
            return View(InfirmierService.GetAll());
        }

        // GET: InfirmierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InfirmierController/Create
        public ActionResult Create()
        {
            var data = InfirmierService.GetAll();
            ViewBag.CodeInfirmier = new SelectList(data, "CodeInfirmier", "Infirmier.specialite");
            ViewBag.CodePatient = new SelectList(data, "CodePatient", "Infirmier.Laboratoire.Intitule");
            return View();
        }

        // POST: InfirmierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,Infirmier infirmier)
        {
            try
            {
                InfirmierService.Add(infirmier);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InfirmierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InfirmierController/Edit/5
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

        // GET: InfirmierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InfirmierController/Delete/5
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
