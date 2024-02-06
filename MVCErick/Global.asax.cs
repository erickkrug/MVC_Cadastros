using MVCErick.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCErick
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Adicionando um Contexto no banco de dados : 

            using (var context = new ApplicationDBContext()) // Certifique-se de substituir AppDBContext pelo nome real do seu contexto
            {
                context.Database.Initialize(false);
            }

        }
    }
}
