using DTO;
using Gestor;
using System.Linq;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class FactorController : Controller
    {
        private FactorGestor factorGestor = new FactorGestor();

        //
        // GET: /Factor/
        public ActionResult Index()
        {
            return this.View(this.factorGestor.Listar().ToList());
        }

        //
        // GET: /Factor/Details/5
        public ActionResult Details(int id)
        {
            var factor = this.factorGestor.GetById(id);
            return View(factor);
        }

        //
        // GET: /Factor/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Factor/Create
        [HttpPost]
        public ActionResult Create(FactorDTO factorDto)
        {
            try
            {
                this.factorGestor.Guardar(factorDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Factor/Edit/5
        public ActionResult Edit(int id)
        {
            var factor = this.factorGestor.GetById(id);
            return View(factor);
        }

        //
        // POST: /Factor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FactorDTO factorDto)
        {
            try
            {
                // TODO: Add update logic here
                this.factorGestor.Guardar(factorDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Factor/Delete/5
        public ActionResult Delete(int id)
        {
            var factor = this.factorGestor.GetById(id);
            return View(factor);
        }

        //
        // POST: /Factor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FactorDTO factorDto)
        {
            try
            {
                // TODO: Add delete logic here
                this.factorGestor.Eliminar(factorDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
