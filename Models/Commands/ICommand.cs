using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Testr.Models.Commands
{
    public interface ICommand
    {
        void Execute(IDbConnection connection);
    }
}
