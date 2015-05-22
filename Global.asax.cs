using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Razor.Text;
using System.Web.Routing;
using BSBChecker.Models;
using CsvHelper;

namespace BSBChecker
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        public static List<BSBData> TheBSBData;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            TheBSBData = ReadBSBFile();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private List<BSBData> ReadBSBFile()
        {
            using (var fileContents = File.OpenText(Server.MapPath(@"~/App_Data/BSBDirectory.csv")))
            {
                var csvReader = new CsvReader(fileContents);
                csvReader.Configuration.HasHeaderRecord = false;
                csvReader.Configuration.RegisterClassMap<BSBDataMap>();

                return csvReader.GetRecords<BSBData>().ToList();
            }
        }
    }
}