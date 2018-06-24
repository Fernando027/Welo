using Welo.Domain.Entities;
using Welo.Domain.Interfaces.Repositories.Base;

namespace Welo.Domain.Interfaces.Repositories
{
    public interface IMovieRepository : IRepository<Movie, int>, IRepositoryAsync<Movie, int>
    {

    }
}
