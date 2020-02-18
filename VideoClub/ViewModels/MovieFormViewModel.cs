using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoClub.Models;

namespace VideoClub.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        ///public Movie Movie { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleasDate { get; set; }

        [Display(Name = "Number in stock")]

        [Required]
        [Range(1, 100)]
        public byte? NumberInStock { get; set; }
        

        

        [Display(Name = "Genre")]
        [Required]

        public byte? GenreId { get; set; }
        public string Title
        {
            get
            {
                if (Id != 0)

                    return "Edit Movie";


                return "New Movie";

            }
        }
        public MovieFormViewModel(Movie movieInDb)
        {

            Id = movieInDb.Id;
            Name = movieInDb.Name;
            ReleasDate = movieInDb.ReleasDate;
            NumberInStock = movieInDb.NumberInStock;
            GenreId = movieInDb.GenreId;
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
    }
}