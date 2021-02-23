using MedicalInformationService.Business.Extencions.DIResolvers;
using MedicalInformationService.DataAccess.Concrete.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalInformationService.API
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
            services.AddDbContext<MyDataContext>();
            services.AddContainerWithDependencies();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //JwtBearer
       .AddJwtBearer(options =>
       {
           //JWT ayarlarýný yaptýðýmýz yerdir.
           options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
           {
               ValidAudience = (string)Convert.ChangeType(Configuration["JwtTokenConfig:ValidAudience"], typeof(string)),//Tokenýmýza vereceðimiz özel bir bilgidir. Bu bilgi ile tokenýmýz oluþacak ve eðer gelen tokendaki bu bilgi farklý ise giriþ iþlemi baþarýsýz olacaktýr.
               ValidateAudience = (bool)Convert.ChangeType(Configuration["JwtTokenConfig:ValidateAudience"], typeof(bool)),//Request isteðinde gelen tokenýn ValidAudience bilgisinin doðruluðunun kontrol edilip edilmemesi kýsmý. Eðer bu özellik false olursa tokenýn ValidAudience deðerinin bir önemi yokt
               ValidIssuer = (string)Convert.ChangeType(Configuration["JwtTokenConfig:ValidIssuer"], typeof(string)),//Tokenýn hangi sunucu tarafýndan oluþturulduðu bilgisinin verildiði kýsýmdýr. Token’a verdiðimiz ekstra güvenlik bilgisi gibi düþünebiliriz.
               ValidateIssuer = (bool)Convert.ChangeType(Configuration["JwtTokenConfig:ValidateIssuer"], typeof(bool)),//Request isteðinde gelen tokenýn ValidIssuer bilgisinin doðruluðunun kontrol edilip edilmemesi kýsmý. Eðer bu özellik false olursa tokenýn ValidIssuer deðerinin bir önemi yoktur.
               ValidateLifetime = (bool)Convert.ChangeType(Configuration["JwtTokenConfig:ValidateLifetime"], typeof(bool)),//Tokenýn ömrünün(expires) kullanýlýp kullanýlmayacaðýnýn belirlendiði kýsýmdýr. Eðer bu özellik false olursa tokenýn ömrünün bir önemi yoktur.
               IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes((string)Convert.ChangeType(Configuration["JwtTokenConfig:IssuerSigningKey"], typeof(string)))),//Tokenýmýzý oluþtururken kullanacaðýmýz secret keyimizdir. Tokenýmýzýn güvenlik anahtarý diyebiliriz.
               ValidateIssuerSigningKey = (bool)Convert.ChangeType(Configuration["JwtTokenConfig:ValidateIssuerSigningKey"], typeof(bool)),// Request isteðinde gelen tokenýn IssuerSigningKey bilgisinin doðruluðunun kontrol edilip edilmemesi kýsmý. Eðer bu özellik false olursa tokenýn IssuerSigningKey deðerinin bir önemi yoktur.
               ClockSkew = TimeSpan.Zero //Tokenýmýzýn ömrünün minimum süresinin belirlendiði kýsýmdýr. Default hali 5 dakikadýr. 5 dakikanýn altýnda bir deðer versen bile 5 dakika yaþar.
           };

           //JWT eventlarýnýn yakalandýðý yerdir.
           options.Events = new JwtBearerEvents
           {
               //Eðer Token bilgisi yanlýþsa buraya düþecek.
               OnAuthenticationFailed = _ =>
               {
                   Console.WriteLine($"Exception:{_.Exception.Message}");
                   return Task.CompletedTask;
               },
               //Eðer token bilgisi doðruysa buraya düþecek.
               OnTokenValidated = _ =>
               {
                   Console.WriteLine($"Login Success:{ _.Principal.Identity}");
                   return Task.CompletedTask;
               },

           };
       });
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

            app.UseAuthentication(); //üyleik jwt üstte
            app.UseAuthorization(); //yetkilendirme allta 
       

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
