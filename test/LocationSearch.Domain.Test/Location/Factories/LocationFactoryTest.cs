using System;
using System.Collections.Generic;
using LocationSearch.Domain.Location.Factories.Impl;
using NUnit.Framework;

namespace LocationSearch.Domain.Test.Location.Factories
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LocationFactoryTest
    {
        [TestCase("", "52.2165425","5.4778534")]
        [TestCase("AH Frieswijkstraat 72, Nijkerk", "", "5.4778534")]
        [TestCase("AH Frieswijkstraat 72, Nijkerk", "abc", "5.4778534")]
        [TestCase("AH Frieswijkstraat 72, Nijkerk", "52.2165425", "")]
        [TestCase("AH Frieswijkstraat 72, Nijkerk", "52.2165425", "abc")]
        public void Build_InvalidValues_ThrowsArgumentException(string name, string latitude, string longitude)
        {
            var values = CreateValueDictionaryParameter(name, latitude, longitude);
            var sut = new LocationFactory();
            Assert.Throws<ArgumentException>(() => sut.Build(values));
        }

        public void Build_ValidValues_Ok()
        {
            var name = "AH Frieswijkstraat 72, Nijkerk";
            var latitude = "52.2165425";
            var longitude = "5.4778534";
            var values = CreateValueDictionaryParameter(name, latitude, longitude);
            var sut = new LocationFactory();

            var build = sut.Build(values);

            Assert.AreEqual(name, build.Name);
            Assert.AreEqual(latitude, build.Latitude);
            Assert.AreEqual(longitude, build.Longitude);
        }

        private Dictionary<string, string> CreateValueDictionaryParameter(string name, string latitude, string longitude)
        {
            return new Dictionary<string, string>
            {
                {"Name", name},
                {"Latitude", latitude},
                {"Longitude", longitude}
            };
        }
    }
}