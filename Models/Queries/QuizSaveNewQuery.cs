using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using Dapper;

namespace Testr.Models.Queries
{
    public class QuizSaveNewQuery : IQuery<Quiz>
    {
        public Quiz Quiz { get; set; }

        public QuizSaveNewQuery(Quiz quiz)
        {
            this.Quiz = quiz;
        }

        public Quiz Execute(IDbConnection connection)
        {
            using (var transaction = connection.BeginTransaction())
            {
                Quiz.Id = connection.Execute("insert into quiz (name) values (@name)", new { name = Quiz.Name }, transaction);
                return Quiz;
            }
        }
    }
}