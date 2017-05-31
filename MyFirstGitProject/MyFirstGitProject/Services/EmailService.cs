using MyFirstGitProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFirstGitProject.Models;

namespace MyFirstGitProject.Services
{
    public class EmailService : IEmailService
    {
        public bool Send(Email email)
        {
            //Send Email Business
            return true;
        }
    }
}