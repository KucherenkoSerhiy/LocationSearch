using System.Collections.Generic;

namespace LocationSearch.Domain.Location.Factories
{
    public interface ILocationFactory
    {
        Models.Location Build(Dictionary<string, string> values);
    }
}