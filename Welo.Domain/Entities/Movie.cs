using Welo.Domain.Entities.Base;
using Welo.Domain.Entities.Enums;

namespace Welo.Domain.Entities
{
    public class Movie : Entity<int>
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
