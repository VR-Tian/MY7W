using AutoMapper;
using MY7W.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MY7W.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(pro => pro.AddProfile<Profiles>());
            //Profiling监视EF的SQL
            //StackExchange.Profiling.EntityFramework6.MiniProfilerEF6.Initialize();
        }

        protected void Application_BeginRequest()
        {
            //if (Request.IsLocal)
            //{
            //    MiniProfiler.Start();

            //}
        }

        protected void Application_EndRequest()
        {
            //MiniProfiler.Stop();
        }

         
    }
}
