using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProjekatASP.Api.Core;
using ProjekatASP.Api.Extensions;
using ProjekatASP.Application;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Logging;
using ProjekatASP.Implementation.UseCases.Commands;
using ProjekatASP.Implementation.UseCases.Queries;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatASP.Api
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
            var settings = new AppSettings();

            Configuration.Bind(settings);

            services.AddSingleton(settings);
            services.AddApplicationUser();
            services.AddJwt(settings); //iz ContainerExtensions.cs
            services.AddProjekatDbContext();

            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<IAuditLogsQuery, EfAuditLogsQuery>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<ICreateIngredientCommand, EfCreateIngredientCommand>();
            services.AddTransient<ICreateDishCommand, EfCreateDishCommand>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IGetDishesQuery, EfGetDishesQuery>();
            services.AddTransient<IGetOneDishQuery, EfGetOneDishQuery>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IDeleteDishCommand, EfDeleteDishCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<IUpdateIngredientCommand, EfUpdateIngredientCommand>();
            services.AddTransient<UpdateIngredientValidator>();
            services.AddTransient<IGetOneIngredientQuery, EfGetOneIngredientQuery>();
            services.AddTransient<IGetOneCategoryQuery, EfGetOneCategoryQuery>();
            services.AddTransient<IGetIngredientsQuery, EfGetIngredientsQuery>();
            services.AddTransient<IUpdateDishCommand, EfUpdateDishCommand>();
            services.AddTransient<UpdateDishValidator>();
            services.AddTransient<IInsertIntoCartCommand, EfInsertIntoCartCommand>();
            services.AddTransient<InsertIntoCartValidator>();
            services.AddTransient<IDeleteDishFromCartCommand, EfDeleteDishFromCartCommand>();
            services.AddTransient<IGetUserCartQuery, EfGetUserCartQuery>();
            services.AddTransient<IUpdateQuantityCartCommand, EfUpdateQuantityCartCommand>();
            services.AddTransient<UpdateQuantityCartValidator>();
            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<IGetOrderQuery, EfGetOrderQuery>();

            //services.AddAutoMapper(cfg => {
            //    cfg.CreateMap<CategoryDto, Category>();
            //});
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateIngredientValidator>();
            services.AddTransient<CreateDishValidator>();
            //services.AddTransient<ProjekatDbContext>();
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjekatASP.Api", Version = "v1" });
            });


            services.AddHttpContextAccessor();
            //services.AddTransient<IApplicationUser>(x =>
            //{
            //    var accessor = x.GetService<IHttpContextAccessor>();

            //    var user = accessor.HttpContext.User;

            //    if (user.FindFirst("ActorData") == null)
            //    {
            //        return new AnonymousActor();
            //    }

            //    var actorString = user.FindFirst("ActorData").Value;

            //    var actor = JsonConvert.DeserializeObject<JwtUser>(actorString);

            //    return actor;

            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjekatASP.Api v1"));
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
