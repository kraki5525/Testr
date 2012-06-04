using System.Data;
using Nancy;
using Nancy.Bootstrapper;
using TinyIoC;

namespace Testr
{
    public class TestrBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
        }
    }
}