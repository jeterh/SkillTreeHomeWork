using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using SkillTreeHomeWork.Models.CustomValidationAttribute;

namespace SkillTreeHomeWork.Models.ViewModels
{
    public class AccountBookViewModels
    {
        [Display(Name = "記事本ID")]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "類別")]
        [Required]
        public int Category { get; set; }

        [Display(Name = "金額")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0}需為正整數")]
        public int Amount { get; set; }

        [Display(Name = "日期")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [DateBeforeToday]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [Required]
        [DataType(DataType.MultilineText)]
        [MultilineTextLimitAttribute(100)]
        public string Remark { get; set; }
    }
}