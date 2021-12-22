namespace LocationSearch.Domain.Location.Models
{
    public class LocationQueryParams
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public LocationFilterValues LocationFilterValues { get; set; }
    }
}