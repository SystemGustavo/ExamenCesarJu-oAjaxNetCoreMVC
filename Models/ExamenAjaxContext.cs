using Microsoft.EntityFrameworkCore;

namespace ExamenCesarJuñoAjaxNetCoreMVC.Models
{
    public class ExamenAjaxContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public ExamenAjaxContext(DbContextOptions<ExamenAjaxContext> options) : base(options)
        {

        }
    }
}
