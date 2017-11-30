using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using CarcelAPI.Models;

namespace CarcelAPI.Controllers
{
    public class LoginController : ApiController
    {
        private CarcelDbContext context;

        public LoginController()
        {
            this.context = new CarcelDbContext();
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        public IHttpActionResult post(Login login)
        {
            try
            {
                Usuario user = context.Usuarios.Where(u => u.UserName == login.UserName && u.Password
                == login.Password).FirstOrDefault();

                if (user == null)
                {
                    return Unauthorized();
                }

                if (user.Token != null)
                {
                    return Ok(new
                    {
                        Token = user.Token
                    });
                }

                String token = GetHashString(user.UserName);

                user.Token = token;
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;

                if (context.SaveChanges() > 0)
                {
                    return Ok(new
                    {
                        token = user.Token
                    });
                }
            return InternalServerError();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
