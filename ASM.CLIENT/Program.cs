using ASM.CLIENT.Helper;
using ASM.CLIENT.HttpInterfaces;
using ASM.CLIENT.HttpRepository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Smart.Blazor;
using System;
using System.Net.Http;
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
            builder.Services.AddTransient<IAccountHttp, AccountHttpRepository>();
            builder.Services.AddTransient<ICartHttp, CartHttpRepository>();



            builder.Services.AddScoped<ToastHelper>();
            builder.Services.AddScoped<CartHelper>();
            builder.Services.AddScoped<AccountHelper>();


            await builder.Build().RunAsync();
        }
    }
}
