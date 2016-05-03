using System;
using System.Collections;
using System.Web.Http;
using System.Web.Http.Description;
using Owin;
using Microsoft.Owin.Hosting;
using System.Runtime.Serialization;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;

namespace sorter
{
    public class ArrayType
    {
        public int[] data;

    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SampleController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ArraySort(ArrayType arg)
        {
            ISorter sorter = Proxy.GetSorter();
            ArrayType array = new ArrayType();
            array.data = sorter.Sort(arg.data);
            return Json<ArrayType>(array);
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.EnableCors();
            config.Routes.MapHttpRoute(
              "Api", "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config);
        }
    }
}
