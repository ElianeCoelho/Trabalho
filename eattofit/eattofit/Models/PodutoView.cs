using System.ComponentModel.DataAnnotations;
using System.Web;

namespace eattofit.Models
{
    public class PodutoView
    {
        public Produto Produto { get; set; }

        public HttpPostedFileBase Imagem { get; set; }
    }
}