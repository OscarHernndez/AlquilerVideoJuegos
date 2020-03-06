using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVJ.BL
{
    public class Producto
    {

        public Producto()
        {
            Disponible = true;
            Precio = 1;
            cantidad = 1;
        }

        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Ingrese la descripción")]
        [MinLength(3, ErrorMessage = "Ingrese mínimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese un máximo de 20 caracteres")]
        public string Descripcion { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Cantidad")]
        [Range(1, 1000, ErrorMessage = "Ingrese un precio entre 1 y 1000")]
        public int cantidad { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Ingrese el precio")]
        [Range(0, 1000, ErrorMessage = "Ingrese un precio entre 1 y 1000")]
        public int Precio { get; set; }
        public bool Disponible { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
    }
}
