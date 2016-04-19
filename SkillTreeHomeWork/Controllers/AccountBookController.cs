using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkillTreeHomeWork.Models.ViewModels;

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
            return View(db.AccountBook.Take(10).ToList());
        }

    }
}