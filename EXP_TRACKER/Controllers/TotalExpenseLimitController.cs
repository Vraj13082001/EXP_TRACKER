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
using EXP_TRACKER.Models;

namespace EXP_TRACKER.Controllers
{
    public class TotalExpenseLimitController : ApiController
    {
        private Expense_TrackerEntities db = new Expense_TrackerEntities();

        // GET: api/TotalExpenseLimit
        public IQueryable<TotalExpenseLimit> GetTotalExpenseLimits()
        {
            return db.TotalExpenseLimits;
        }

        // GET: api/TotalExpenseLimit/5
        [ResponseType(typeof(TotalExpenseLimit))]
        public IHttpActionResult GetTotalExpenseLimit(int id)
        {
            TotalExpenseLimit totalExpenseLimit = db.TotalExpenseLimits.Find(id);
            if (totalExpenseLimit == null)
            {
                return NotFound();
            }

            return Ok(totalExpenseLimit);
        }

        // PUT: api/TotalExpenseLimit/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTotalExpenseLimit(int id, TotalExpenseLimit totalExpenseLimit)
        {
            

            if (id != totalExpenseLimit.TotalExpenseId)
            {
                return BadRequest();
            }

            db.Entry(totalExpenseLimit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TotalExpenseLimitExists(id))
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

        // POST: api/TotalExpenseLimit
        [ResponseType(typeof(TotalExpenseLimit))]
        public IHttpActionResult PostTotalExpenseLimit(TotalExpenseLimit totalExpenseLimit)
        {
            

            db.TotalExpenseLimits.Add(totalExpenseLimit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = totalExpenseLimit.TotalExpenseId }, totalExpenseLimit);
        }

        // DELETE: api/TotalExpenseLimit/5
        [ResponseType(typeof(TotalExpenseLimit))]
        public IHttpActionResult DeleteTotalExpenseLimit(int id)
        {
            TotalExpenseLimit totalExpenseLimit = db.TotalExpenseLimits.Find(id);
            if (totalExpenseLimit == null)
            {
                return NotFound();
            }

            db.TotalExpenseLimits.Remove(totalExpenseLimit);
            db.SaveChanges();

            return Ok(totalExpenseLimit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TotalExpenseLimitExists(int id)
        {
            return db.TotalExpenseLimits.Count(e => e.TotalExpenseId == id) > 0;
        }
    }
}