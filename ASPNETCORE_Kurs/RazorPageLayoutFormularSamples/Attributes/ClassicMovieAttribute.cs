using RazorPageLayoutFormularSamples.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorPageLayoutFormularSamples.Attributes
{
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public int Year { get; set; }
        
        public ClassicMovieAttribute(int year)
        {
            Year = year;
        }

        public string GetErrorMessage() => $"Classic Filme müssen früher als {Year} sein";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;
            int releaseYear = (Convert.ToInt32(value));

            if(movie.Genre == MovieGenre.Classic && releaseYear > Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
