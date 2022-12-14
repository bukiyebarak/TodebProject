using BackgroundJobs.Abstract;
using BackgroundJobs.Concrete;
using BackgroundJobs.Concrete.HangfireJobs;
using Business.Abstract;
using Business.Concrete;
using Business.Configuration.Cache;
using Business.Configuration.Mapper;
using DAL.Abstract;
using DAL.Concrete.EF;
using DAL.Concrete.MongoDB;
using DAL.DbContexts;
using DAL.EFBase;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace API
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
            
           
            //middleware
            services.AddDbContext<TodebDbContext>(ServiceLifetime.Transient);


            //mongoDb
           

            #region Cache
            //Redis NoSql bir veri taban?d?r.
            //distributed cache i?in redis impelemetasyonu yap?ld?. RedisEndPointInfo ile RedisTen al?nan bilgiler e?le?tirildi.
            var redisConfigInfo = Configuration.GetSection("RedisEndpointInfo").Get<RedisEndpointInfo>();
          
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.ConfigurationOptions = new ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { redisConfigInfo.EndPoint, redisConfigInfo.Port }
                    },
                    Password = redisConfigInfo.Password,
                    User = redisConfigInfo.UserName

                };
            });
            //local cache kullan?m?
            //Inmemory Ramde tutulur.
            services.AddMemoryCache();

            #endregion

            //mongo db
            services.AddSingleton<MongoClient>(x => new MongoClient("mongodb://localhost:27017"));
           


            //Mapper i?lemleri i?in servise MapperProfile eklendi.
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddScoped<IJobs, HangfireJobs>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IApartmentRepository, EFApartmentRepository>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IBillRepository, EFBillRepository>();
            services.AddScoped<ICacheExample, CacheExample>();
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            services.AddScoped<ICreditCardService, CreditCardService>();
            services.AddScoped<IMessageRepository, EFMessageRepository>();
            services.AddScoped<IMessageService, MessageService>();


            //Token ayarlar?
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<Business.Configuration.Auth.TokenOption>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                    };
                });

            #region Hangfire
            var hangFireDb = Configuration.GetConnectionString("HangfireConnection");

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(hangFireDb, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            services.AddHangfireServer();
            #endregion

            services.AddControllers();

            //401 hataso i?in d?zenleme
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHangfireDashboard("/TodebHangfire", new DashboardOptions()
            {

            });

            RecurringJob.AddOrUpdate<IJobs>(x => x.ReccuringJob(), Cron.Daily);

            app.UseRouting();

            //401 hatas? i?in 
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
