using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            if(id==0)
            return View(new Funcionario());
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Funcionarios.Where(x => x.FuncID==id).FirstOrDefault<Funcionario>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Funcionario fnc)
        {
            using (DBModel db = new DBModel())
            {
                if(fnc.FuncID == 0)
                { 
                db.Funcionarios.Add(fnc);
                db.SaveChanges();
                return Json(new { success = true, message = "Salvo com sucesso!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(fnc).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Atualizado com sucesso!" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using(DBModel db = new DBModel())
            {
                Funcionario fnc = db.Funcionarios.Where(x => x.FuncID == id).FirstOrDefault<Funcionario>();
                db.Funcionarios.Remove(fnc);
                db.SaveChanges();
                return Json(new { success = true, message = "Deletado com sucesso" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}