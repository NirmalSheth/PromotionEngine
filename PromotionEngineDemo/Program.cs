using Microsoft.Extensions.DependencyInjection;
using PromotionEngineOrchestration.Abstract;
using PromotionEngineOrchestration.Concrete;
using System;
using System.Collections.Generic;

namespace PromotionEngineDemo
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
          
            var service = _serviceProvider.GetService<IProductService>();
            var getproductList= service.PlaceProductOrder();
            var getTotalPrice= service.GetTotalPrice(getproductList);
            //calculate total price
            Console.WriteLine($"Total Price is:-{getTotalPrice}");
            DisposeServices();
            Console.ReadLine();

        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IProductService, ProductService>();
            services.AddScoped<IPromotion, AProductPromotion>();
            services.AddScoped<IPromotion, BProductPromotion>();
            services.AddScoped<IPromotion, CProductPromotion>();
            services.AddScoped<IPromotion, DProductPromotion>();
            services.AddScoped<IcombinePromotion, CDProductPromotion>();
            _serviceProvider = services.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
       
    }
}
