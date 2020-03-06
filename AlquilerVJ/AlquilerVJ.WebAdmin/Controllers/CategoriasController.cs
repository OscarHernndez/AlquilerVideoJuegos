using AlquilerVJ.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVJ.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
       CategoriasBL _CategoriasBL;
        public CategoriasController()
        {
            _CategoriasBL = new CategoriasBL();
        }
        // GET: Productos
        public ActionResult Index()
        {
            var ListadeCategorias = _CategoriasBL.ObtenerCategorias();

            return View(ListadeCategorias);
        }

        public ActionResult Crear()
        {
            var NuevaCategoria = new Categoria();

            return View(NuevaCategoria);
        }
        
        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio o al final");
                    return View(categoria);
                }
                _CategoriasBL.GuardarCategoria(categoria);

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Editar(int id)
        {
            var categoria = _CategoriasBL.ObtenerCategorias(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            _CategoriasBL.GuardarCategoria(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Detalles(int id)
        {
            var categoria = _CategoriasBL.ObtenerCategorias(id);
            return View(categoria);
        }
        public ActionResult Eliminar(int id)
        {
            var categoria = _CategoriasBL.ObtenerCategorias(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {
            _CategoriasBL.EliminarCategoria(categoria.Id);
            return RedirectToAction("Index");
        }
    }
}