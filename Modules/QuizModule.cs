using System.Data;
using System.Data.SQLite;

using Dapper;

using Nancy;
using Nancy.ModelBinding;

using Testr.Models;
using Testr.Models.Commands;
using Testr.Models.Queries;

namespace Testr.Modules
{
    public class QuizModule : NancyModule
    {
        public QuizModule(Repository repository) : base("/quiz")
        {
            Get["/{id}/"] = o =>
                                  {
                                      using (var connection = new SQLiteConnection("data.db"))
                                      {
                                          var quiz = repository.Load(new QuizByIdQuery(o.id));
                                          return View["Quiz", quiz];
                                      }
                                  };
            Get["/new/"] = o =>
                                {
                                    ViewBag.Title = "New Quiz";
                                    return View["EditQuiz", null];
                                };

            Post["/new/"] = o =>
                                {
                                    var quiz = this.Bind<Quiz>();
                                    var quizSaveCommand = new QuizSaveCommand(quiz);

                                    repository.Execute(quizSaveCommand);

                                    return View["EditQuiz", quiz];
                                };
        }
    }
}