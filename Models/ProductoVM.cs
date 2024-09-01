using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamenCesarJuñoAjaxNetCoreMVC.Models
{
    public class ProductoVM
    {
       public Producto Producto { get; set; }
       public IEnumerable<SelectListItem> Categoria { get; set; }
    }
}
