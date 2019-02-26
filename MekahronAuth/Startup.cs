using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MekahronAuth.Startup))]
namespace MekahronAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
