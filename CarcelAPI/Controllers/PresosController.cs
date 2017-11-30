using CarcelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CarcelAPI.Controllers
{
    [AuthenticationFilter]
    public class PresosController : ApiController
    {
        private CarcelDbContext context;

        public PresosController()
        {
            context = new CarcelDbContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Presos.ToList();
        }

        public IHttpActionResult post(Preso preso)
        {
            context.Presos.Add(preso);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }

            return Ok(new { mensaje = "Agregado correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Preso preso = context.Presos.Find(id);

            if (preso == null) return NotFound();

            context.Presos.Remove(preso);

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Eliminado Correctamente" });
            }

            return InternalServerError();
        }

        public IHttpActionResult put(Preso preso)
        {
            context.Entry(preso).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Modificado Correctamente" });
            }

            return InternalServerError();
        }
    }
}