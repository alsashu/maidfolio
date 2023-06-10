using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IMovieService
    {
        List<Movie> GetAllMovie();
        Movie CreateMovie(Movie movie);

    }
}
