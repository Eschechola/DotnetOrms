using DotnetORMS.Infra.Dapper.Context;
using DotnetORMS.Infra.Dapper.Repository;
using DotnetORMS.Infra.DataReader.Context;
using DotnetORMS.Infra.DataReader.Repository;
using DotnetORMS.Infra.DI.Settings;
using DotnetORMS.Infra.Entity.Context;
using DotnetORMS.Infra.Entity.Repository;
using DotnetORMS.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotnetORMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //injeção de dependência dos bancos / connectionString
            Configuration = Injection.Configuration;
            var connectionString = Configuration["ConnectionStrings:SqlServer"];

            //injetando serviço do dapper
            var dapperContext = new DapperContext(connectionString);
            var dapperRepository = new DapperRepository(dapperContext);
            var dapperService = new DapperService(dapperRepository);

            services.AddSingleton<DapperService>(dapperService);

            //injetando serviço do entity
            var entityContext = new EntityContext(connectionString);
            var entityRepository = new EntityRepository(entityContext);
            var entityService = new EntityService(entityRepository);

            services.AddSingleton<EntityService>(entityService);


            //injetando serviço do datareader
            var readerContext = new DataReaderContext(connectionString);
            var readerRepository = new DataReaderRepository(readerContext);
            var readerService = new DataReaderService(readerRepository);

            services.AddSingleton<DataReaderService>(readerService);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
