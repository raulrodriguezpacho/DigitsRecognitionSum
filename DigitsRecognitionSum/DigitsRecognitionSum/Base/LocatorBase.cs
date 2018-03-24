using Autofac;
using Autofac.Core;
using DigitsRecognitionSum.Services;
using DigitsRecognitionSum.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitsRecognitionSum.Base
{
    public static class LocatorBase
    {
        private static bool _mock;

        private static IContainer _container;
        public static IContainer Container
        {
            get
            {
                return _container;
            }
        }

        public static void Register(IModule module = null, bool mock = false)
        {
            _mock = mock;
            var builder = new ContainerBuilder();
            RegisterServices(builder);
            RegisterViewModels(builder);
            if (module != null) RegisterPlatformModule(builder, module);
            _container = builder.Build();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            if (!_mock)
            {
                builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            }
            else
            {
                builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            }
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<FirstDigitViewModel>();
            builder.RegisterType<SecondDigitViewModel>();
            builder.RegisterType<ResultViewModel>();
        }

        private static void RegisterPlatformModule(ContainerBuilder builder, IModule module)
        {
            builder.RegisterModule(module);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
