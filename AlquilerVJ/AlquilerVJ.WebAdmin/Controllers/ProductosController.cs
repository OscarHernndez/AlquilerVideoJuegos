using AlquilerVJ.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVJ.WebAdmin.Controllers
{
    public class ProductosController : Controller
    {
        ProductosBL _ProductosBL;
        CategoriasBL _CategoriasBL;

        public ProductosController()
        {
            _ProductosBL = new ProductosBL();
            _CategoriasBL = new CategoriasBL();
        }

        // GET: Productos
        public ActionResult Index()
        {
            var ListadeProductos = _ProductosBL.ObtenerProductos();

            return View(ListadeProductos);
        }

        public ActionResult Crear()
        {
            var NuevoProducto = new Producto();
            var categorias = _CategoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(NuevoProducto);
            
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }

        [HttpPost]
        public ActionResult Crear(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }
                _ProductosBL.GuardarProducto(producto);
                return RedirectToAction("Index");
            }
                var categorias = _CategoriasBL.ObtenerCategorias();
                ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

                return View(producto);
        }


        public ActionResult Editar(int id)
        {
            var producto = _ProductosBL.ObtenerProducto(id);
            var categorias = _CategoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }


        [HttpPost]
        public ActionResult Editar(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }

                _ProductosBL.GuardarProducto(producto);
                return RedirectToAction("Index");
            }
            var categorias = _CategoriasBL.ObtenerCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            if (imagen != null)
            {
                producto.UrlImagen = GuardarImagen(imagen);
            }

            return View(producto);
        }

        public ActionResult Detalles(int id)
        {
            var producto = _ProductosBL.ObtenerProducto(id);
            return View(producto);
        }


        public ActionResult Eliminar(int id)
        {
            var producto = _ProductosBL.ObtenerProducto(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _ProductosBL.EliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }
    }
}