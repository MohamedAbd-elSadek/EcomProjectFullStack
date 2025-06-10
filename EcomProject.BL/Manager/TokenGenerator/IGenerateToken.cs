using EcomProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.TokenGenerator
{
    public interface IGenerateToken
    {
        string GetAndCreateToken(User user);
    }
}
