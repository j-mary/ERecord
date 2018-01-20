using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERecord.Startup))]
namespace ERecord
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
