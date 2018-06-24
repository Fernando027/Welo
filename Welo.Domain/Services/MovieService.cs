using Welo.Domain.Entities;
using Welo.Domain.Interfaces.Repositories;
using Welo.Domain.Interfaces.Services;

namespace Welo.Domain.Services
{
    public class MovieService : ServiceBaseTEntity<Movie, int>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
            : base(movieRepository)
        {
            _movieRepository = movieRepository;
        }
    }
}
