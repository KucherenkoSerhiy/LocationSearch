using System;
using Core.Patterns;
using LocationSearch.Domain.Location.Specification.SpecificationParameterModels;

namespace LocationSearch.Domain.Location.Specifications
{
    public class IsLocationInRangeSpecification: ISpecification<Models.Location, LocationSpecificationParameters>
    {
        public bool IsSatisfiedBy(Models.Location value, LocationSpecificationParameters parameters)
        {
            if (value == null || parameters?.ReferenceLocation == null)
                return false;
            
            var distance = CalculateDistance(value, parameters.ReferenceLocation);
            return distance <= parameters.ThresholdDistance;
        }
        
        /// <summary>
        /// Calculates the distance between this location and another one, in meters.
        /// </summary>
        public double CalculateDistance(Models.Location targetLocation, Models.Location currentLocation)
        {
            var rlat1 = Math.PI * targetLocation.Latitude / 180;
            var rlat2 = Math.PI * currentLocation.Latitude / 180;
            var rlon1 = Math.PI * targetLocation.Longitude / 180; // BUG?: value not used
            var rlon2 = Math.PI * currentLocation.Longitude / 180; // BUG?: value not used
            var theta = targetLocation.Longitude - currentLocation.Longitude;
            var rtheta = Math.PI * theta / 180;
            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1609.344;
        }
    }
}