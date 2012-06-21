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
            return connection.Query<Quiz>("select * from Quiz where id = @id", new { id = Id }).FirstOrDefault();
        }
    }
}