using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkillTreeHomeWork.Models.ViewModels;

namespace SkillTreeHomeWork.Controllers
{
    public class Day1Controller : Controller
    {
        // GET: Day1
        public ActionResult Index()
        {
            List<Day1> viewModelDay1 = new List<Day1>();

            for (int i = 0; i < 5; i++)
            {
                string strCategory = "支出";

                if (i % 2 == 0)
                {
                    strCategory = "收入";
                }

                var model = new Day1
                {
                    Day1ID = i,
                    Category = strCategory,
                    Money = 1000 * i,
                    Date = DateTime.Now.AddDays(i)
                };

                viewModelDay1.Add(model);
            }

            return View(viewModelDay1);
        }

        [ChildActionOnly]
        public ActionResult Day1ChildAction()
        {
            List<Day1> viewModelDay1 = new List<Day1>();

            for (int i = 0; i < 10; i++)
            {
                string strCategory = "支出";

                if (i % 3 == 0)
                {
                    strCategory = "收入";
                }

                var model = new Day1
                {
                    Day1ID = i,
                    Category = strCategory,
                    Money = 1000 * i,
                    Date = DateTime.Now.AddDays(i)
                };

                viewModelDay1.Add(model);
            }
            
            return View(viewModelDay1);
        }


    }
}