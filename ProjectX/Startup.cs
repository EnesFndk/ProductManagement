using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProjectX
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
            
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectX", Version = "v1" });
            });

            services.AddDbContext<XDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration["ConnSt"]);
            });


            services.AddScoped<IBrandDal, EfBrandDal>();
            services.AddTransient<IBrandService, BrandManager>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddTransient<ICategoryService, CategoryManager>();

            services.AddScoped<ICityDal, EfCityDal>();
            services.AddTransient<ICityService, CityManager>();

            services.AddScoped<ICountryDal, EfCountryDal>();
            services.AddTransient<ICountryService, CountryManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddTransient<IProductService, ProductManager>();

            services.AddScoped<ISupplierDal, EfSupplierDal>();
            services.AddTransient<ISupplierService, SupplierManager>();

            services.AddScoped<IUnitDal, EfUnitDal>();
            services.AddTransient<IUnitService, UnitManager>();

            services.AddScoped<IUserDal, EfUserDal>();
            services.AddTransient<IUserService, UserManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectX v1"));
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
