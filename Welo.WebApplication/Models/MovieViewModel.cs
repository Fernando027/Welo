using Welo.Domain.Entities.Enums;

namespace Welo.WebApplication.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}