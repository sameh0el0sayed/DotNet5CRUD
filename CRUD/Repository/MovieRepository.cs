using System;
using System.Collections.Generic;
using System.Linq;
using CRUD.Interface;
using CRUD.Models;

namespace CRUD.Repository
{
    public class MovieRepository : IMovie
    {

        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
           Movie movie= _context.Movies.Find(id);
            _context.Movies.Remove(movie);
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Find(id);
        }

        public Movie GetMovieById(int? id)
        {
            Movie movie=_context.Movies.Find(id);
            if (movie!=null)
            {
                return movie;
            }
            movie = new Movie();
            return movie;

        }

        public void Insert(Movie movie)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                transaction.CreateSavepoint("BeforeMoreMovies");

                _context.Movies.Add(movie);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.ReleaseSavepoint("BeforeMoreMovies");
            }
        }

        public void Update(Movie movie)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                transaction.CreateSavepoint("BeforeUpdateMovies");

                _context.Movies.Update(movie);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.ReleaseSavepoint("BeforeUpdateMovies");
            }

        }
    }
}
