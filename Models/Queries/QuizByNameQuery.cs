using System;
using System.Data;
using System.Linq;

using Dapper;

namespace Testr.Models.Queries
{
    public class QuizByNameQuery : IQuery<Quiz>
    {
        public string Name { get; set; }

        public QuizByNameQuery(string name)
        {
            Name = name;
        }

        public Quiz Execute(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<Quiz>("select Id, Name from Quiz where name = @name", new { name = Name }).First();
        }
    }
}