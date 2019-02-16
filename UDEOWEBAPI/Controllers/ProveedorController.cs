using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UDEOWEBAPI.Models;

namespace UDEOWEBAPI.Controllers
{
    public class ProveedorController : ApiController
    {
        private PROVEEDORESEntities db = new PROVEEDORESEntities();

        // GET: api/Proveedor
        public IQueryable<Proveedor> GetProveedors()
        {
            return db.Proveedors;
        }

        // GET: api/Proveedor/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult GetProveedor(int id)
        {
            Proveedor proveedor = db.Proveedors.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        // PUT: api/Proveedor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProveedor(int id, Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedor.id)
            {
                return BadRequest();
            }

            db.Entry(proveedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Proveedor
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult PostProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proveedors.Add(proveedor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proveedor.id }, proveedor);
        }

        // DELETE: api/Proveedor/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult DeleteProveedor(int id)
        {
            Proveedor proveedor = db.Proveedors.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            db.Proveedors.Remove(proveedor);
            db.SaveChanges();

            return Ok(proveedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProveedorExists(int id)
        {
            return db.Proveedors.Count(e => e.id == id) > 0;
        }
    }
}