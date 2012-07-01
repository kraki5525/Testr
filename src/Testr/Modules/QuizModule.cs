using System.Data;
using System.Data.SQLite;
using System.Linq;

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
            Get["/list/"] = o =>
                                {
                                    ViewBag.Title = "Quiz List";
                                    var quizes = repository.Load(new AllQuizesQuery());
                                    return View["Quiz/List", quizes];
                                };
            Get["/{id}/edit/"] = o =>
                                {
                                    ViewBag.Title = "Edit Quiz";
                                    var quiz = repository.Load(new QuizByIdQuery(o.id));
                                    return View["Quiz/Edit", quiz];
                                };
            Get["/new/"] = o =>
                                {
                                    ViewBag.Title = "New Quiz";
                                    return View["Quiz/Edit", null];
                                };

            Post["/new/"] = o =>
                                {
                                    var quiz = this.Bind<Quiz>();
                                    var quizSaveNewQuery = new QuizSaveNewQuery(quiz);

                                    quiz = repository.Save(quizSaveNewQuery);

                                    return Response.AsRedirect(string.Format("/quiz/{0}/", quiz.Id));
                                };

            Get["/{id}/take/"] = o =>
                                {
                                    var quiz = repository.Load(new QuizByIdQuery(o.id));
                                    ViewBag.Title = "Taking " + quiz.Name;

                                    return View["Quiz/Take", quiz];
                                };

            Get["/{id}/take/{step}/"] = o =>
                                {
                                    var step = (int)(o.step ?? 0);
                                    var quiz = repository.Load(new QuizByIdQuery(o.id));

                                    if (step >= quiz.Questions.Count())
                                    {
                                        return Response.AsRedirect(string.Format("/quiz/review/{0}/", quiz.Id));
                                    }

                                    var question = quiz.Questions.Skip(step).First();

                                    return Response.AsJson(question);
                                };

            Get["/{id}/"] = o =>
            {
                var quiz = repository.Load(new QuizByIdQuery(o.id));
                ViewBag.Title = quiz.Name;
                return View["Quiz/View", quiz];
            };

        }
    }
}