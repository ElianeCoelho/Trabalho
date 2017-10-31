using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eattofit.Controllers
{
    public class PedidoController : Controller
    {

        private eatfitdados2Entities db = new eatfitdados2Entities();




        public ActionResult ListaPedidos()
        {
            return View(db.Pedido.ToList());
        }

    }
}