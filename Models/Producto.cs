using System.ComponentModel.DataAnnotations;

namespace ExamenCesarJuñoAjaxNetCoreMVC.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        [Required(ErrorMessage = "La Descripcion es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El PrecioVenta es obligatorio")]
        public decimal PrecioVenta { get; set; }
        public int StockMinimo { get; set; }
        public int StockActual { get; set; }
        public DateTime FechaDeVenta { get; set; }
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
    }
}
