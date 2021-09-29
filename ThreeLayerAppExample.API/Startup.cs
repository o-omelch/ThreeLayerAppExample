using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ThreeLayerAppExample.BusinessLogic;
using ThreeLayerAppExample.BusinessLogic.Abstract;
using ThreeLayerAppExample.Data.Concrete.InMemory;
using ThreeLayerAppExample.Infrastructure.Abstract;

namespace ThreeLayerAppExample
{
   public class Startup
   {
      public Startup( IConfiguration configuration )
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices( IServiceCollection services )
      {
         services.AddAutoMapper( AppDomain.CurrentDomain.GetAssemblies() );

         registerBLServices( services );
         registerDalServices( services );

         services.AddControllers();
         
         services.AddSwaggerGen( c =>
         {
            c.SwaggerDoc( "v1", new OpenApiInfo
            {
               Version = "v1",
               Title = "ThreeLayerAppExample"
            } );
         } );
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
      {
         if ( env.IsDevelopment() )
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseSwagger();

         app.UseSwaggerUI( c =>
         {
            c.SwaggerEndpoint( "/swagger/v1/swagger.json", "My API V1" );
            c.RoutePrefix = string.Empty;
         } );

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints( endpoints =>
          {
             endpoints.MapControllers();
          } );
      }

      private void registerBLServices( IServiceCollection services )
      {
         services.AddSingleton< ICarManager, CarManager> ();
      }

      private void registerDalServices(IServiceCollection services )
      {
         services.AddSingleton<ICarRepository, CarInMemoryRepository>();
         services.AddSingleton< ICarPhotoRepository, CarPhotoInMemoryRepository> ();

      }
   }
}
