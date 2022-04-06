using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieManager.Models
{
    public class PeliculasActores
    {
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }

        [Required(ErrorMessage = "Ingrese el orden del actor")]
        public int Orden { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Ingrese el personaje")]
        public string Personaje { get; set; }

        //Propiedades de navegación
        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
    }
}
