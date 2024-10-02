using RestoreMonarchy.AssetModifier.Models;
using Rocket.API;
using SDG.Unturned;
using System.Collections.Generic;

namespace RestoreMonarchy.AssetModifier
{
    public class AssetModifierConfiguration : IRocketPluginConfiguration
    {
        public bool Debug { get; set; }
        public List<AssetModifications> Assets { get; set; }

        public void LoadDefaults()
        {
            Debug = false;
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
                        new AssetModification("magazineID", "17"),
                        new AssetModification("sightID", "146"),
                        new AssetModification("gripID", "143"),
                        new AssetModification("barrelID", "7"),
                        new AssetModification("tacticalID", "151"),
                        new AssetModification("ammoMin", "255"),
                        new AssetModification("ammoMax", "255"),
                        new AssetModification("playerDamageMultiplier.damage", "40"),
                        new AssetModification("playerDamageMultiplier.leg", "0.6"),
                        new AssetModification("playerDamageMultiplier.arm", "0.6"),
                        new AssetModification("playerDamageMultiplier.spine", "0.8"),
                        new AssetModification("playerDamageMultiplier.skull", "1.1"),
                        new AssetModification("zombieDamageMultiplier.damage", "99"),
                        new AssetModification("zombieDamageMultiplier.leg", "0.3"),
                        new AssetModification("zombieDamageMultiplier.arm", "0.3"),
                        new AssetModification("zombieDamageMultiplier.spine", "0.6"),
                        new AssetModification("zombieDamageMultiplier.skull", "1.1"),
                        new AssetModification("animalDamageMultiplier.damage", "40"),
                        new AssetModification("animalDamageMultiplier.leg", "0.6"),
                        new AssetModification("animalDamageMultiplier.spine", "0.8"),
                        new AssetModification("animalDamageMultiplier.skull", "1.1"),
                        new AssetModification("barricadeDamage", "30"),
                        new AssetModification("structureDamage", "30"),
                        new AssetModification("vehicleDamage", "30"),
                        new AssetModification("resourceDamage", "300"),
                        new AssetModification("objectDamage", "300"),
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
