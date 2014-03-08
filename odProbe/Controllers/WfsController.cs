using odProbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace odProbe.Controllers
{
    //[ValidateInput(false)]
    public class WfsController : Controller
    {
        //
        // GET: /Wfs/

        public ActionResult Index()
        {
            return View();
        }
        //[ValidateInput(false)]
        public ActionResult CsvData(string title, string name, string @abstract, string defaultSRS, string keywords)
        {

            return View();
        }
    }
}
#if (false)
protected void Page_Load(object sender, EventArgs e)
        {
            var addr =   //  @"http://opendataserver.ashevillenc.gov/geoserver/ows?service=WFS&request=GetFeature&srsName=EPSG:4326&typeName=coagis:coa_asheville_tree_map_trees_view&maxFeatures=1000000&outputFormat=json";
                // @"http://opendataserver.ashevillenc.gov/geoserver/ows?service=WFS&request=GetFeature&srsName=EPSG:4326&typeName=coagis:coa_asheville_tree_map_trees_view&maxFeatures=1000000&outputFormat=csv";
                        @"http://opendataserver.ashevillenc.gov/geoserver/ows?service=wfs&version=1.1.0&request=GetCapabilities";
            try
            {
                var xDoc = XDocument.Load(addr);
                var c = xDoc.Root.Descendants().Count();
                foreach (var n in xDoc.Root.Nodes())
                {
                    var t = n.GetType();
                }
                XNamespace ns = "http://www.opengis.net/wfs";
                var xs = from el in xDoc.Root.Descendants( ns + "FeatureType")
                         select el;

                foreach (var el in xs)
                {
                    foreach (var node in el.DescendantNodes())
	                {
                        var n = node as XElement;
	                }
                    var t = el.Descendants(ns + "Title").Single();
                }
                System.Net.HttpWebRequest WebRequest;
                Uri CSVUri = new Uri(addr);

                WebRequest = (System.Net.HttpWebRequest)
                              System.Net.HttpWebRequest.Create(CSVUri);

                var ou = WebRequest.GetResponse();
                if ((ou.ContentLength > 0))
                {
                    System.IO.StreamReader strReader =
                      new System.IO.StreamReader(
                      WebRequest.GetResponse().GetResponseStream());
                    var all = strReader.ReadToEnd();
                    //var rl = strReader.ReadLine();
                    //while(rl!=null)
                    //{
                    //    rl = strReader.ReadLine();
                    //}

                    if (strReader != null) strReader.Close();
                }
            }
            catch (System.Net.WebException ex)
            {
                
            }
        }
#endif