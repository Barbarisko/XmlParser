using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLClasses.Models
{

    [XmlRoot("Candies", Namespace = "http://www.mydomain/candies", IsNullable = false)]
    public partial class Candies
    {
        [XmlElementAttribute("candy")]
        public Candy[] Candy { get; set; }
    }
}
