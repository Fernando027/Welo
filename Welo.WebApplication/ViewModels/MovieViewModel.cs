using System.ComponentModel.DataAnnotations;
using Welo.Domain.Entities.Enums;

namespace Welo.WebApplication.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        #region Name Annotations
        [Required(ErrorMessage = "The {0} is required.")]
        #endregion
        public string Name { get; set; }

        #region Year Annotations
        [Required(ErrorMessage = "The {0} is required.")]
        [Range(1878, int.MaxValue, ErrorMessage = "The {0} field must be greater than 1878 (first movie ever made).")]
        #endregion
        public int Year { get; set; }

        #region Genre Annotations
        [Required(ErrorMessage = "The {0} is required.")]
        #endregion
        public Genre Genre { get; set; }
    }
}