﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Inception" },
                new Movie { Id = 2, Name = "Prestige" }
            };
        }

        [Route("Movie/Random")]
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