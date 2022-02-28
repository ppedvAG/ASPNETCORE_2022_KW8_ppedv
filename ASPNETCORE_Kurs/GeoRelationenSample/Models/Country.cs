namespace GeoRelationenSample.Models
{
    public class Country
    {
        public int Id { get; set; } 
        public int ContinentId { get; set; }
        public string Name { get; set; }

        public string Capital { get; set; }


        //Naviagtion
        public virtual Continent Continent { get; set; }

        public virtual ICollection<LanguagesInCountry> LanguagesInCountry { get; set; }
    }
}
