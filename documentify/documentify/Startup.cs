using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(documentify.Startup))]
namespace documentify
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
