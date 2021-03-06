﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eattofit;

namespace eattofit.Controllers
{
    public class CartaoController : Controller
    {
        private eatfitdados2Entities db = new eatfitdados2Entities();

        // GET: Cartao
        public ActionResult Index()
        {



            if (Session["IdFornecedor"] != null)
            {

                var cartao = db.Cartao.Include(c => c.Fornecedor);
                return View(cartao.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Fornecedor");
            }

        }

        // GET: Cartao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = db.Cartao.Find(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            return View(cartao);
        }

        // GET: Cartao/Create
        public ActionResult Create()
        {
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "IdFornecedor", "Nome");
            return View();
        }

        // POST: Cartao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCartao,Bandeira,ImagemUrl,IdFornecedor")] Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                db.Cartao.Add(cartao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "IdFornecedor", "Nome", cartao.IdFornecedor);
            return View(cartao);
        }

        // GET: Cartao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = db.Cartao.Find(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "IdFornecedor", "Nome", cartao.IdFornecedor);
            return View(cartao);
        }

        // POST: Cartao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCartao,Bandeira,ImagemUrl,IdFornecedor")] Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "IdFornecedor", "Nome", cartao.IdFornecedor);
            return View(cartao);
        }

        // GET: Cartao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = db.Cartao.Find(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            return View(cartao);
        }

        // POST: Cartao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cartao cartao = db.Cartao.Find(id);
            db.Cartao.Remove(cartao);
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
