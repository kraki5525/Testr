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
        public IEnumerable<Quiz> Execute(IDbConnection connection)
        {
            return connection.Query<Quiz>("select id, name from Quiz").ToArray();
        }
    }
}