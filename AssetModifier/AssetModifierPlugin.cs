using RestoreMonarchy.AssetModifier.Helpers;
using RestoreMonarchy.AssetModifier.Models;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RestoreMonarchy.AssetModifier
{
    public class AssetModifierPlugin : RocketPlugin<AssetModifierConfiguration>
    {
        private const BindingFlags allBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        protected override void Load()
        {
            if (Level.isLoaded)
            {
                LoadAssetModifications();
            }
            else
            {
                DedicatedUGC.installed += LoadAssetModifications;
            }

            Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded!", ConsoleColor.Yellow);
        }

        protected override void Unload()
        {
            DedicatedUGC.installed -= LoadAssetModifications;

            Logger.Log($"{Name} has been unloaded!", ConsoleColor.Yellow);
        }

        public override TranslationList DefaultTranslations => new()
        {
            { "", "" }
        };

        private void LoadAssetModifications()
        {
            Logger.Log($"Loading {Configuration.Instance.Assets.Count()} asset modifications...", ConsoleColor.Yellow);

            foreach (AssetModifications assetModifications in Configuration.Instance.Assets)
            {
                Asset asset = null;

                if (assetModifications.Id != 0)
                {
                    asset = Assets.find(assetModifications.AssetType, assetModifications.Id);
                } else if (!string.IsNullOrEmpty(assetModifications.Guid))
                {
                    if (!Guid.TryParse(assetModifications.Guid, out Guid guid))
                    {
                        Logger.LogWarning($"Failed to parse Guid {assetModifications.Guid} for item Id {assetModifications.Id}");
                        continue;
                    }

                    asset = Assets.find(guid);
                }

                if (asset == null)
                {
                    Logger.LogWarning($"Asset for item Id {assetModifications.Id} not found");
                    continue;
                }

                foreach (AssetModification modification in assetModifications.Modifications)
                {
                    string[] names = modification.Name.Split('.');

                    MemberInfo member = null;
                    Type type = asset.GetType();
                    object instance = asset;
                    for (int i = 0; i < names.Length; i++)
                    {
                        string name = names[i];

                        if (member != null)
                        {
                            if (member.MemberType == MemberTypes.Property)
                            {
                                instance = ((PropertyInfo)member).GetValue(instance);
                            }
                            else if (member.MemberType == MemberTypes.Field)
                            {
                                instance = ((FieldInfo)member).GetValue(instance);
                            }

                            if (instance == null)
                            {
                                Logger.LogWarning($"Failed to get instance for member {name} for asset Id {assetModifications.Id} type {type.Name}");
                                break;
                            }

                            type = instance.GetType();
                        }

                        IEnumerable<MemberInfo> members = ReflectionHelper.GetAllMembers(type);
                        foreach (MemberInfo member2 in members)
                        {
                            if (member2.Name == name)
                            {
                                member = member2;
                                break;
                            }
                        }

                        if (member == null)
                        {
                            Logger.LogWarning($"Failed to find member {name} for asset Id {assetModifications.Id} type {type.Name}");
                            break;
                        }

                        // last member
                        if (i == names.Length - 1)
                        {
                            // set value of member
                            try
                            {
                                if (member is FieldInfo field)
                                {
                                    object value;
                                    if (field.FieldType.IsEnum)
                                    {
                                        value = Enum.Parse(field.FieldType, modification.Value);
                                    } else
                                    {
                                        value = Convert.ChangeType(modification.Value, field.FieldType);
                                    }                                    
                                    field.SetValue(instance, value);
                                    Logger.Log($"[{asset.FriendlyName} ({asset.id})] {modification.Name} field set to {value}", ConsoleColor.Yellow);
                                }
                                else if (member is PropertyInfo property)
                                {
                                    object value;
                                    if (property.PropertyType.IsEnum)
                                    {

                                       value = Enum.Parse(property.PropertyType, modification.Value);
                                    }
                                    else
                                    {
                                        value = Convert.ChangeType(modification.Value, property.PropertyType);
                                    }
                                    property.SetValue(instance, value);
                                    Logger.Log($"[{asset.FriendlyName} ({asset.id})] {modification.Name} property set to {value}", ConsoleColor.Yellow);
                                }
                                else
                                { 
                                    Logger.LogWarning($"Failed to find member {name} for asset Id {assetModifications.Id} type {type.Name}");
                                }
                            }
                            catch (FormatException e)
                            {
                                Logger.LogWarning($"Failed to convert value {modification.Value} to type {member.MemberType} for asset Id {assetModifications.Id} type {type.Name}: {e.Message}");
                            }
                            catch (InvalidCastException e)
                            {
                                Logger.LogWarning($"Failed to convert value {modification.Value} to type {member.MemberType} for asset Id {assetModifications.Id} type {type.Name}: {e.Message}");
                            }
                            catch (Exception e)
                            {
                                Logger.LogWarning($"Failed to set value {modification.Value} to member {name} for asset Id {assetModifications.Id} type {type.Name}");
                                Logger.LogException(e);
                            }
                        }
                    }
                }
            }
        }
    }
}
