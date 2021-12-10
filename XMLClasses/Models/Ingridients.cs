using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLClasses.Models
{
    public partial class Ingridients
    {
        [XmlElementAttribute("ingridient")]
        public Ingridient[] Ingridient { get; set; }
    }
    public class Ingridient
    {
        [XmlAttribute("measurement")]
        public string Measurment { get; set; } = "";

        [XmlElement("name", IsNullable = false)]
        public string Name { get; set; }

        [XmlElement("amount", IsNullable = false)]
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return
                $"Ingredient : measurement :{Measurment},Name= {Name}, Amount = {Amount}";
        }
    }
}
