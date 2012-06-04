using System.Collections.Generic;

namespace Testr.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> Answers { get; set; }
        public int CorrectAnswer { get; set; }
    }
}