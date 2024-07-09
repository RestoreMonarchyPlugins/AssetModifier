using SDG.Unturned;
using System;
using System.Xml.Serialization;

namespace RestoreMonarchy.AssetModifier.Models
{
    public class AssetModifications
    {
        [XmlAttribute]
        public ushort Id { get; set; }
        [XmlAttribute]
        public string Guid { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public EAssetType AssetType { get; set; }

        public AssetModification[] Modifications { get; set; }


        public bool ShouldSerializeId()
        {
            return Id != 0;
        }

        public bool ShouldSerializeGuid()
        {
            return !string.IsNullOrEmpty(Guid);
        }

        public bool ShouldSerializeName()
        {
            return !string.IsNullOrEmpty(Name);
        }

        public bool ShouldSerializeAssetType()
        {
            return AssetType != EAssetType.NONE;
        }
    }
}
