using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace MechTrackV2.Controllers
{
    public class ForcesController : Controller
    {
        private MechTrackContext db = new MechTrackContext();

        // GET: Forces
        public ActionResult Index()
        {
            var forces = db.Forces.Include(f => f.Player);
            return View(forces.ToList());
        }

        // GET: Forces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Machine> forceMachines = db.Machines.Where(m => m.ForceID == id).ToList();
            if (forceMachines == null)
            {
                return HttpNotFound();
            }
            return View(forceMachines);
        }

        // GET: Forces/Create
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name");
            return View();
        }

        // POST: Forces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ForceID,Name,ForceType,PlayerID,ParentForceID")] Force force)
        {
            if (ModelState.IsValid)
            {
                db.Forces.Add(force);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", force.PlayerID);
            return View(force);
        }

        // GET: Forces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Force force = db.Forces.Find(id);
            if (force == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", force.PlayerID);
            return View(force);
        }

        // POST: Forces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ForceID,Name,ForceType,PlayerID,ParentForceID")] Force force)
        {
            if (ModelState.IsValid)
            {
                db.Entry(force).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", force.PlayerID);
            return View(force);
        }

        // GET: Forces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Force force = db.Forces.Find(id);
            if (force == null)
            {
                return HttpNotFound();
            }
            return View(force);
        }

        // POST: Forces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Force force = db.Forces.Find(id);
            db.Forces.Remove(force);
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
