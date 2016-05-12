using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkillTreeHomeWork.Models.ViewModels;

namespace SkillTreeHomeWork.Areas.Admin.Controllers
{
    public class AccountBookController : Controller
    {
        private AccountBookDbContext db = new AccountBookDbContext();

        // GET: Admin/AccountBook
        public ActionResult Index()
        {
            return View(db.AccountBook.ToList());
        }

        // GET: Admin/AccountBook/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBookModels accountBookModels = db.AccountBook.Find(id);
            if (accountBookModels == null)
            {
                return HttpNotFound();
            }
            return View(accountBookModels);
        }

        // GET: Admin/AccountBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AccountBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Amount,Date,Remark")] AccountBookModels accountBookModels)
        {
            if (ModelState.IsValid)
            {
                accountBookModels.Id = Guid.NewGuid();
                db.AccountBook.Add(accountBookModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountBookModels);
        }

        // GET: Admin/AccountBook/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBookModels accountBookModels = db.AccountBook.Find(id);
            if (accountBookModels == null)
            {
                return HttpNotFound();
            }
            return View(accountBookModels);
        }

        // POST: Admin/AccountBook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Amount,Date,Remark")] AccountBookModels accountBookModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountBookModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountBookModels);
        }

        // GET: Admin/AccountBook/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBookModels accountBookModels = db.AccountBook.Find(id);
            if (accountBookModels == null)
            {
                return HttpNotFound();
            }
            return View(accountBookModels);
        }

        // POST: Admin/AccountBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AccountBookModels accountBookModels = db.AccountBook.Find(id);
            db.AccountBook.Remove(accountBookModels);
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
