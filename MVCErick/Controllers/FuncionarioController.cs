using MVCErick.Data;
using MVCErick.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCErick.Controllers
{
    public class FuncionarioController : Controller
    {

        readonly private ApplicationDBContext _dbContext = new ApplicationDBContext();

        public FuncionarioController(ApplicationDBContext db)
        {
            _dbContext = db;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(_dbContext.Usuarios.ToList());
        }

        // GET:DETAILS Criando Aba de Detalhes 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModels usuarioModels = _dbContext.Usuarios.Find(id);
            if (usuarioModels == null)
            {
                return HttpNotFound();
            }
            return View(usuarioModels);
        }

        //Get:Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post:Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,CPF,Endereco,Telefone")] UsuarioModels usuarioModels)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Usuarios.Add(usuarioModels);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarioModels);
        }

        //GET:Usuarios/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,CPF,Endereco,Telefone")] UsuarioModels usuarioModels)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(usuarioModels).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarioModels);
        }


        //DELETE:Usuarios
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModels usuarioModels= _dbContext.Usuarios.Find(id);
            if (usuarioModels == null)
            {
                return HttpNotFound();
            }
            return View(usuarioModels);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioModels usuarioModels = _dbContext.Usuarios.Find(id);
            _dbContext.Usuarios.Remove(usuarioModels);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}