using ExamenCesarJuñoAjaxNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;

namespace ExamenCesarJuñoAjaxNetCoreMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ExamenAjaxContext _context;

        public ProductosController(ExamenAjaxContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            IEnumerable<Producto> query = _context.Productos.Include(x => x.Categoria);

            if (query != null)
            {
                var ProductDTO = query.Select(x => new ProductoDTO
                {
                    ProductoID = x.ProductoID,
                    Descripcion = x.Descripcion,
                    PrecioDeVenta = x.PrecioVenta,
                    StockActual = x.StockActual,
                    Categoria = x.Categoria.Nombre
                }).ToList();

                return Json(ProductDTO);
            }
            else
            {
                return Json(Enumerable.Empty<ProductoDTO>());
            }
        }

        [HttpPost]
        public IActionResult BuscarPorNombreyPrecio(string Nombre,decimal Precio)
        {
            IEnumerable<Producto> query = _context.Productos.Include(x => x.Categoria);
            if (!string.IsNullOrEmpty(Nombre))
            {
                query = query.Where(p => p.Descripcion.IndexOf(Nombre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            if (Precio > 0 )
            {
                query = query.Where(x => x.PrecioVenta == Precio).ToList();
            }
            if (Precio == 0)
            {
                query = query.ToList();
            }
            if (query != null)
            {
                var ProductDTO = query.Select(x => new ProductoDTO
                {
                    ProductoID = x.ProductoID,
                    Descripcion = x.Descripcion,
                    PrecioDeVenta = x.PrecioVenta,
                    StockActual = x.StockActual,
                    Categoria = x.Categoria.Nombre
                }).ToList();

                return Json(ProductDTO);
            }
           
            else
            {
                return Json(Enumerable.Empty<ProductoDTO>());
            }
        }

        [HttpGet]
        public IActionResult ViewModalProductPartial(int id)
        {
            //obtener todos las categorias
            IEnumerable<SelectListItem> SelectedListItemCategoria = _context.Categorias.Select(c => new SelectListItem
            {
                Text = c.Nombre,
                Value = c.CategoriaID.ToString()
            });
           
            //vista view modal registrar
            if (id == 0)
            {
                ProductoVM productVM = new ProductoVM()
                {
                    Producto = new Producto(),
                    Categoria = SelectedListItemCategoria
                };
                return PartialView("ModalProductPartial", productVM);
            }

            //vista view modal actualizar
            if (id > 0)
            {
                Producto producto = _context.Productos.Include(x => x.Categoria).
                                          FirstOrDefault(p => p.ProductoID == id);
                if (producto != null)
                {
                    ProductoVM productVM = new ProductoVM()
                    {
                        Producto = producto,
                        Categoria = SelectedListItemCategoria
                    };
                    return PartialView("ModalProductPartial", productVM);
                }
                
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(Producto data)
        {
            //registrar
            if (data.ProductoID == 0)
            {
                _context.Productos.Add(data);
                await _context.SaveChangesAsync();
                return Json(new { message = "Producto Registrado con éxito." });
            }

            //actualizar
            if (data.ProductoID > 0)
            {
                Producto producto = _context.Productos.Include(x => x.Categoria).
                                          FirstOrDefault(p => p.ProductoID == data.ProductoID);
               
                if (producto != null)
                {
                    producto.ProductoID = data.ProductoID;
                    producto.Descripcion = data.Descripcion;
                    producto.PrecioVenta = data.PrecioVenta;
                    producto.StockMinimo = data.StockMinimo;
                    producto.StockActual = data.StockActual;
                    producto.FechaDeVenta = data.FechaDeVenta;
                    producto.CategoriaID = data.CategoriaID;

                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                    return Json(new { message = "Producto Actualizado con éxito." });
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ViewEliminar(int id)
        {
            if (id > 0)
            {
                Producto producto = await _context.Productos.FirstOrDefaultAsync(p => p.ProductoID == id);

                if (producto != null)
                {
                     _context.Productos.Remove(producto);
                    await _context.SaveChangesAsync();
                    return Json(new { message = "Producto Eliminado con éxito." });
                }
            }
            return NotFound();
        }
    }
}
