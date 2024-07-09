using System.Xml.Serialization;

namespace RestoreMonarchy.AssetModifier.Models
{
    public class AssetModification
    {
        public AssetModification() { }

        public AssetModification(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }
    }
}
