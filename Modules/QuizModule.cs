using System.Data;
using Nancy;

namespace Testr.Modules
{
    public class QuizModule : NancyModule
    {
        public QuizModule(IDbConnection connection) : base("/quiz")
        {
            Get["/{name}/"] = o =>
                                  {
                                      using ()
                                  };
        }
    }
}