using System;

namespace LocationSearch.Domain.Location.Models
{
    public class Location
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        /// <summary>
        /// Calculates the distance between this location and another one, in meters.
        /// </summary>
        public double CalculateDistance(Models.Location other)
        {
            var rlat1 = Math.PI * this.Latitude / 180;
            var rlat2 = Math.PI * other.Latitude / 180;
            var rlon1 = Math.PI * this.Longitude / 180; // BUG?: value not used
            var rlon2 = Math.PI * other.Longitude / 180; // BUG?: value not used
            var theta = this.Longitude - other.Longitude;
            var rtheta = Math.PI * theta / 180;
            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1609.344;
        }
    }
}