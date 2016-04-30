using System;
using System.Web.Mvc;
using System.Web.Routing;
using AspCourseProject.Domain;
using AspCourseProject.Domain.Context;
using AspCourseProject.Domain.Interfaces;
using Ninject;

namespace AspCourseProject.WebUI.Interface
{
    // реализация пользовательской фабрики контроллеров,
    // наследуясь от фабрики используемой по умолчанию
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
       Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IPersonRepository>().To<EFPersonRepository>();
            ninjectKernel.Bind<IVoteRepository>().To<EFVoteRepository>();
            ninjectKernel.Bind<IVoteItemsRepository>().To<EFVoteItemsRepository>();
            // конфигурирование контейнера
        }
    }
}