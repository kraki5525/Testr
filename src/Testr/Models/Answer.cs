using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testr.Models
{
    public class Answer
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsDeleted { get; set; }
    }

}