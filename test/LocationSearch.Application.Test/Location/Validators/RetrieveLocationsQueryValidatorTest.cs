using System;
using LocationSearch.Application.Location.Validators;
using LocationSearch.Domain.Location.Models;
using NUnit.Framework;

namespace LocationSearch.Application.Test.Location.Validators
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RetrieveLocationsQueryValidatorTest
    {
        [Test]
        public void Validate_NullValue_Throws()
        {
            var sut = new RetrieveLocationsQueryValidator();
            
            Assert.Throws<ArgumentNullException>(() => { sut.Validate(null); });
        }
        
        [Test]
        public void Validate_NullLocationFilterValues_Throws()
        {
            var valueToValidate = new LocationQueryParams();
            
            var sut = new RetrieveLocationsQueryValidator();
            
            Assert.Throws<ArgumentNullException>(() => { sut.Validate(valueToValidate); });
        }
        
        [Test]
        public void Validate_ValidValue_Ok()
        {
            var valueToValidate = new LocationQueryParams
            {
                LocationFilterValues = new LocationFilterValues()
            };
            
            var sut = new RetrieveLocationsQueryValidator();
            
            Assert.DoesNotThrow(() => { sut.Validate(valueToValidate); });
        }
    }
}