using Castle.DynamicProxy;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace MyFirstGitProject.Interceptor
{
    public class LoggingInterceptor : IInterceptor
    {



        public string ipAddress;

        public string IpAddress
        {
            get
            {
                if (this.ipAddress == null)
                {
                    this.ipAddress = this.GetIpAddress();
                }

                return this.ipAddress;
            }

            set { this.ipAddress = value; }
        }


        protected string GetIpAddress()
        {
            //string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            System.Net.IPAddress ip = default(System.Net.IPAddress);
            ip = new System.Net.IPAddress(System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].Address);
            //string ip1 = Request.UserHostAddress;
            //string ipMethod1 = HttpContext.Current.Request.UserHostAddress;
            //return ip1.ToString() + "---" + ipMethod1.ToString();
            return ip.ToString();
        }

        public void Intercept(IInvocation invocation)
        {
            var serializer = new JavaScriptSerializer();
            var parametersJson = serializer.Serialize(invocation.Arguments);
            Logger logger = null;
            try
            {

                logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Log(LogLevel.Trace, invocation.Method.Name + " Metoduna girildi... Bu metoda ait parametreler:" + parametersJson + "Client ip Address= " + this.IpAddress);

                System.Diagnostics.Debug.WriteLine("İstek yapilan metod: " + invocation.Method.Name + " Parametreleri: " + parametersJson);

                invocation.Proceed();

                var returnValueJson = serializer.Serialize(invocation.ReturnValue);

                System.Diagnostics.Debug.WriteLine("Response of " + invocation.Method.Name + " is: " + invocation.ReturnValue);
                logger.Log(LogLevel.Trace, invocation.Method.Name + " Metodundan Cikildi... Bu metoddan geri dönen değer:" + invocation.ReturnValue);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, new Exception(ex.Message));
            }


        }
    }
}