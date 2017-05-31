using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MyFirstGitProject.Interceptor;
using MyFirstGitProject.Interfaces;
using MyFirstGitProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstGitProject.Models
{
    public class IoC
    {

        private static IWindsorContainer BootstrapContainer()
        {
            return new WindsorContainer().Register(
            Component.For<IEmailService>().ImplementedBy<EmailService>().Interceptors(typeof(LoggingInterceptor)),
            Component.For<LoggingInterceptor>()
            );
        }

        private static IWindsorContainer _container = null;
        private static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = BootstrapContainer();
                }
                return _container;
            }
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}