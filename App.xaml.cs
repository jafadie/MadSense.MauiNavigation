﻿using Prismanda.Views;

namespace Prismanda
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            MainPage = new NavigationPage(ServiceProvider.GetRequiredService<MainPage>());
        }
    }
}
