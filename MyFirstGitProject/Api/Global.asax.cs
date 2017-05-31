using Api.Ioc;
using Castle.Windsor;
using MyFirstGitProject.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

           /* var container = new WindsorContainer();
            container.Install(new ServiceInstaller());
            container.Install(new WebApiControllerInstaller());
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new ApiControllerActivator(container));
            GlobalConfiguration.Configure(WebApiConfig.Register);*/
        }
    }
}
