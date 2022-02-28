namespace GeoRelationenSample.Models
{
    public class LanguagesInCountry
    {
        public int Id { get; set; }
        public double Percent { get; set; }

        public virtual Country Country { get; set; }
        public virtual Language Languages { get; set; }
    }
}
