﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineRezervacijaBioskopskihKarata.Models;

namespace OnlineRezervacijaBioskopskihKarata.Controllers
{
    public class ProjectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projections
        public ActionResult Index()
        {
            return View(db.Projections.ToList());
        }

        public ActionResult AllProjections()
        {
            return View(db.Projections.ToList());
        }

        public ActionResult BuyTickets(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            return View(db.Projections.Include(x => x.Reservations).FirstOrDefault(x=>x.Id==id));
        }
        [HttpPost]
        public ActionResult BuyTickets(int id, string selectedSeats)
        {
            Projection projection = db.Projections.Find(id);
            List<string> selected = selectedSeats.Split(',').ToList();
            string orderId = Guid.NewGuid().ToString();
            
            foreach (string s in selected)
            {
                int row = Convert.ToInt32( s.Split('r')[1].Split('c')[0]);
                int col = Convert.ToInt32( s.Split('r')[1].Split('c')[1]);
                string guid = Guid.NewGuid().ToString();
                db.Reservations.Add(new Reservation() { 
                    Column=col,
                    Row=row,
                    OrderId=orderId,
                    ProjectionId=id,
                    TicketGuid=guid
                });
            }
            db.SaveChanges();
            return RedirectToAction("index");
        }

        // GET: Projections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            return View(projection);
        }

        // GET: Projections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartTime,EndTime,Date,TicketCost")] Projection projection)
        {
            if (ModelState.IsValid)
            {
                db.Projections.Add(projection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projection);
        }

        // GET: Projections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            return View(projection);
        }

        // POST: Projections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartTime,EndTime,Date,TicketCost")] Projection projection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projection);
        }

        // GET: Projections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            return View(projection);
        }

        // POST: Projections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projection projection = db.Projections.Find(id);
            db.Projections.Remove(projection);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
