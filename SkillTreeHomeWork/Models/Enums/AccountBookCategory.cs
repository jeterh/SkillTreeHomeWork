using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillTreeHomeWork.Models.Enums
{
    public enum AccountBookCategory
    {
        [Display(Name = "支出")]
        expend = 0,
        [Display(Name = "收入")]
        income = 1
    }
}