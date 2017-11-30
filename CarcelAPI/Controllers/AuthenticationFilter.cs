using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CarcelAPI.Models;

namespace CarcelAPI.Controllers
{
    public class AuthenticationFilter : AuthorizeAttribute
    {
        private CarcelDbContext context = new CarcelDbContext();

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string AccesTokenFromRequest = "";

            if (actionContext.Request.Headers.Authorization != null)
            {
                AccesTokenFromRequest = actionContext.Request.Headers.Authorization.Parameter;

                if (context.Usuarios.Where(u => u.Token == AccesTokenFromRequest).Count() > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}