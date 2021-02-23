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
           //JWT ayarlar�n� yapt���m�z yerdir.
           options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
           {
               ValidAudience = (string)Convert.ChangeType(Configuration["JwtTokenConfig:ValidAudience"], typeof(string)),//Token�m�za verece�imiz �zel bir bilgidir. Bu bilgi ile token�m�z olu�acak ve e�er gelen tokendaki bu bilgi farkl� ise giri� i�lemi ba�ar�s�z olacakt�r.
               ValidateAudience = (bool)Convert.ChangeType(Configuration["JwtTokenConfig:ValidateAudience"], typeof(bool)),//Request iste�inde gelen token�n ValidAudience bilgisinin do�rulu�unun kontrol edilip edilmemesi k�sm�. E�er bu �zellik false olursa token�n ValidAudience de�erinin bir �nemi yokt
               ValidIssuer = (string)Convert.ChangeType(Configuration["JwtTokenConfig:ValidIssuer"], typeof(string)),//Token�n hangi sunucu taraf�ndan olu�turuldu�u bilgisinin verildi�i k�s�md�r. Token�a verdi�imiz ekstra g�venlik bilgisi gibi d���nebiliriz.
               ValidateIssuer = (bool)Convert.ChangeType(Configuration["JwtTokenConfig:ValidateIssuer"], typeof(bool)),//Request iste�inde gelen token�n ValidIssuer bilgisinin do�rulu�unun kontrol edilip edilmemesi k�sm�. E�er bu �zellik false olursa token�n ValidIssuer de�erinin bir �nemi yoktur.
               ValidateLifetime = (bool)Convert.ChangeType(Configuration["JwtTokenConfig:ValidateLifetime"], typeof(bool)),//Token�n �mr�n�n(expires) kullan�l�p kullan�lmayaca��n�n belirlendi�i k�s�md�r. E�er bu �zellik false olursa token�n �mr�n�n bir �nemi yoktur.
               IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes((string)Convert.ChangeType(Configuration["JwtTokenConfig:IssuerSigningKey"], typeof(string)))),//Token�m�z� olu�tururken kullanaca��m�z secret keyimizdir. Token�m�z�n g�venlik anahtar� diyebiliriz.
               ValidateIssuerSigningKey = (bool)Convert.ChangeType(Configuration["JwtTokenConfig:ValidateIssuerSigningKey"], typeof(bool)),// Request iste�inde gelen token�n IssuerSigningKey bilgisinin do�rulu�unun kontrol edilip edilmemesi k�sm�. E�er bu �zellik false olursa token�n IssuerSigningKey de�erinin bir �nemi yoktur.
               ClockSkew = TimeSpan.Zero //Token�m�z�n �mr�n�n minimum s�resinin belirlendi�i k�s�md�r. Default hali 5 dakikad�r. 5 dakikan�n alt�nda bir de�er versen bile 5 dakika ya�ar.
           };

           //JWT eventlar�n�n yakaland��� yerdir.
           options.Events = new JwtBearerEvents
           {
               //E�er Token bilgisi yanl��sa buraya d��ecek.
               OnAuthenticationFailed = _ =>
               {
                   Console.WriteLine($"Exception:{_.Exception.Message}");
                   return Task.CompletedTask;
               },
               //E�er token bilgisi do�ruysa buraya d��ecek.
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

            app.UseAuthentication(); //�yleik jwt �stte
            app.UseAuthorization(); //yetkilendirme allta 
       

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
