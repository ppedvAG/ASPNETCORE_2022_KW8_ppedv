using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using RazorPageLayoutFormularSamples.Attributes;

namespace RazorPageLayoutFormularSamples.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required] //Muss-Feld
        [MaxLength(50)]

        public string Title { get; set; }   

        //Ist kein Mussfeld, aber wenn ich ausfülle benötige ich mindesten 5 Zeichen
        [MinLength(5)]
        public string Description { get; set; }
        
        //Wertebereiche kann man festlegen 
        [Range(0, 50)]
        public decimal Price { get; set; }  

        [DisplayName("Release Year")]
        [ClassicMovie(1960)]
        public int ReleaseYear { get; set; }

        [Required]
        public MovieGenre Genre { get; set; }   
    }

    public enum MovieGenre { Action, Thriller, Drama, Romance, Comdey, Horroy, Western,Classic, Docu }
}
