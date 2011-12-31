using Ninject.Modules;
using Delicious.Services;

namespace Delicious.Sample.Console
{
    class DeliciousModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConnection>().To<Connection>();
            Bind<IPostService>().To<PostService>();
            Bind<ITagService>().To<TagService>();
            Bind<IBundleService>().To<BundleService>();
        }
    }
}
