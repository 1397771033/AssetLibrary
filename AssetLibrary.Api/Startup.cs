using AssetLibrary.Api.Extensions.Filters;
using AssetLibrary.Api.Infrastructure;
using AssetLibrary.Api.Models.AutoMapperProfile;
using CSRedis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Configuration;
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

            services.AddControllers()
                .AddMvcOptions(opt =>
                {
                    opt.Filters.Add<CustomAuthorizationFilter>();
                });

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

                c.AddSecurityDefinition("XY", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "XY",
                    BearerFormat = "XY",
                    In = ParameterLocation.Header,
                    Description = "请输入token，格式：XY {token}",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "XY"
                                }
                            },
                            new string[] {}
                    }
                });
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

            #region 配置redis
            var redisConnection = Configuration.GetValue<string>("RedisConnection");
            var csredis = new CSRedisClient(redisConnection);
            RedisHelper.Initialization(csredis);
            #endregion


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
