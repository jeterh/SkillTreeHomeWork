using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkillTreeHomeWork.Models.ViewModels;

namespace SkillTreeHomeWork.Controllers
{
    public class NoteBookController : Controller
    {
        // GET: NoteBook
        public ActionResult Index()
        {
            List<NoteBookModels> viewModelNoteBook = new List<NoteBookModels>();

            for (int i = 0; i < 5; i++)
            {
                string strCategory = "支出";

                if (i % 2 == 0)
                {
                    strCategory = "收入";
                }

                var model = new NoteBookModels
                {
                    NoteBookID = 1000 + i,
                    Category = strCategory,
                    Money = 1000 * i,
                    Date = DateTime.Now.AddDays(i)
                };

                viewModelNoteBook.Add(model);
            }

            return View(viewModelNoteBook);
        }

        [ChildActionOnly]
        public ActionResult NoteBookChildAction()
        {
            List<NoteBookModels> viewModelNoteBook = new List<NoteBookModels>();

            for (int i = 0; i < 10; i++)
            {
                string strCategory = "支出";

                if (i % 3 == 0)
                {
                    strCategory = "收入";
                }

                var model = new NoteBookModels
                {
                    NoteBookID = i,
                    Category = strCategory,
                    Money = 1000 * i,
                    Date = DateTime.Now.AddDays(i)
                };

                viewModelNoteBook.Add(model);
            }
            
            return View(viewModelNoteBook);
        }


    }
}