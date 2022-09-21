using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.DataBaseConnection;
using Repositories.Interfaces;
using Repositories.Repository;
using Services.Interfaces;
using Services.Services;

namespace ProjetoBackEnd_V6
{
    
    public class Startup
    {
        private const string V = @"Server = 127.0.0.1; Database = apipablo; Uid = root; Pwd = 30910023";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            //services.AddRouting();

            //services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            //services.AddScoped<IRepositoryTarefa, RepositoryTarefa>();
            //services.AddScoped<ITarefaService, TarefaService>();
            services.AddDbContext<ApiContext>(opt => opt.UseMySql(,V));

            services.AddDbContext<ApiContext>(opt => opt.UseSqlServer(@"Server = DESKTOP-10HCQPV\SQLEXPRESS; Database = Tarefas; Trusted_Connection = True;"));

            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<IRespositoryTarefa, RepositoryTarefa>();
            services.AddScoped<IValidator<Tarefa>, TarefaValidator>();

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
