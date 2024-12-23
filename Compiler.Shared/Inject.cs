﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared
{
    public class Inject
    {
        // singleton
        private static Inject instance = null;
        public static Inject Instance
        {
            get
            {
                if (instance == null) instance = new Inject();
                return instance;
            }
        }


        private ConfigurationBuilder confBuilder;
        private ServiceCollection services = new ServiceCollection();

        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }


        private Inject()
        {
            services = new ServiceCollection();
            confBuilder = new ConfigurationBuilder();
            Configuration = confBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

        }

        public void Build()
        {
            AddServices.Invoke(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        #region Configs

        public void AddJsonConfigFile(string jsonPath)
        {
            Configuration = confBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
        }

        public void AddJsonConfigString(string json)
        {
            Configuration = confBuilder.AddJsonStream(GenerateStreamFromString(json)).Build();
        }


        private Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        #endregion


        #region Services

        public Action<IServiceCollection> AddServices { get; set; }

        public T GetRequiredService<T>() where T : notnull
        {
            if (ServiceProvider == null) throw new NullReferenceException("You need call Build() to create the service provider.");
            return ServiceProvider.GetRequiredService<T>();
        }

        #endregion

    }
}
