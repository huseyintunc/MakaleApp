using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makaleler.Business.Abstract;
using Makaleler.Business.Concrete;
using Makaleler.DataAccess.Abstract;
using Makaleler.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Makaleler.Rest
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
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);
            #region DPI

            services.AddScoped<IYazarService, YazarManager>();
            services.AddScoped<IYazarDal, EfYazarDal>();
            services.AddScoped<IKategoriService, KategoriManager>();
            services.AddScoped<IKategoriDal, EfKategoriDal>();
            services.AddScoped<IMakaleService, MakaleManager>();
            services.AddScoped<IMakaleDal, EfMakaleDal>();
            #endregion



            services.AddMvc().AddJsonOptions(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,//biz bu tokenı olustururken encrypt edılerek gonderılıyor.Bunu baskaları rahatlıkla encrypt edemesın dıye oraya bır tane kendı anahtarımızı koyuyuoruz.
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,// bu ıkısı false verılıyor.Kullanıcıyı dogrula 
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());
            app.UseAuthentication();

            app.UseAuthentication();
          
            app.UseMvc();
        }
    }
}
