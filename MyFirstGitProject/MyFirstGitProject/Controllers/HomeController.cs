using Castle.Windsor;
using MyFirstGitProject.Interfaces;
using MyFirstGitProject.Models;
using MyFirstGitProject.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstGitProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IEmailService EmailService = IoC.Resolve<IEmailService>();
            EmailService.Send(new Email() { From="furkan.yetgin",To="engin.donmez",Body="Message body"});
            return View();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine("OnResultExecuted");
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("OnActionExecuted");
        }
    }
}