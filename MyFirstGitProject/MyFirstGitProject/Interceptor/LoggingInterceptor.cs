using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MyFirstGitProject.Interceptor
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var serializer = new JavaScriptSerializer();
            var parametersJson = serializer.Serialize(invocation.Arguments);

            System.Diagnostics.Debug.WriteLine("Request of " + invocation.Method.Name + " is " + parametersJson);

            invocation.Proceed();

            var returnValueJson = serializer.Serialize(invocation.ReturnValue);
           
            System.Diagnostics.Debug.WriteLine("Response of " + invocation.Method.Name + " is: " + invocation.ReturnValue);
        }
    }
}