namespace SkillTreeHomeWork.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountBook")]
    public partial class AccountBookModel
    {
        public Guid Id { get; set; }

        public int Category { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string Remark { get; set; }
    }
}
