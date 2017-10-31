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
    public class ClienteController : Controller
    {
        private eatfitdados2Entities db = new eatfitdados2Entities();



       
        public ActionResult ListaClientes()
        {
            return View(db.Cliente.ToList());
        }


    }
}