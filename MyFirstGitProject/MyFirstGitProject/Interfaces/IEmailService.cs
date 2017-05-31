using MyFirstGitProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGitProject.Interfaces
{
    public interface IEmailService
    {
        bool Send(Email email);
    }
}
