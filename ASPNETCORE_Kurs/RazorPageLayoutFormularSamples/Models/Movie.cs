namespace RazorPageLayoutFormularSamples.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }   
        public string Description { get; set; }
        
        public decimal Price { get; set; }  

        public MovieGenre Genre { get; set; }   
    }

    public enum MovieGenre { Action, Thriller, Drama, Romance, Comdey, Horroy, Western,Classic, Docu }
}
