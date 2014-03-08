using odProbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace odProbe.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var url = @"http://opendataserver.ashevillenc.gov/geoserver/ows?service=wfs&version=1.1.0&request=GetCapabilities";
            XNamespace ns = "http://www.opengis.net/wfs";
            var feats = new List<FeatureType>();
            var xDoc = XDocument.Load(url);

            var xs = from el in xDoc.Root.Descendants(ns + "FeatureType")
                     select el;

            foreach (var el in xs)
            {
                var t = el.Descendants(ns + "Title").Single();
                var n = el.Descendants(ns + "Name").Single();
                var a = el.Descendants(ns + "Abstract").Single();
                var d = el.Descendants(ns + "DefaultSRS").Single();

                feats.Add(new FeatureType
                {
                    Title = t.Value,
                    Name = n.Value,
                    Abstract = a.Value,
                    DefaultSRS = d.Value
                });
            }

            return View(feats);
        }

    }
}
