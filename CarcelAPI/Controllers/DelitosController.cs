using CarcelAPI.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CarcelAPI.Controllers
{
    [AuthenticationFilter]
    public class DelitosController : ApiController
    {
        private CarcelDbContext context;

        public DelitosController()
        {
            context = new CarcelDbContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Delitos.ToList();
        }

        //public IHttpActionResult get(int id)
        //{
        //    OracleParameter param1 = new OracleParameter("codigo", id);

        //    try
        //    {
        //        Delito delito =
        //       context.Database
        //       .SqlQuery<Delito>("begin sp_buscar_delitos(:codigo); end;", 
        //       param1);

        //        return Ok(delito);
        //    }
        //    catch (Exception)
        //    {
        //        return NotFound();
        //    }
        //}

        //public IHttpActionResult post(Delito delito)
        //{
        //    context.Delitos.Add(delito);
        //    int filasAfectadas = context.SaveChanges();

        //    if (filasAfectadas == 0)
        //    {
        //        return InternalServerError();
        //    }

        //    return Ok(new { mensaje = "Agregado correctamente" });
        //}

        public IHttpActionResult post(Delito delito)
        {
            OracleParameter param1 = new OracleParameter("nombre", delito.Nombre);
            OracleParameter param2 = new OracleParameter("conmin", delito.CondenaMinima);
            OracleParameter param3 = new OracleParameter("conmax", delito.CondenaMaxima);

            try
            {
                context.
                    Database
                    .ExecuteSqlCommand("begin sp_agregar_delito(:nombre, :conmin, :conmax); end;", param1, param2, param3);

                return Ok(new { mensaje = "Delito Agregado correctamente" });

            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        public IHttpActionResult delete(int id)
        {
            Delito delito = context.Delitos.Find(id);

            if (delito == null) return NotFound();

            context.Delitos.Remove(delito);

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Eliminado Correctamente" });
            }

            return InternalServerError();
        }

        public IHttpActionResult put(Delito delito)
        {
            context.Entry(delito).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Modificado Correctamente" });
            }

            return InternalServerError();
        }
    }
}