using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using VideoClub.Models;
using VideoClub.ViewModels;

namespace VideoClub.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext context;
            public MovieController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var customers = context.Movies
                                    .Include(m => m.Genre)
                                    .ToList();

            return View(customers);
        }


        public ActionResult Details(int id)
        {
            var movie = context.Movies
                .Include(m=> m.Genre)
                .SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        public ActionResult Edit(int id)
        {
            var movieInDb = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return HttpNotFound();
            }
           
                var viewModel = new MovieFormViewModel(movieInDb)
                {
                    //Id = movieInDb.Id,
                    //Name = movieInDb.Name,
                    //ReleasDate = movieInDb.ReleasDate,
                    //NumberInStock = movieInDb.NumberInStock,
                    //GenreId = movieInDb.GenreId,
                    Genres = context.Genres.ToList()
                    
                };
            
            return View("MovieForm", viewModel);
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1,Name = "Avengers"},
                new Movie { Id = 2, Name = "Harry Potter"},
                new Movie { Id = 3, Name = "Justice League"}
            };

        }
        // GET: Movie/Random
        public ViewResult Random()
        {
            var movie = new Movie() { Name = "Avengers" };
            var customers = new List<Customer>
            {
             new Customer{Name= "Customer1"},
             new Customer{Name= "Customer2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie);
               
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = context.Movies.Single(m => m.Id == movie.Id);
                if (movieInDb != null)
                {
                    movieInDb.Name = movie.Name;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.NumberInStock = movie.NumberInStock;
                    movieInDb.ReleasDate = movie.ReleasDate;
                }
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
        public ActionResult New()
        {
            var genres = context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
               // Movie = new Movie(),
                Genres = genres
            };
            return View("MovieForm", viewModel);

        }
        //public ActionResult Edit(int id)
        //{
        //    return Content("id = " + id);
        //}
        //[Route("movie/released/{year}/{month:regex(\\d{2})}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}