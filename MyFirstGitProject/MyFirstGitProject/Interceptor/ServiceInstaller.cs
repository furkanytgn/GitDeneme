using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MyFirstGitProject.Interfaces;
using MyFirstGitProject.Services;

namespace MyFirstGitProject.Interceptor
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IEmailService))
                 .ImplementedBy(typeof(EmailService))
                 .Interceptors(typeof(LoggingInterceptor)));
        }
    }

   
}