using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LocationSearch.Domain.Location.Collections;
using LocationSearch.Domain.Location.Factories;
using LocationSearch.Domain.Location.Models;
using LocationSearch.Domain.Location.Services;
using Microsoft.Extensions.Configuration;

namespace LocationSearch.Infrastructure.Location.Services
{
    public class CsvLocationsDataRetriever : IRetrieveLocationsData<LocationQueryParams>
    {
        private readonly IConfiguration _configuration;
        private readonly ILocationFactory _locationFactory;
        private readonly ILocationCollection _locationCollection;

        public CsvLocationsDataRetriever(
            IConfiguration configuration,
            ILocationFactory locationFactory,
            ILocationCollection locationCollection)
        {
            _configuration = configuration;
            _locationFactory = locationFactory;
            _locationCollection = locationCollection;
        }

        public async Task Read(LocationQueryParams query)
        {
            var referenceLocation = new Domain.Location.Models.Location
            {
                Latitude = query.Latitude,
                Longitude = query.Longitude
            };
            var thresholdDistance = query.LocationFilterValues.ThresholdDistance;

            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["LocationSearch:Csv:DbPath"]);
            using (var reader = new StreamReader(dbPath))
            {
                while (!reader.EndOfStream)
                {
                    await ReadLine(reader, referenceLocation, thresholdDistance);
                }
            }
        }

        private async Task ReadLine(StreamReader reader, Domain.Location.Models.Location referenceLocation,
            double thresholdDistance)
        {
            var line = (await reader.ReadLineAsync()).Split(';');
            var values = new Dictionary<string, string>
            {
                {"Name", line[0]},
                {"Latitude", line[1]},
                {"Longitude", line[2]},
            };
            var location = _locationFactory.Build(values);
            _locationCollection.Add(location, referenceLocation, thresholdDistance);
        }
    }
}