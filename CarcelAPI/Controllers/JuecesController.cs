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
    public class JuecesController : ApiController
    {
        private CarcelDbContext context;

        public JuecesController()
        {
            context = new CarcelDbContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Jueces.ToList();
        }

        public IHttpActionResult post(Juez juez)
        {
            context.Jueces.Add(juez);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }

            return Ok(new { mensaje = "Agregado correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Juez juez = context.Jueces.Find(id);

            if (juez == null) return NotFound();

            context.Jueces.Remove(juez);

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Eliminado Correctamente" });
            }

            return InternalServerError();
        }

        public IHttpActionResult put(Juez juez)
        {
            context.Entry(juez).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Modificado Correctamente" });
            }

            return InternalServerError();
        }
    }
}