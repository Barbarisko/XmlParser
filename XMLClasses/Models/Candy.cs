using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace XMLClasses.Models
{
    public class Candy : IComparable<Candy>
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElementAttribute("type")]
        public CandyType Type { get; set; } 

        [XmlElementAttribute("energy")]
        public System.Int32 Energy { get; set; } = 0;
        [XmlElementAttribute("stuffing")]
        public bool Stuffing { get; set; } = false;

        [XmlElementAttribute("ingridients")]
        public Ingridients Ingridients { get; set; } = new Ingridients();

        [XmlElementAttribute("values")]
        public Values Values { get; set; } = new Values();

        [XmlElementAttribute("production")]
        public string Production { get; set; } = "";
        public int CompareTo(Candy other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Energy.CompareTo(other.Energy);
        }
        public override string ToString()
        {
            return
                $"Candy: Id = {Id}, Type = {Type}, Energy = {Energy},Stuffing = {Stuffing}," +
                $"{Environment.NewLine} Ingridients ={Ingridients}," +
                $"{Environment.NewLine}Values= {Values}," +
                $"{Environment.NewLine}Production = {Production}";
        }
    }
}
