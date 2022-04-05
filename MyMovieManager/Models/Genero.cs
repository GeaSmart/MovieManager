using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieManager.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [Display(Name = "Nombre del género")]
        [MaxLength(50,ErrorMessage = "El nombre no debe exceder de 50 caracteres")]
        public string Nombre { get; set; }
    }
}
