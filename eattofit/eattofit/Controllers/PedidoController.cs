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
    public class PedidoController : Controller
    {
        private eatfitdados2Entities db = new eatfitdados2Entities();

        // GET: Pedido
        public ActionResult Index()
        {



            if (Session["IdFornecedor"] != null)
            {
                var pedido = db.Pedido.Include(p => p.Produto).Include(p => p.Nota1);
                return View(pedido.ToList());
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
