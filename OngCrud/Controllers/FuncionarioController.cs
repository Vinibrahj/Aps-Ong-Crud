using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OngCrud.Models;

namespace OngCrud.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Funcionario> funcList = db.Funcionarios.ToList<Funcionario>();
                return Json(new { data = funcList }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new Funcionario());
        }

        [HttpPost]
        public ActionResult AddOrEdit(Funcionario fnc)
        {
            using (DBModel db = new DBModel())
            {
                db.Funcionarios.Add(fnc);
                db.SaveChanges();
                return Json(new { success = true, message = "Salvo com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}