using DTO;
using Gestor;
using System.Linq;
using System.Web.Mvc;

using WebMVC.FactorABMCServicio;

namespace WebMVC.Controllers
{
    public class FactorController : Controller
    {
        //private FactorGestor factorGestor = new FactorGestor();
        private FactorServicioClient factorServicio = new FactorServicioClient();

        //
        // GET: /Factor/
        public ActionResult Index()
        {
            return this.View(factorServicio.Listar().ToList());
            //return this.View(this.factorGestor.Listar().ToList());
        }

        //
        // GET: /Factor/Details/5
        public ActionResult Details(int id)
        {
            //var factor = this.factorGestor.GetById(id);
            var factor = this.factorServicio.GetById(id);
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
        public ActionResult Create(Factor factor)
        {
            try
            {
                //this.factorGestor.Guardar(factor);

                this.factorServicio.Guardar(factor);
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
            //var factor = this.factorGestor.GetById(id);

            var factor = this.factorServicio.GetById(id);
            return View(factor);
        }

        //
        // POST: /Factor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Factor factor)
        {
            try
            {
                //this.factorGestor.Guardar(factor);

                this.factorServicio.Guardar(factor);
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
            //var factor = this.factorGestor.GetById(id);
            var factor = this.factorServicio.GetById(id);
            return View(factor);
        }

        //
        // POST: /Factor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Factor factor)
        {
            try
            {
                // TODO: Add delete logic here
                //this.factorGestor.Eliminar(factor);
                this.factorServicio.Eliminar(factor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
