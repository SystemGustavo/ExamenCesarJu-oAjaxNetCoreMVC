namespace ExamenCesarJuñoAjaxNetCoreMVC.Models
{
    public class ProductoDTO
    {
        public int ProductoID { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public int StockActual { get; set; }
        public string Categoria { get; set; }
    }
}
