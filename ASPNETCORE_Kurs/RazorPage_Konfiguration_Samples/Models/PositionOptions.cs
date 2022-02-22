namespace RazorPage_Konfiguration_Samples.Models
{
    public class PositionOptions
    {
        public const string Position = "Position";

        //Achtung vor der Schreibweise -> Properties müssen selben Namen haben, wie in AppSettings->Keys 
        public string Title { get; set; }
        public string Name { get; set; }
    }
}
