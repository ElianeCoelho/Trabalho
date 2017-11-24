using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace eattofit.Classes
{
    public class Utilidades
    {



        public static string UploadImagem(HttpPostedFileBase file)
        {

            string path = string.Empty;
            string pic = string.Empty;
            if (file != null)
                {

                pic = Path.GetFileName(file.FileName);
               
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/Arquivos/"), pic);

                file.SaveAs(path);
                string two = path;
                using (MemoryStream ms = new MemoryStream())
                {

                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }
            return pic;


        }
    }
}