using MedicalInformationService.Business.Abstract;
using MedicalInformationService.Business.Concrete;
using MedicalInformationService.Business.Helpers;
using MedicalInformationService.Business.Helpers.HelperAbstract;
using MedicalInformationService.DataAccess.Abstract;
using MedicalInformationService.DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInformationService.Business.Extencions.DIResolvers
{
    public static class StartupDIResolvers
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IActiveSubstanceService, ActiveSubstanceService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IStorageService, StorageService>();

            services.AddScoped<IActiveSubstanceRepository, ActiveSubstanceRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IStorageRepository, StorageRepository>();

            services.AddScoped<IMedicineFunctions, MedicineFunctions>();
        }
    }
}
