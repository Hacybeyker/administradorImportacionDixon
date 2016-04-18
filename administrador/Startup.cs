using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(administrador.Startup))]
namespace administrador
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
