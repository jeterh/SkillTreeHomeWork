using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SkillTreeHomeWork.Models.CustomValidationAttribute
{
    public class MultilineTextLimitAttribute : ValidationAttribute
    {
        private int _strLength;

        public MultilineTextLimitAttribute(int length)
        {
            _strLength = length;
        }
        
       protected sealed override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //權責分清楚，沒有輸入不算錯
            if (value == null)
            {
                return ValidationResult.Success;
            }
            
            if (value is string)
            {
                if (value.ToString().Length > _strLength)
                {
                    return new ValidationResult(string.Format("文字長度不得超過{0}字。", _strLength));
                }
            }
            
            return ValidationResult.Success;
        }

    }
}