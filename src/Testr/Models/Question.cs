using System.Collections.Generic;

namespace Testr.Models
{
    public class Question
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public int SortOrder { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public bool IsDeleted { get; set; }
    }
}