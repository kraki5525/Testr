using System.Collections.Generic;

namespace Testr.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}