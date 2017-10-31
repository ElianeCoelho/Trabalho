﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eattofit;
using System.Web.Security;

namespace eattofit.Controllers
{
    public class FornecedorController : Controller
    {
        private eatfitdados2Entities db = new eatfitdados2Entities();

        // GET: Fornecedor
        // GET: Fornecedor
        public ActionResult Index()
        {

            if (Session["IdFornecedor"] != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        public ActionResult Login()
        {
            return View();
        }


        //ValidaLogin
        [HttpPost]
        public ActionResult Login(Fornecedor fornecedor)
        {
            using (eatfitdados2Entities db = new eatfitdados2Entities())
            {
                var fornec = db.Fornecedor.Single(f => f.Email == fornecedor.Email && f.Senha == fornecedor.Senha);
                if (fornec != null)
                {
                    Session["IdFornecedor"] = fornec.IdFornecedor.ToString();
                    Session["Email"] = fornec.Nome.ToString();

                    return RedirectToAction("Index");

                }
                else
                {


                    ModelState.AddModelError("", "Email ou Senha Incorreto.");
                }
            }
            return View();
        }





        // GET: Fornecedor
        public ActionResult ListaFornecedor()
        {
            return View(db.Fornecedor.ToList());
        }


        public ActionResult EncerrarSessao()
        {

            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }



        // GET: Fornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            ViewBag.IdEndereco = new SelectList(db.Endereco, "IdEndereco", "Rua");
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFornecedor,Nome,Cpf,Cnpj,Telefone,RazaoSocial,Email,Senha,ConfirmaSenha,IdEndereco")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Fornecedor.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Create", "Endereco", new {IdFornecedor = fornecedor.IdFornecedor});
            }

            ViewBag.IdEndereco = new SelectList(db.Endereco, "IdEndereco", "Rua", fornecedor.IdEndereco);
            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEndereco = new SelectList(db.Endereco, "IdEndereco", "Rua", fornecedor.IdEndereco);
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFornecedor,Nome,Cpf,Cnpj,Telefone,RazaoSocial,Email,Senha,ConfirmaSenha,IdEndereco")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEndereco = new SelectList(db.Endereco, "IdEndereco", "Rua", fornecedor.IdEndereco);
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            db.Fornecedor.Remove(fornecedor);
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