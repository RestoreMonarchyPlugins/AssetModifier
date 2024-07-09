using RestoreMonarchy.AssetModifier.Models;
using Rocket.API;
using SDG.Unturned;
using System.Collections.Generic;

namespace RestoreMonarchy.AssetModifier
{
    public class AssetModifierConfiguration : IRocketPluginConfiguration
    {
        public List<AssetModifications> Assets { get; set; }

        public void LoadDefaults()
        {
            Assets =
            [
                new()
                {
                    Id = 363,
                    Name = "Maplestrike",
                    AssetType = EAssetType.ITEM,
                    Modifications =
                    [
                        new AssetModification("isInvulnerable", "true"),
                        new AssetModification("structureDamage", "300"),
                        new AssetModification("barricadeDamage", "300"),
                        new AssetModification("magazineID", "17"),
                        new AssetModification("ammoMax", "255"),
                        new AssetModification("playerDamageMultiplier.damage", "100"),
                        new AssetModification("zombieDamageMultiplier.damage", "999"),
                    ]
                },
                new() 
                {
                    Id = 253,
                    Name = "Alicepack",
                    AssetType = EAssetType.ITEM,
                    Modifications = 
                    [
                        new AssetModification("_width", "8"),
                        new AssetModification("_height", "14"),
                    ]
                },
                new() 
                {
                    Guid = "c45d7632cd5f44eab7ef7f1976a35544",
                    Name = "Taxi",
                    AssetType = EAssetType.VEHICLE,
                    Modifications = 
                    [
                        new AssetModification("_healthMin", "40"),
                        new AssetModification("_healthMax", "60"),
                        new AssetModification("_health", "80"),
                    ]
                },
                new() 
                {
                    Guid = "b5da36615ef8412698cbd6db41ea383b",
                    Name = "Cow",
                    AssetType = EAssetType.ANIMAL,
                    Modifications =
                    [
                        new AssetModification("_behaviour", "OFFENSE"),
                        new AssetModification("_regen", "0.1"),
                        new AssetModification("_damage", "15"),
                    ]
                }
            ];
        }
    }
}
