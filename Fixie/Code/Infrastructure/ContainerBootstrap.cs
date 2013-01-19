using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Fixie.Code.Facades;
using Fixie.Code.Repository;
using StructureMap;

namespace Fixie.Code.Infrastructure
{
    public class ContainerBootstrap
    {
        public static void Bootstrap()
        {
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            ObjectFactory.Initialize(x =>
            {
                x.For<IFixieApiService>().Use<FixieApiService>();
                x.For<ICardRepository>().Use<CardRepository>();
                x.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
                //x.For<IConfigSettings>().Singleton().Use(() => new ConfigSettings().PopulateFromConfig());
                Debug.WriteLine(ObjectFactory.WhatDoIHave());
            });
        }
    }

    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                base.GetControllerInstance(requestContext, controllerType);

            return (IController)ObjectFactory.GetInstance(controllerType);
        }
    }
}