
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Correios.Net;
namespace eattofit.Controllers
{
    public class EnderecoController : Controller
    {
        private eatfitdados2Entities db = new eatfitdados2Entities();

        // GET: Enderecoes
        public ActionResult Index()
        {
            return View(db.Endereco.ToList());
        }

        // GET: Enderecoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Enderecoes/Create
        public ActionResult Create(int IdFornecedor)
        {
            TempData["IdFornecedor"] = IdFornecedor;
            return View();
        }

        // POST: Enderecoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEndereco,Rua,Numero,Complemento,Cep,Bairro,Cidade,Estado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Endereco.Add(endereco);
                db.SaveChanges();

                int IdFornecedor = int.Parse(TempData["IdFornecedor"].ToString());

                TempData.Remove("Idfornecedor");

                Fornecedor f = db.Fornecedor.Find(IdFornecedor);

                f.IdEndereco = endereco.IdEndereco;

                db.Entry(f).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index", "Fornecedor");
            }

            return View(endereco);
        }

        // GET: Enderecoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEndereco,Rua,Numero,Complemento,Cep,Bairro,Cidade,Estado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        // GET: Enderecoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.Endereco.Find(id);
            db.Endereco.Remove(endereco);
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


        //private void LocalizarCEP()
        //{
        //    if (!string.IsNullOrWhiteSpace(txtCep.Text))
        //    {
        //        Address endereco = SearchZip.GetAddress(.Text);
        //        if (endereco.Zip != null)
        //        {
        //            txtEstado.Text = endereco.State;
        //            txtCidade.Text = endereco.City;
        //            txtBairro.Text = endereco.District;
        //            txtRua.Text = endereco.Street;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Cep não localizado...");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Informe um CEP válido");
        //    }
        //}



    }
}
