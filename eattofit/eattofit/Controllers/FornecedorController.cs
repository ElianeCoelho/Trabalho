using System;
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
            try { 
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
            
            return View();

            }
            catch
            {
                ModelState.AddModelError(string.Empty,"The item cannot be removed");
               

               return RedirectToAction("Login");

            }

        }





        // GET: Fornecedor
        public ActionResult ListaFornecedor()
        {



           int idSessao = int.Parse(Session["IdFornecedor"].ToString());

            var filtro = from f in db.Fornecedor where f.IdFornecedor == idSessao select f;


            return View(filtro);
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
            if (ModelState.IsValid) { 
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





        
            public static bool IsCpf(string cpf)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }




        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }




//        public ActionResult EmailUnico(string Email)
//        {
//            boolean emailValido = false;

//            emailValido = chamada a sua classe de verificacao de email com retorno(true / false)


//if (emailValido == true)
//            {
//                return Json(true, JsonRequestBehavior.AllowGet);
//            }
//            else
//            {
//                return Json(string.Format("E-mail '{0}' já esta cadastrado.", Email), JsonRequestBehavior.AllowGet);
//            }
//        }

//        public ActionResult Verificaemail(FO)

    }
}
