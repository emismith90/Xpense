﻿using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Xpense.Data.Infrastructure;
using Xpense.Service.XpenseServices.ClientServices;
using Xpense.Web.API.Models;
using Xpense.Web.API.Providers;

namespace Xpense.Web.API
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacWebAPIServices();
        }

        private static IContainer _container;

        private static void SetAutofacWebAPIServices()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();

            //services

            var x = new ApplicationDbContext();
            builder.Register<ApplicationDbContext>(c => x);
           
            builder.Register<UserStore<ApplicationUser>>(c => new UserStore<ApplicationUser>(x)).AsImplementedInterfaces();
            builder.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName")
            });

            builder.RegisterType<ApplicationUserManager>();


            builder.RegisterType<SimpleAuthorizationServerProvider>().AsSelf();
            builder.RegisterType<SimpleRefreshTokenProvider>().AsSelf();

            builder.RegisterType<ClientService>().As<IClientService>();
            builder.RegisterType<RefreshTokenService>().As<IRefreshTokenService>();

            _container = builder.Build();
            // Set the dependency resolver implementation.
            var resolver = new AutofacWebApiDependencyResolver(_container);
            configuration.DependencyResolver = resolver;
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}