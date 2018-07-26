using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GameStore.Services.Interfaces;
using GameStore.Services.Services;

namespace GameStore.Web.Infrastructure
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<GameServices>().As<IGameServices>();
            builder.RegisterType<CommentsServices>().As<ICommentsServices>();
            builder.RegisterType<GenreServices>().As<IGenreServices>();
            builder.RegisterType<PlatformServices>().As<IPlatformServices>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}