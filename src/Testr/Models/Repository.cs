﻿using System;
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

                return query.Execute(connection, null);
            }
        }

        public T Save<T>(IQuery<T> query)
        {
            var cs = ConfigurationManager.ConnectionStrings["db"];
            var factory = DbProviderFactories.GetFactory(cs.ProviderName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = cs.ConnectionString;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var o = query.Execute(connection, transaction);
                        transaction.Commit();
                        return o;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}