using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkillTreeHomeWork.Startup))]
namespace SkillTreeHomeWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
