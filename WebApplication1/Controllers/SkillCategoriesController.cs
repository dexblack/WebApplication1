using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SkillCategoriesController : Controller
    {
        private WebApplication1Entities1 db = new WebApplication1Entities1();

        // GET: SkillCategories
        public ActionResult Index()
        {
            return View(db.SkillCategories.ToList());
        }

        // GET: SkillCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillCategory skillCategory = db.SkillCategories.Find(id);
            if (skillCategory == null)
            {
                return HttpNotFound();
            }
            return View(skillCategory);
        }

        // GET: SkillCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] SkillCategory skillCategory)
        {
            if (ModelState.IsValid)
            {
                db.SkillCategories.Add(skillCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skillCategory);
        }

        // GET: SkillCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillCategory skillCategory = db.SkillCategories.Find(id);
            if (skillCategory == null)
            {
                return HttpNotFound();
            }
            return View(skillCategory);
        }

        // POST: SkillCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] SkillCategory skillCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skillCategory);
        }

        // GET: SkillCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillCategory skillCategory = db.SkillCategories.Find(id);
            if (skillCategory == null)
            {
                return HttpNotFound();
            }
            return View(skillCategory);
        }

        // POST: SkillCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SkillCategory skillCategory = db.SkillCategories.Find(id);
            db.SkillCategories.Remove(skillCategory);
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
