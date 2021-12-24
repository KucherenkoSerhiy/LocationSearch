using System;
using System.Collections.Generic;

namespace LocationSearch.Domain.Location.Factories.Impl
{
    public class LocationFactory: ILocationFactory
    {
        public Models.Location Build(Dictionary<string, string> values)
        {
            var name = values["Name"];
            var isLatitudeValueOk = double.TryParse(values["Latitude"], out var latitude);
            var isLongitudeValueOk = double.TryParse(values["Longitude"], out var longitude);
            
            if (string.IsNullOrWhiteSpace(name) || !isLatitudeValueOk || !isLongitudeValueOk)
                throw new ArgumentException($"Failed creating following location:" +
                                            $"  Name = {name}," +
                                            $"  latitude = {values["Latitude"]}" +
                                            $"  longitude = {values["Longitude"]}");

            return new Models.Location
            {
                Name = name,
                Latitude = latitude,
                Longitude = longitude
            };
        }
    }
}