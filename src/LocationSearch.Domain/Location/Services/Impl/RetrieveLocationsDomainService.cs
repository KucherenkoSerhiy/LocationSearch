using System.Collections.Generic;
using System.Threading.Tasks;
using LocationSearch.Domain.Location.Models;

namespace LocationSearch.Domain.Location.Services.Impl
{
    public class RetrieveLocationsDomainService: IRetrieveLocationsDomainService
    {
        private readonly IRetrieveQueryBuilder<LocationQueryParams, string> _queryBuilder;
        private readonly IRetrieveQueryRunner<string, List<Models.Location>> _queryRunner;

        public RetrieveLocationsDomainService(
            IRetrieveQueryBuilder<LocationQueryParams, string> queryBuilder,
            IRetrieveQueryRunner<string, List<Models.Location>> queryRunner)
        {
            _queryBuilder = queryBuilder;
            _queryRunner = queryRunner;
        }
        
        public async Task<List<Models.Location>> Retrieve(LocationQueryParams parameters)
        {
            var query = await _queryBuilder.Build(parameters);
            var result = await _queryRunner.Run(query);
            return result;
        }
    }
}