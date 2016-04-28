using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using SkillTreeHomeWork.Models.CustomValidationAttribute;

namespace SkillTreeHomeWork.Models.ViewModels
{
    [Table("AccountBook")]
    public partial class AccountBookModels
    {
        public Guid Id { get; set; }
        public int Category { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
    }
}