using System;

using Nancy;
using Nancy.Bootstrappers.Autofac;
using Nancy.Conventions;

namespace Testr
{
    public class TestrBootstrapper : DefaultNancyBootstrapper //AutofacNancyBootstrapper
    {
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Content"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts"));
        }
    }
}