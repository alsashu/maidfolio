using MFMS.Application.Repository;
using MFMS.Domain;

namespace MFMS.Infrastructure
{
    public class MovieRepository : IMovieRepository
    {
        public EF_DbContext _dbContext;
        public MovieRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public static List<Movie> movies = new List<Movie>()
        {
            new Movie{ id=1, name="Passion of Christ", cost=2 },
            new Movie{ id=2, name="Home Alone 4", cost=3 }
        };

        public Movie CreateMovie(Movie movie)
        {
            _dbContext.Add(movie);
            _dbContext.SaveChanges();
            return movie;
        }

        public List<Movie> GetAllMovie()
        {
            return _dbContext.Movies.ToList();
        }
    }
}
