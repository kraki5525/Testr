using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using Dapper;

namespace Testr.Models.Queries
{
    public class QuizByIdQuery : IQuery<Quiz>
    {
        public long Id { get; set; }

        public QuizByIdQuery(int id)
        {
            Id = id;
        }

        public Quiz Execute(System.Data.IDbConnection connection, IDbTransaction transaction = null)
        {
            var quiz = connection.Query<Quiz>("select * from Quiz where id = @id", new { id = Id }).FirstOrDefault();
            quiz.Questions = (from q in connection.Query<Question>("select * from Question where quiz_id = @id", new { id = Id })
                              orderby q.SortOrder
                              select new Question
                              {
                                  Id = q.Id,
                                  Text = q.Text,
                                  Answers = connection.Query<Answer>("select * from Answer where question_id = @id", new { id = q.Id })
                              }).ToArray();

            return quiz;
        }
    }
}