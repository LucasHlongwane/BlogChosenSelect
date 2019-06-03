using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog20190528.Models;

namespace Blog20190528.Controllers
{
    public class LookUpsController : Controller
    {
        private Blog20190528Context db = new Blog20190528Context();

        // GET: LookUps
        public ActionResult Index()
        {
            var lookUps = db.LookUps.Include(l => l.Category).Include(l => l.Post);
            return View(lookUps.ToList());
        }

        // GET: LookUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LookUp lookUp = db.LookUps.Find(id);
            if (lookUp == null)
            {
                return HttpNotFound();
            }
            return View(lookUp);
        }

        // GET: LookUps/Create
        public ActionResult Create()
        {
            ViewBag.catRef = new SelectList(db.Categories, "Id", "Name");
            ViewBag.postRef = new SelectList(db.Posts, "postId", "postTitle");
            return View();
        }

        // POST: LookUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lookupId,catRef,postRef")] LookUp lookUp)
        {
            if (ModelState.IsValid)
            {
                db.LookUps.Add(lookUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catRef = new SelectList(db.Categories, "Id", "Name", lookUp.catRef);
            ViewBag.postRef = new SelectList(db.Posts, "postId", "postTitle", lookUp.postRef);
            return View(lookUp);
        }

        // GET: LookUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LookUp lookUp = db.LookUps.Find(id);
            if (lookUp == null)
            {
                return HttpNotFound();
            }
            ViewBag.catRef = new SelectList(db.Categories, "Id", "Name", lookUp.catRef);
            ViewBag.postRef = new SelectList(db.Posts, "postId", "postTitle", lookUp.postRef);
            return View(lookUp);
        }

        // POST: LookUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lookupId,catRef,postRef")] LookUp lookUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lookUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catRef = new SelectList(db.Categories, "Id", "Name", lookUp.catRef);
            ViewBag.postRef = new SelectList(db.Posts, "postId", "postTitle", lookUp.postRef);
            return View(lookUp);
        }

        // GET: LookUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LookUp lookUp = db.LookUps.Find(id);
            if (lookUp == null)
            {
                return HttpNotFound();
            }
            return View(lookUp);
        }

        // POST: LookUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LookUp lookUp = db.LookUps.Find(id);
            db.LookUps.Remove(lookUp);
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
