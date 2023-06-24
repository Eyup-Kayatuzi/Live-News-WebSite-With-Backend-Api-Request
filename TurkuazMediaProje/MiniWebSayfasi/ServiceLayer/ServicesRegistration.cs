using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Concrete;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class ServicesRegistration
    {
        public static void AddCustomeServices(this IServiceCollection services)
        {
            services.AddTransient<IHttpClientServiceImplementation, HttpClientServiceImplementation>(); // herbir istekte yenilenmesi icin
            services.AddSingleton<IHelperMethods, HelperMethods>(); 
        }
    }
}
