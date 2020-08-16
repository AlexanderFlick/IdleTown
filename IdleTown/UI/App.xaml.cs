﻿using BLL.Services;
using BLL.Services.WorkerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IsThisThingOn
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder();
            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(MainWindow));
            services.AddSingleton<IItemService, ItemService>();
            services.AddSingleton<IWheatService, WheatService>();
            services.AddSingleton<ITimerService, TimerService>();
            services.AddSingleton<IStoneService, StoneService>();
            services.AddSingleton<IFarmerService, FarmerService>();
            services.AddSingleton<IMinerService, MinerService>();
            services.AddSingleton<IMerchantService, MerchantService>();
            services.AddSingleton<ITownsPeopleService, TownsPeopleService>();
        }
    }
}