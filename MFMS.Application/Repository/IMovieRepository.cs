using MFMS.Domain;

namespace MFMS.Application.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovie();
        Movie CreateMovie(Movie movie);

    }
}
