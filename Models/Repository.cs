using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.Common;

using Testr.Models.Commands;
using Testr.Models.Queries;

namespace Testr.Models
{
    public class Repository
    {
        public T Load<T>(IQuery<T> query)
        {
            var cs = ConfigurationManager.ConnectionStrings["db"];
            var factory = DbProviderFactories.GetFactory(cs.ProviderName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = cs.ConnectionString;
                connection.Open();

                return query.Execute(connection);
            }
        }

        public void Execute(ICommand command)
        {
            var cs = ConfigurationManager.ConnectionStrings["db"];
            var factory = DbProviderFactories.GetFactory(cs.ProviderName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = cs.ConnectionString;
                connection.Open();

                command.Execute(connection);
            }
        }
    }
}