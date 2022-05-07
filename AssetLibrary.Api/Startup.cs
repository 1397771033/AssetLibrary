using AssetLibrary.Api.Infrastructure;
using AssetLibrary.Api.Models.AutoMapperProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;

namespace AssetLibrary.Api
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
            #region 配置swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AssetLibrary.Api"
                });
                // 获取dll
                var path = typeof(Program).Assembly.Location;
                var basePath = Path.GetDirectoryName(path);
                // 为Swagger接口配置注释路径
                var xmlPath = Path.Combine(basePath, "AssetLibrary.Api.xml");
                c.IncludeXmlComments(xmlPath);
            });
            #endregion


            #region 配置数据库连接
            //string sqlServerConn = Configuration.GetValue<string>("SqlConnections:SqlServer");
            string mysqlConn = Configuration.GetValue<string>("SqlConnections:MySql");
            services.AddDbContext<AssetLibraryDbContext>(opt =>
            {
                //opt.UseSqlServer(sqlServerConn);
                opt.UseMySQL(mysqlConn);
            });
            #endregion

            services.AddAutoMapper(typeof(AssetLibraryProfile));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssetLibrary.Api v1"));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
