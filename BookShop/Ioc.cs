using Application.Interfaces;
using Application.Services;
using BookShop.View;
using BookShop.View.Dialogs;
using BookShop.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Constants;
using Persistence.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    internal static class Ioc
    {
        private static readonly IServiceProvider _serviceProvider;

        static Ioc()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
            var dataBase = _serviceProvider.GetRequiredService<BookShopDbContext>();
            if (dataBase.Database.EnsureCreated())
            {
                DatabaseInitializer.Initialize(dataBase);
            }

        }
        public static T Resolve<T>() => _serviceProvider.GetRequiredService<T>();

        private static void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddPersistence(configuration);

            services.AddTransient<MainViewModel>();
            services.AddSingleton<MainWindow>();

            services.AddTransient<AdminPanelViewModel>();
            services.AddTransient<AdminPanelPage>();

            services.AddSingleton<BookCatalogViewModel>();
            services.AddTransient<BookListPage>();

            services.AddTransient<AddProductViewModel>();
            services.AddTransient<NewProductDialog>();

            services.AddTransient<RegisterDialog>();
            services.AddTransient<RegistrationViewModel>();

            services.AddTransient<SelectCategoriesViewModel>();
            services.AddTransient<SelectCategoriesDialog>();

            services.AddTransient<AuthorizationViewModel>();
            services.AddTransient<AuthorizeWindow>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<CartPage>();
        }
    }
}
