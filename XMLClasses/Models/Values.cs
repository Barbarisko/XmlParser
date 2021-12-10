using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLClasses.Models
{
   public  class Values
    {
        //[XmlAttribute("measurement")]
        //public string Measurement { get; set; }
        
        [XmlElement("proteins")]
        public System.Double Proteins { get; set; }

        [XmlElement("fats")]
        public System.Double Fats { get; set; }

        [XmlElement("carbohydrates")]
        public System.Double Carbohydrates { get; set; }

        public override string ToString()
        {
            return $"Values: Proteins = {Proteins}, Fats = {Fats}, Carbohydrates = {Carbohydrates}";
        }

        //   <proteins measurement="gr.">4.0</proteins>
            //<fats measurement = "gr." > 6.0 </ fats >
            //< carbohydrates measurement="gr.">75.0</carbohydrates>
    }
}
