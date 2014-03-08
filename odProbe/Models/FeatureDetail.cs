using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace odProbe.Models
{
    public class FeatureDetail
    {
        public FeatureType FeatureType { get; set; }
        public string[] Headings { get; set; }
        public List<List<string>> Data { get; set; }

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
            return fd;
        }
    }
}
