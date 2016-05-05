using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SkillTreeHomeWork.Models.CustomValidationAttribute
{
    public class DateBeforeTodayAttribute : ValidationAttribute
    {
        protected sealed override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //權責分清楚，沒有輸入不算錯
            if (value == null)
            {
                return ValidationResult.Success;
            }

            DateTime myDateTime = DateTime.Parse(value.ToString());              

            if (DateTime.Compare(myDateTime.Date, DateTime.Now.Date) == 1)
            {
                return new ValidationResult("日期不得大於今天。");
            }

            return ValidationResult.Success;
        }
    }
}