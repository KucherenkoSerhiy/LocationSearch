using Core.Patterns;
using LocationSearch.Application.Location.Handlers;
using LocationSearch.Application.Location.Models.Queries;
using LocationSearch.Application.Location.Models.Queries.Responses;
using LocationSearch.Application.Location.Services;
using LocationSearch.Application.Location.Services.Impl;
using LocationSearch.Application.Location.Validators;
using LocationSearch.Domain.Location.Collections;
using LocationSearch.Domain.Location.Collections.Impl;
using LocationSearch.Domain.Location.Factories;
using LocationSearch.Domain.Location.Factories.Impl;
using LocationSearch.Domain.Location.Models;
using LocationSearch.Domain.Location.Services;
using LocationSearch.Domain.Location.Services.Impl;
using LocationSearch.Domain.Location.Specification.SpecificationParameterModels;
using LocationSearch.Domain.Location.Specifications;
using LocationSearch.Infrastructure.Location.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LocationSearch
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "LocationSearch.API", Version = "v1"});
            });
            
            services.AddMediatR(typeof(Startup));

            RegisterApplicationLayerDependencies(services);
            RegisterDomainLayerDependencies(services);
            
            RegisterInfrastructureLayerDependencies(services);
        }

        private static void RegisterApplicationLayerDependencies(IServiceCollection services)
        {
            services
                .AddTransient<IRequestHandler<RetrieveLocationsQuery, RetrieveLocationsQueryResponse>,
                    RetrieveLocationsQueryHandler>();
            services.AddTransient<IRetrieveLocationsAppService, RetrieveLocationsAppService>();
            services.AddTransient<IRequestValidator<LocationQueryParams>, RetrieveLocationsQueryValidator>(); ;
        }

        private static void RegisterDomainLayerDependencies(IServiceCollection services)
        {
            services.AddTransient<IRetrieveLocationsDomainService, RetrieveLocationsDomainService>();
            services.AddTransient<ISpecification<Domain.Location.Models.Location, LocationSpecificationParameters>, IsValidLocationSpecification>();
            services.AddTransient<ISpecification<Domain.Location.Models.Location, LocationSpecificationParameters>, IsLocationInRangeSpecification>();
            services.AddScoped<ILocationCollection, LocationCollection>();
            services.AddTransient<ILocationFactory, LocationFactory>();
        }

        private static void RegisterInfrastructureLayerDependencies(IServiceCollection services)
        {
            services.AddTransient<IRetrieveLocationsData<LocationQueryParams>, CsvLocationsDataRetriever>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LocationSearch.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}