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
    public class EmpresaController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Empresa
        public ActionResult Index()
        {
            return View(db.Empresas.ToList());
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaModels empresaModels = db.Empresas.Find(id);
            if (empresaModels == null)
            {
                return HttpNotFound();
            }
            return View(empresaModels);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NomeEmpresa,DescricaoEmpresa,Localidade,CNPJ,DataCriacao")] EmpresaModels empresaModels)
        {
            if (ModelState.IsValid)
            {
                db.Empresas.Add(empresaModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresaModels);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaModels empresaModels = db.Empresas.Find(id);
            if (empresaModels == null)
            {
                return HttpNotFound();
            }
            return View(empresaModels);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NomeEmpresa,DescricaoEmpresa,Localidade,CNPJ,DataCriacao")] EmpresaModels empresaModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresaModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresaModels);
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaModels empresaModels = db.Empresas.Find(id);
            if (empresaModels == null)
            {
                return HttpNotFound();
            }
            return View(empresaModels);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpresaModels empresaModels = db.Empresas.Find(id);
            db.Empresas.Remove(empresaModels);
            db.SaveChanges();
            return RedirectToAction("Index");
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
