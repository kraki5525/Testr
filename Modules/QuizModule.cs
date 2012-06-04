using System.Data;
using System.Data.SQLite;
using Dapper;
using Nancy;
using Testr.Models;

namespace Testr.Modules
{
    public class QuizModule : NancyModule
    {
        public QuizModule() : base("/quiz")
        {
            Get["/{name}/"] = o =>
                                  {
                                      using (var connection = new SQLiteConnection("data.db"))
                                      {
                                          var quiz = connection.Query<Quiz>("", new {o.name});
                                          return View["Quiz", quiz];
                                      }
                                  };
        }
    }
}