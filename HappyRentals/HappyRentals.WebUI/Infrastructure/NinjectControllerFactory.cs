﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using HappyRentals.Domain.Abstract;
using HappyRentals.Domain.Concrete;

namespace HappyRentals.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {            
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        
        private void AddBindings()
        {
            ninjectKernel.Bind<IHomeRepository>().To<HomeRepository>();
            ninjectKernel.Bind<IHomeOwnerRepository>().To<HomeOwnerRepository>();
        }
    }
}