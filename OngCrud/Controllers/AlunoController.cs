using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OngCrud.Models;

namespace OngCrud.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Curso()
        {
            return View();
        }
        
        
        public ActionResult CursoDados()
        {
            // Retorna os dados da tabela Cursos, a partir do model criado pelo Entity Framework
            using (DBModel db = new DBModel())
            {
                List<Curso> funcList = db.Cursos.ToList<Curso>();
                return Json(new { data = funcList }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Grade()
        {
            return View();
        }

        public ActionResult Nota()
        {
            return View();
        }

        public ActionResult Tarefa()
        {
            return View();
        }
    }
}