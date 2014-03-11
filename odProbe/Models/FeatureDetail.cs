using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace odProbe.Models
{
    public class FeatureDetail
    {
        public FeatureType FeatureType { get; set; }
        public string QueryString { get; set; }
        public string[] Headings { get; set; }
        public List<string[]> Data { get; set; }

        public static FeatureDetail GetFeatureDetail(string title, string name, string @abstract, string defaultSRS, string keywords)
        {
            var fd = new FeatureDetail
            {
                FeatureType = new FeatureType
                {
                    Title = title,
                    Name = name,
                    Abstract = @abstract,
                    DefaultSRS = defaultSRS,
                    Keywords = keywords
                }
            };

            fd.Data = new List<string[]>();
            fd.QueryString = string.Format ( 
                @"http://opendataserver.ashevillenc.gov/geoserver/ows?service=WFS&request=GetFeature&srsName={0}&typeName={1}&maxFeatures=1000000&outputFormat=csv",
                defaultSRS, name );

            var CSVUri = new Uri(fd.QueryString);

            var webReq = (HttpWebRequest) HttpWebRequest.Create(CSVUri);

            var ou = webReq.GetResponse();

            if ((ou.ContentLength > 0))
            {
                using (var strReader = new System.IO.StreamReader(webReq.GetResponse().GetResponseStream()))
                {
                    var rl = strReader.ReadLine();
                    while (rl != null)
                    {
                        if (fd.Headings == null)
                        {
                            fd.Headings = rl.Split(',');
                        }
                        else
                        {
                            fd.Data.Add(rl.Split(','));
                        }
                        rl = strReader.ReadLine();
                    }
                }
            }
            return fd;
        }
    }
}
