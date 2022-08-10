using ASM.CLIENT.Helper;
using ASM.CLIENT.HttpInterfaces;
using ASM.CLIENT.HttpRepository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Smart.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASM.CLIENT
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddSmart();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient<IProductHttp, ProductHttpRepository>();
            builder.Services.AddTransient<ICategoryHttp, CategoryHttpRepository>();

            builder.Services.AddScoped<ToastHelper>();
            builder.Services.AddSingleton<CartHelper>();

            await builder.Build().RunAsync();
        }
    }
}