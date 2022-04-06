using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieManager.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50,ErrorMessage = "No se puede exceder de 50 caracteres")]
        [Required(ErrorMessage = "El nombre del actor es obligatorio")]        
        [Display(Name = "Nombres del actor")]
        public string Nombres { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "No se puede exceder de 50 caracteres")]
        [Required(ErrorMessage = "El apellido del actor es obligatorio")]
        [Display(Name = "Apellidos del actor")]
        public string Apellidos { get; set; }

        [Display(Name = "Edad del actor")]
        public int Edad { get; set; }

        //Propiedades de navegación
        public List<PeliculasActores> PeliculasActores { get; set; }
    }
}
