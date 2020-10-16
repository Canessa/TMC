using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TMC.UI.StartUp))]
namespace TMC.UI
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}