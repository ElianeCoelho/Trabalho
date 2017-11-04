using System;
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
    public class ProdutoController : Controller
    {
        private eatfitdados2Entities db = new eatfitdados2Entities();

        // GET: Produto
        public ActionResult Index()
        {
            var produto = db.Produto.Include(p => p.Categoria).Include(p => p.Fornecedor);
            return View(produto.ToList());
        }


        public ActionResult UploadImagem()
        {
            return View();
        }





        [HttpPost]
        public ActionResult UploadImagem(HttpPostedFileBase arquivo)
        {

            if(arquivo == null)
            {

                ViewBag.MsgError = "Selecione um arquivo";
                return RedirectToAction("Index");
            }
            var extenssao = System.IO.Path.GetExtension(arquivo.FileName);
            if(extenssao.Equals(".png", StringComparison.CurrentCultureIgnoreCase)
                ||extenssao.Equals(".gif", StringComparison.CurrentCultureIgnoreCase)
                                || extenssao.Equals(".jpg", StringComparison.CurrentCultureIgnoreCase))
            {
                var nomeUnico = String.Format("{0}_{1}{2}", System.IO.Path.GetFileNameWithoutExtension(arquivo.FileName),
                    DateTime.Now.Ticks, extenssao);

                var nomeUnicoTeste = nomeUnico;
                arquivo.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Arquivos"), nomeUnico));
                ViewBag.Message = "Arquivo Carregado com sucesso!";


            }
            else
            {
                ViewBag.Message = "Somente Imagens Formato PNG, JPG e GIF são permitidos";
            }

                return View();
        }






            // GET: Produto/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "DescriçãoCategoria");
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "IdFornecedor", "Nome");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduto,NomeProduto,DescricaoProduto,ValorProduto,IdCategoria,IdFornecedor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "DescriçãoCategoria", produto.IdCategoria);
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "IdFornecedor", "Nome", produto.IdFornecedor);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "DescriçãoCategoria", produto.IdCategoria);
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "IdFornecedor", "Nome", produto.IdFornecedor);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduto,NomeProduto,DescricaoProduto,ValorProduto,IdCategoria,IdFornecedor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "DescriçãoCategoria", produto.IdCategoria);
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "IdFornecedor", "Nome", produto.IdFornecedor);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produto.Find(id);
            db.Produto.Remove(produto);
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
