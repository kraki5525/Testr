using System;
using System.Data;

namespace Testr.Models.Queries
{
    public interface IQuery<T>
    {
        T Execute(IDbConnection connection, IDbTransaction transaction);
    }
}