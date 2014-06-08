using System.Linq;
using System.Web.Mvc;

using Gestor;

namespace MVC.Controllers
{
    public class FactorController : Controller
    {
        //private Contexto db = new Contexto();

        private FactorGestor factorGestor = new FactorGestor();

        // GET: /Factor/
        public ActionResult Index()
        {
            return this.View(this.factorGestor.Listar().ToList());
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }*/
    }
}