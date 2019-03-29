using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
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