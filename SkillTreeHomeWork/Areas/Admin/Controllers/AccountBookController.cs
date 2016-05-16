using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkillTreeHomeWork.Models.ViewModels;
using SkillTreeHomeWork.Service;
using SkillTreeHomeWork.Repositories;

namespace SkillTreeHomeWork.Areas.Admin.Controllers
{
    public class AccountBookController : Controller
    {
        private readonly AccountBookService _accountBookSvc;

        public AccountBookController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountBookSvc = new AccountBookService(unitOfWork);
        }

        // GET: Admin/AccountBook
        public ActionResult Index()
        {
            var source = _accountBookSvc.Lookup();
            return View(source.OrderByDescending(x => x.Date).ToList());
        }

        // GET: Admin/AccountBook/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AccountBookViewModels accountBookViewModels = _accountBookSvc.LookupByGuid(id);

            if (accountBookViewModels == null)
            {
                return HttpNotFound();
            }

            return View(accountBookViewModels);
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

        public ActionResult Create([Bind(Include = "Id,Category,Amount,Date,Remark")] AccountBookViewModels accountBookViewModels)
        {
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

            return View(accountBookViewModels);
        }

        // GET: Admin/AccountBook/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AccountBookViewModels accountBookViewModels = _accountBookSvc.LookupByGuid(id);
            
            if (accountBookViewModels == null)
            {
                return HttpNotFound();
            }
            return View(accountBookViewModels);
        }

        // POST: Admin/AccountBook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Amount,Date,Remark")] AccountBookViewModels accountBookViewModels)
        {
            if (ModelState.IsValid)
            {
                _accountBookSvc.Edit(accountBookViewModels);
                _accountBookSvc.Save();

                return RedirectToAction("Index");
            }
            return View(accountBookViewModels);
        }

        // GET: Admin/AccountBook/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBookViewModels accountBookViewModels = _accountBookSvc.LookupByGuid(id);

            if (accountBookViewModels == null)
            {
                return HttpNotFound();
            }
            return View(accountBookViewModels);
        }

        // POST: Admin/AccountBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AccountBookViewModels accountBookViewModels = _accountBookSvc.LookupByGuid(id);

            if (accountBookViewModels == null)
            {
                return HttpNotFound();
            }

            _accountBookSvc.Remove(accountBookViewModels);
            _accountBookSvc.Save();

            return RedirectToAction("Index");
        }
    }
}
