﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillTreeHomeWork.Models.ViewModels
{
    public class NoteBookModels
    {
        public int NoteBookID { get; set; }
        public string Category { get; set; }
        public int Money { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}