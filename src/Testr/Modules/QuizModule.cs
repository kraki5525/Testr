using System.Data;
using System.Data.SQLite;
using System.Linq;

using Dapper;

using Nancy;
using Nancy.ModelBinding;

using Testr.Models;
using Testr.Models.Commands;
using Testr.Models.Queries;
using System;
using System.IO;

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

            Get["/{id}/review/"] = o =>
                                {
                                    return Response.AsRedirect("/");
                                };

            Get["/{id}/take/{step}/"] = o =>
                                {
                                    var step = (int)(o.step ?? 0);
                                    var quiz = repository.Load(new QuizByIdQuery(o.id));
                                    var contents = "";

                                    if (step >= quiz.Questions.Count())
                                    {
                                        using (var stream = new MemoryStream())
                                        {
                                            var x = View["Quiz/Review", quiz];
                                            x.Contents(stream);

                                            stream.Position = 0;
                                            using (var reader = new StreamReader(stream))
                                            {
                                                contents = reader.ReadToEnd();
                                            }
                                        }

                                        return Response.AsJson(new
                                        {
                                            type = "Review",
                                            value = contents
                                        });                                      
                                    }

                                    var question = quiz.Questions.Skip(step).First();

                                    return Response.AsJson(new
                                    {
                                        type = "Question",
                                        value = question
                                    });
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