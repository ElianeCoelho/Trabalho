using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using PagedList;
using System.Web.Mvc;

namespace eattofit.Controllers
{
    public class ProdutoController : Controller
    {
        private eatfitdados2Entities db = new eatfitdados2Entities();

        // GET: Produto
        //public ActionResult Index()
        //{
        //    var produto = db.Produto.Include(p => p.Categoria).Include(p => p.Fornecedor);
        //    return View(produto.ToList());
        //}

        public ActionResult Index(String sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NomeParam = String.IsNullOrEmpty(sortOrder) ? "NomeProduto" : "";
            ViewBag.DescricaoParam = String.IsNullOrEmpty(sortOrder) ? "Descricao" : "";
            ViewBag.ValorParam = String.IsNullOrEmpty(sortOrder) ? "Valor" : "";
            ViewBag.CategoriaParam = String.IsNullOrEmpty(sortOrder) ? "Categoria" : "";

            if (searchString != null)
            {
                page = 1;

            }
            else
            {
                searchString = currentFilter;

            }

            ViewBag.CurrentFilter = searchString;

            var produtos = from s in db.Produto select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                produtos = produtos.Where(s => s.NomeProduto.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "NomeProduto":
                    produtos = produtos.OrderByDescending(s => s.NomeProduto);

                    break;

                case "Categoria":
                    produtos = produtos.OrderByDescending(s => s.Categoria);

                    break;

                default:
                    produtos = produtos.OrderBy(s => s.NomeProduto);
                    break;

            }

            int quantidadePorPagina = 3;
            int numeroPagina = (page ?? 1);
            return View(produtos.ToPagedList(numeroPagina, quantidadePorPagina));

        }



        public ActionResult UploadImagem()
        {
            return View();
        }





        //[HttpPost]
        //public async Task<ActionResult> UploadImagem(HttpPostedFileBase file)
        //{
        //    if (file != null && file.ContentLength > 0)
        //    {
        //        var user = await GetCurrentUserAsync();
        //        var username = user.UserName;
        //        var fileExt = Path.GetExtension(file.FileName);
        //        var fnm = username + ".png";


        //        if (fileExt.ToLower().EndsWith(".png") || fileExt.ToLower().EndsWith(".jpg") || fileExt.ToLower().EndsWith(".gif"))
        //        {

        //            var filePath = HostingEnvironment.MapPath("~/Content/foto") + fnm;
        //            var diretorio = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/foto"));
        //            if (diretorio.Exists == false)
        //            {
        //                diretorio.Create();
        //            }
        //            ViewBag.FilePath = filePath.ToString();
        //            file.SaveAs(filePath);
        //            return RedirectToAction("Index", new { Message = ManageMessageId.PhotUploadSucess });

        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", new { Message = ManageMessageId.FileExtensionError });

        //        }


        //    }

        //    return RedirectToAction("Index", new { Message = ManageMessageId.Error });

        //}

        //public Task<ApplicationUser> GetCurrentUserAsync()
        //{
        //    return await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //}

        //public enum ManageMessageId{
        //    Error,
        //    PhotUploadSucess,
        //    FileExtensionError

        //}


        



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
