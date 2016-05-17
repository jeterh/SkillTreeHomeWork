using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkillTreeHomeWork.Models.ViewModels;
using System.Data.Entity;
using System.Net;
using SkillTreeHomeWork.Service;
using SkillTreeHomeWork.Repositories;

namespace SkillTreeHomeWork.Controllers
{
    public class AccountBookController : Controller
    {
        private readonly AccountBookService _accountBookSvc;

        //private AccountBookDbContext db = new AccountBookDbContext();

        public AccountBookController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountBookSvc = new AccountBookService(unitOfWork);
        }

        // GET: AccountBook
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult AccountBookChildAction(int? year, int? month)
        {
            IEnumerable<AccountBookViewModels> accountBookViewModels = Enumerable.Empty<AccountBookViewModels>();

            if (year.HasValue && month.HasValue)
            {
                accountBookViewModels = _accountBookSvc.LookupByYearMonth(year, month);
            }
            else if (year.HasValue && !month.HasValue)
            {
                accountBookViewModels = _accountBookSvc.LookupByYear(year);
            }
            else
            {
                accountBookViewModels = _accountBookSvc.Lookup();
            }

            return View(accountBookViewModels.OrderByDescending(x => x.Date).ToList());
                
            //var source = _accountBookSvc.Lookup();
            //return View(source.OrderByDescending(x => x.Date).ToList());
            //return View(db.AccountBook.Take(10).OrderByDescending(x => x.Date).ToList());
        }

        // POST: AccountBook/Index
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Category,Amount,Date,Remark")] AccountBookViewModels accountBookViewModels)
        {
            //if (ModelState.IsValid)
            //{
                //accountBookModels.Id = Guid.NewGuid();
                //db.AccountBook.Add(accountBookModels);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            //}

            //return View(accountBookModels);

            if (ModelState.IsValid)
            {
                accountBookViewModels.Id = Guid.NewGuid();
                _accountBookSvc.Add(accountBookViewModels);
                _accountBookSvc.Save();

                return RedirectToAction("Index");
            }

            var result = new AccountBookViewModels()
            {
                Id = accountBookViewModels.Id,
                Amount = accountBookViewModels.Amount,
                Category = accountBookViewModels.Category,
                Date = accountBookViewModels.Date,
                Remark = accountBookViewModels.Remark
            };

            return View(result);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}