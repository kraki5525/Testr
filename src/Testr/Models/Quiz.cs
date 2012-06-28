using System.Collections.Generic;
using System.Linq;

namespace Testr.Models
{
    public class Quiz
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public int QuestionCount 
        {
            get { return (Questions ?? Enumerable.Empty<Question>()).Count(); }
        }
    }
}