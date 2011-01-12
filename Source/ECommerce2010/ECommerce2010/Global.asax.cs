using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using StructureMap;
using SubSonic.Repository;
using ECommerce2010.Core;

namespace ECommerce2010
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Default"];

            ObjectFactory.Initialize(x =>
            {
                x.For(typeof(IGenericRepository<>))
                      .LifecycleIs(InstanceScope.PerRequest)
                      .Use(typeof(GenericRepository<>))
                      .CtorDependency<string>("connectionStringName").Is(settings.Name)
                      .CtorDependency<SimpleRepositoryOptions>("options").Is(SimpleRepositoryOptions.None);
                //.WithCtorArg("connectionStringName").EqualTo(settings.Name)
                //.WithCtorArg("options").EqualTo(SimpleRepositoryOptions.None);

                x.For(typeof(IRedirector)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(Redirector));

                x.For(typeof(IUserSession)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(UserSession));


                x.For(typeof(IWebContext)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(WebContext));

                x.For(typeof(IConfiguration)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(ECommerce2010.Core.Configuration));

                x.For(typeof(ICaptcha)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(Captcha));

                //x.For(typeof(SubSonic.Caching.ICacheConfigReader))
                //  .LifecycleIs(InstanceScope.PerRequest)
                //  .Use(typeof(SubSonic.Caching.CacheConfigFromXml));

            });
            ECommerce2010.Core.Statistics statistics = new ECommerce2010.Core.Statistics(Server.MapPath("~/statistics.xml"));
            // Code that runs on application startup
            Application["totalvisits"] = 1;
            Application["online"] = 0;
            Application["totalvisitsday"] = 1;
            Application["totalvisitsweek"] = 1;
            Application["totalvisitsmonth"] = 1;

            //neu ma tu 8h sang den 10h dem cho nguoi dung tu 10 den 100 nguoi
            //if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 22)
            //    Application["onlinevirtual"] = statistics.Ramdom(10, 100);
            //else
            //    Application["onlinevirtual"] = statistics.Ramdom(0, 10);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            ECommerce2010.Core.Statistics statistics = new ECommerce2010.Core.Statistics(Server.MapPath("~/statistics.xml"));
            //sua so nguoi truy cap ao o day onlinevirtual 
            Application.Lock();
            Application["online"] = Convert.ToInt32(Application["online"]) + 1;
            //Application["onlinevirtual"] = Convert.ToInt32(Application["onlinevirtual"]) + 1;
            Application.UnLock();
            Application.Lock();
            Application["totalvisits"] = statistics.ReadField("totalvisits");
            statistics.WriteField("totalvisits", statistics.ReadField("totalvisits") + 1);
            Application["totalvisitsday"] = statistics.GetVisiterInDay();
            Application["totalvisitsweek"] = statistics.GetVisiterInWeek();
            Application["totalvisitsmonth"] = statistics.GetVisiterInMonth();
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
            Application.Lock();
            Application["online"] = Convert.ToInt32(Application["online"]) - 1;
            //Application["onlinevirtual"] = Convert.ToInt32(Application["onlinevirtual"]) - 1;
            Application.UnLock();
        }
    }
}