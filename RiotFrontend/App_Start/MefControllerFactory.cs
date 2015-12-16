using System.ComponentModel.Composition.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiotFrontend.App_Start
{
    public class MefControllerFactory : DefaultControllerFactory
    {
        private readonly CompositionContainer _container;

        public MefControllerFactory(CompositionContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            Lazy<object, object> export = _container.GetExports(controllerType, null, null).FirstOrDefault();
            var ret = export == null
                ? base.GetControllerInstance(requestContext, controllerType)
                : (IController)export.Value;

            return ret;
        }

        public override void ReleaseController(IController controller)
        {
            ((IDisposable)controller).Dispose();
        }
    }
}