using System;
using System.ServiceModel.Activation;
using System.Web.Routing;

namespace AzureDemo.Service
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Registers the AzureDemo RESTful route.
        /// </summary>
        /// <param name="sender">The caller of this method.</param>
        /// <param name="e">The arguments provided by the caller.</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("AzureDemo", new WebServiceHostFactory(), typeof(ExampleService)));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}