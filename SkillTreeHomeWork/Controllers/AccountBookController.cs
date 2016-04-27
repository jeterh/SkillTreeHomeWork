using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkillTreeHomeWork.Models.ViewModels;
using System.Data.Entity;
using System.Net;

namespace SkillTreeHomeWork.Controllers
{
    public class AccountBookController : Controller
    {
        private AccountBookDbContext db = new AccountBookDbContext();

        // GET: AccountBook
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult AccountBookChildAction()
        {
            return View(db.AccountBook.Take(10).OrderByDescending(x => x.Date).ToList());
        }

        // POST: AccountBook/Index
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Category,Amount,Date,Remark")] AccountBookModels accountBookModels)
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