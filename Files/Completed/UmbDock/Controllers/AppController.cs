using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbDock.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/application/[action]")]
    public class AppController : UmbracoApiController
    {

        public AppController()
        {
            
        }

        public IEnumerable<string> GetBlogSummaries()
        {
            // Routes to /Umbraco/Api/App/GetBlogSummaries
            return new[] { "Table", "Chair", "Desk", "Computer" };
        }

    }
}
