using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieManager.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "No se puede exceder de 50 caracteres")]
        [Required(ErrorMessage = "El titulo de la película es obligatorio")]
        [Display(Name = "Nombres del actor")]
        public string Titulo { get; set; }

        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "La fecha estreno es obligatoria")]
        [Display(Name = "Fecha estreno")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaEstreno { get; set; }

        [Required(ErrorMessage = "Por favor indique si la película está en cartelera o no")]
        public bool EnCartelera { get; set; }

        public int GeneroId { get; set; }

        //Propiedades de navegación
        public Genero Genero { get; set; }
        public List<PeliculasActores> PeliculasActores { get; set; }
    }
}
