using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id); ;

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }

        [Route("Movies/Random")]
        public ActionResult Random()
        {
            var viewModel = new RandomMovieViewModel
            {
                Movie = new Movie
                {
                    Name = "Inception"
                },
                Customers = new List<Customer>
                {
                    new Customer
                    {
                        Name = "Customer 1"
                    },
                    new Customer
                    {
                        Name = "Customer 2"
                    }
                }
            };

            return View(viewModel);
        }
    }
}