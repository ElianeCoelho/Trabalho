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
    public class CategoriaController : Controller
    {
        private eatfitdados2Entities db = new eatfitdados2Entities();

        // GET: Categoria
        public ActionResult ListaCategorias()
        {

            if (Session["IdFornecedor"] != null)
            {
                return View(db.Categoria.ToList());

            }
            else
            {
                return RedirectToAction("Login", "Fornecedor");
            }

            
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
