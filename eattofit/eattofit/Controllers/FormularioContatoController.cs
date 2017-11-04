using eattofit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using eattofit.Models;
using System.Net;

namespace eattofit.Controllers
{

   
    public class FormularioContatoController : Controller
    {
        public ActionResult Index()
        {
         
            return View();
        }





        public ActionResult formulario()
        {

            return View();
        }

        //[HttpPost]
        //public ActionResult formulario(FormularioContato model)
        //{
        //    var mensagem = new MailMessage();
        //    mensagem.Subject = model.Assunto;
        //    mensagem.Body = model.Mensagem;
        //    mensagem.To.Add(model.Remetente);

        //    mensagem.IsBodyHtml = true;

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.EnableSsl = true;
        //    smtp.Send(mensagem);


        //    //smtp.Send(model.Remetente, "papturma2017@gmail.com", model.Assunto, model.Mensagem);



        //    return View();

        //}
        [HttpPost]
        public ActionResult formulario(FormularioContato model)
        {
               
            SmtpClient smtp = new SmtpClient("smtp.gmail.com"); //Utilize seu próprio servidor SMTP

           
            smtp.Send(model.Remetente, "papturma2017@gmail.com", model.Assunto, model.Mensagem);
                
            
                        return RedirectToAction("Index");
        }



        
    }
}

