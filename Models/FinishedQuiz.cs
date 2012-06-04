using System.Collections.Generic;

namespace Testr.Models
{
    public class FinishedQuiz
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public float Score { get; set; }
        public IEnumerable<int> SelectedAnswers { get; set; }
    }
}