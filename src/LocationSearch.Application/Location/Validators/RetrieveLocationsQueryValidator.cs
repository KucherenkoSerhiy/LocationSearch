using System;
using Core.Patterns;
using LocationSearch.Domain.Location.Models;

namespace LocationSearch.Application.Location.Validators
{
    public class RetrieveLocationsQueryValidator : IRequestValidator<LocationQueryParams>
    {
        public void Validate(LocationQueryParams valueToValidate)
        {
            if (valueToValidate?.LocationFilterValues == null)
                throw new ArgumentNullException();
        }
    }
}