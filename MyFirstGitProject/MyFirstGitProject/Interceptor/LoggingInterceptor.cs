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

            System.Diagnostics.Debug.WriteLine("İstek yapilan metod: " + invocation.Method.Name + " Parametreleri: " + parametersJson);

            invocation.Proceed();

            var returnValueJson = serializer.Serialize(invocation.ReturnValue);
           
            System.Diagnostics.Debug.WriteLine("Cevap Alinan Metod: " + invocation.Method.Name + " Geri Donen Deger: " + invocation.ReturnValue);
        }
    }
}