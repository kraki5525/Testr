using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using Dapper;

namespace Testr.Models.Queries
{
    public class AllQuizesQuery : IQuery<IEnumerable<Quiz>>
    {
        public IEnumerable<Quiz> Execute(IDbConnection connection, IDbTransaction transaction = null)
        {
            var quizes = connection.Query<Quiz>("select id, name from Quiz").ToArray();
            quizes.Each(quiz =>
                {
                    quiz.Questions = (from q in connection.Query<Question>("select * from Question where quiz_id = @id", new { id = quiz.Id })
                                   orderby q.SortOrder
                                   select new Question
                                   {
                                       Id = q.Id,
                                       Text = q.Text,
                                       Answers = connection.Query<Answer>("select * from Answer where question_id = @id", new { id = q.Id })
                                   }).ToArray();
                });

            return quizes;
        }
    }
}