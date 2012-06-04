using Nancy;

namespace Testr.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = o => View["Index"];
        }
    }
}