using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Release Date" )]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Display(Name="Number in stock")]
        public long NumberInStock { get; set; }

        public byte GenreId { get; set; } // Dodane tylko dla optymalizacji, aby nie musieś robić include Genre?
    }

}