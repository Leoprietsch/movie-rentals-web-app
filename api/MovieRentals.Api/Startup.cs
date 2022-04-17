using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MovieRentals.Infra.Contracts;
using MovieRentals.Infra.Repositories;
using MovieRentals.Service.Contracts;
using MovieRentals.Service.Services;
using MySql.Data.MySqlClient;

namespace MovieRentals.Api
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
      services.AddScoped<IDbConnection>(provider => new MySqlConnection(Configuration.GetConnectionString("MovieRentals")));

      services.AddTransient<IClientService, ClientService>();
      services.AddTransient<IClientRepository, ClientRepository>();

      services.AddTransient<IRentService, RentService>();
      services.AddTransient<IRentRepository, RentRepository>();

      services.AddTransient<IMovieRepository, MovieRepository>();

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie Rentals", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

      app.UseSwagger();
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Rentals"));

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
