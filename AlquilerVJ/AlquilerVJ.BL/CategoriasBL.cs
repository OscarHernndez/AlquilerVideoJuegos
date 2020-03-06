using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVJ.BL
{
    public class CategoriasBL
    {
        Contexto _contexto;
        public List<Categoria> ListadeCategoria{ get; set; }

        public CategoriasBL()
        {
            _contexto = new Contexto();
            ListadeCategoria = new List<Categoria>();
        }

        public List<Categoria> ObtenerCategorias()
        {

            ListadeCategoria = _contexto.Categorias.ToList();
     

            return ListadeCategoria; 
        }

        public void GuardarCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var productoExistent = _contexto.Categorias.Find(categoria.Id);
                productoExistent.Descripcion = categoria.Descripcion;
            }
            _contexto.SaveChanges();

        }

        public void EliminarCategoria(int id)
        {
            var categoria = _contexto.Categorias.Find(id);
            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();

        }

        public Categoria ObtenerCategorias(int id)
        {
            var categoria = _contexto.Categorias.Find(id);
            return categoria;
        }
    }
}
