using RestoreMonarchy.AssetModifier.Helpers;
using Rocket.API;
using Rocket.Core.Logging;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RestoreMonarchy.AssetModifier.Commands
{
    public class CheckAssetCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Console;

        public string Name => "checkasset";

        public string Help => "";

        public string Syntax => "<id/guid> [type]";

        public List<string> Aliases => new();

        public List<string> Permissions => new();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length == 0)
            {
                Logger.Log("");
                return;
            }

            Asset asset = null;

            if (Guid.TryParse(command[0], out Guid guid))
            {
                asset = Assets.find(guid);
            } else
            {
                if (!ushort.TryParse(command[0], out ushort id))
                {
                    Logger.Log($"{command[0]} is not a valid GUID or ID.");
                }

                if (command.Length == 1)
                {
                    Logger.Log("When using ID you must provide asset type");
                    return;
                }

                if (!Enum.TryParse(command[1], true, out EAssetType assetType))
                {
                    Logger.Log($"{command[1]} is not a valid asset type.");
                    return;
                }

                asset = Assets.find(assetType, id);                
            }

            if (asset == null)
            {
                Logger.Log("Asset not found.");
                return;
            }

            IEnumerable<MemberInfo> members = ReflectionHelper.GetAllMembers(asset.GetType());
            Logger.Log($"{asset.FriendlyName} - {asset.id} - {asset.GUID} - {asset.assetCategory}");
            Logger.Log($"Available {members.Count()} modifications:");
            foreach (MemberInfo member in members)
            {
                object value;
                if (member.MemberType == MemberTypes.Field)
                {
                    value = ((FieldInfo)member).GetValue(asset);
                } else if (member.MemberType == MemberTypes.Property)
                {
                    value = ((PropertyInfo)member).GetValue(asset);
                } else
                {
                    continue;
                }

                Logger.Log($"[{member.Name}] TYPE: \"{member.DeclaringType.Name}\" VALUE: \"{value}\"");
            }
        }
    }
}
