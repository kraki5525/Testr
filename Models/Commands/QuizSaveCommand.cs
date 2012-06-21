using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using Dapper;

namespace Testr.Models.Commands
{
    public class QuizSaveCommand : ICommand
    {
        public Quiz Quiz { get; set; }

        public QuizSaveCommand(Quiz quiz)
        {
            this.Quiz = quiz;
        }

        public void Execute(IDbConnection connection)
        {
            using (var transaction = connection.BeginTransaction())
            {
                connection.Execute("insert into quiz select @name", new { name = Quiz.Name }, transaction);
            }
        }
    }
}