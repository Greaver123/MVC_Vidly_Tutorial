using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Genre field is required")]
        public byte GenreId { get; set; } // Dodane tylko dla optymalizacji, aby nie musieś robić include Genre?

        [Required(ErrorMessage = "The Release Date field is required ")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "The Number in Stock field is required")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        public long NumberInStock { get; set; }
    }
}