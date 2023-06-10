using MFMS.Application.Abstraction;
using MFMS.Application.Repository;
using MFMS.Domain;
namespace MFMS.Application.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie CreateMovie(Movie movie)
        {
            return _movieRepository.CreateMovie(movie);
        }

        public List<Movie> GetAllMovie()
        {
            var movies = _movieRepository.GetAllMovie();
            return movies;
        }
    }
}
