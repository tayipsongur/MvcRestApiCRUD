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
using MvcRestApiCRUD.Models;

namespace MvcRestApiCRUD.Controllers
{
    public class CalisanlarController : ApiController
    {
        private KurulusEntities db = new KurulusEntities();

        // GET: api/Calisanlar
        public IQueryable<Calisanlar> GetCalisanlars()
        {
            return db.Calisanlars;
        }

        // GET: api/Calisanlar/5
        [ResponseType(typeof(Calisanlar))]
        public IHttpActionResult GetCalisanlar(int id)
        {
            Calisanlar calisanlar = db.Calisanlars.Find(id);
            if (calisanlar == null)
            {
                return NotFound();
            }

            return Ok(calisanlar);
        }

        // PUT: api/Calisanlar/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalisanlar(int id, Calisanlar calisanlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calisanlar.CalisanID)
            {
                return BadRequest();
            }

            db.Entry(calisanlar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalisanlarExists(id))
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

        // POST: api/Calisanlar
        [ResponseType(typeof(Calisanlar))]
        public IHttpActionResult PostCalisanlar(Calisanlar calisanlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calisanlars.Add(calisanlar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calisanlar.CalisanID }, calisanlar);
        }

        // DELETE: api/Calisanlar/5
        [ResponseType(typeof(Calisanlar))]
        public IHttpActionResult DeleteCalisanlar(int id)
        {
            Calisanlar calisanlar = db.Calisanlars.Find(id);
            if (calisanlar == null)
            {
                return NotFound();
            }

            db.Calisanlars.Remove(calisanlar);
            db.SaveChanges();

            return Ok(calisanlar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalisanlarExists(int id)
        {
            return db.Calisanlars.Count(e => e.CalisanID == id) > 0;
        }
    }
}