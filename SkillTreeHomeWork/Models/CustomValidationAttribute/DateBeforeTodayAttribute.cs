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
            if (value == null)
            {
                return new ValidationResult("請輸入日期。");
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