using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Interface;
using CRUD.Models;
using CRUD.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMovie _imovie;
        public MoviesController(IMovie imovie)
        {
            _imovie = imovie;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //var movies = _movieRepository.GetAll();
            //ViewBag.data = movies.FirstOrDefault().Title;
            return View();
        }

        [HttpGet]
        [Route("Movie/{id?}")]
        public IActionResult init(int? id)
        {
            Movie movie = _imovie.GetMovieById(id);

            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound();
        }
    }
}
