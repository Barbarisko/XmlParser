using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLClasses.Models
{
    public enum CandyType
    {
        [XmlEnum("caramel")]
        Caramel,
        [XmlEnum("chocolate")]
        Chocolate,
        [XmlEnum("fruity")]
        Fruity
    }
}
