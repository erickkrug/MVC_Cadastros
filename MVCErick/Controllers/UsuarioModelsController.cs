using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCErick.Data;
using MVCErick.Models;

namespace MVCErick.Controllers
{
    public class UsuarioModelsController : Controller
    { 
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: UsuarioModels
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Empresa);
            return View(usuarios.ToList());
        }

        // GET: UsuarioModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModels usuarioModels = db.Usuarios.Find(id);
            if (usuarioModels == null)
            {
                return HttpNotFound();
            }
            return View(usuarioModels);
        }

        // GET: UsuarioModels/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresas, "ID", "NomeEmpresa");
            return View();
        }

        // POST: UsuarioModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,CPF,Endereco,Telefone,EmpresaId")] UsuarioModels usuarioModels)
        {
            // Fazer o replace dos dados para virem pelados para o banco de dados >.<
            usuarioModels.CPF = usuarioModels.CPF.Replace(".", "").Replace("-", "");
            usuarioModels.Telefone = usuarioModels.Telefone.Replace("(", "").Replace(")", "").Replace("-","");

            // Fazer a validação de CPF aqui ;3
            if (db.Usuarios.Any(u => u.CPF == usuarioModels.CPF))
            {
                ModelState.AddModelError("CPF", "O CPF informado já existe em nosso banco de dados");
            }

            // Validação numero de telefone né pai.
            if(db.Usuarios.Any(u => u.Telefone == usuarioModels.Telefone))
            {
                ModelState.AddModelError("Telefone", "O numero de telefone inserido já está cadastrado no nosso sistema, verifique seu numero de telefone! o.0");
            }


            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarioModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(db.Empresas, "ID", "NomeEmpresa", usuarioModels.EmpresaId);
            return View(usuarioModels);
        }

        // GET: UsuarioModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModels usuarioModels = db.Usuarios.Find(id);
            if (usuarioModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "ID", "NomeEmpresa", usuarioModels.EmpresaId);
            return View(usuarioModels);
        }

        // POST: UsuarioModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,CPF,Endereco,Telefone,EmpresaId")] UsuarioModels usuarioModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "ID", "NomeEmpresa", usuarioModels.EmpresaId);
            return View(usuarioModels);
        }

        // GET: UsuarioModels/Delete/5
        
        [HttpPost, ActionName("Delete")]
        public JsonResult Delete(int? id)
        {
           
            UsuarioModels usuarioModels = db.Usuarios.Find(id);
            
           
            db.Usuarios.Remove(usuarioModels);
            db.SaveChanges();
            
            return Json(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
