    using System;
using System.Collections.Generic;
using CRUD.Models;

namespace CRUD.Interface
{
    public interface IMovie
    {
        List<Movie> GetAll();
        Movie GetMovieById(int? id);

        void Insert(Movie movie);
        void Update(Movie movie);
        void Delete(int id);

    }
}
