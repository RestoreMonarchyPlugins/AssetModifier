# Asset Modifier
> ⚠️**Warning:** This plugin requires technical knowledge of Unturned asset properties. It can be difficult to use correctly without understanding how the game handles assets internally.

## Overview
Modify properties of vanilla or workshop assets in Unturned, including vehicles, items, and animals.

## Important Limitations
Not all asset properties can be modified effectively. This plugin changes values on the server, but clients may still use original values, causing these issues:

- **Desync problems:** Modifying movement properties can cause players to teleport or lag because the client and server have different values.
- **Visual feedback issues:** Some changes (like enabling structure damage on weapons) work but won't show proper visual feedback to players.

## Commands
- **/checkasset \<id\> \<assetType\>** - List all properties of an asset by ID and type
- **/checkasset \<guid\>** - List all properties of an asset by GUID

## Configuration
The plugin uses XML configuration to specify which assets to modify and what properties to change:

```xml
<?xml version="1.0" encoding="utf-8"?>
<AssetModifierConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Debug>false</Debug>
  <Assets>
    <!-- Item modification example (Maplestrike gun) -->
    <AssetModifications Id="363" Name="Maplestrike" AssetType="ITEM">
      <Modifications>
        <AssetModification Name="isInvulnerable" Value="true" />
        <AssetModification Name="playerDamageMultiplier.damage" Value="40" />
        <!-- More modifications... -->
      </Modifications>
    </AssetModifications>
    
    <!-- Backpack size modification -->
    <AssetModifications Id="253" Name="Alicepack" AssetType="ITEM">
      <Modifications>
        <AssetModification Name="_width" Value="8" />
        <AssetModification Name="_height" Value="14" />
      </Modifications>
    </AssetModifications>
    
    <!-- Vehicle modification (using GUID) -->
    <AssetModifications Guid="c45d7632cd5f44eab7ef7f1976a35544" Name="Taxi">
      <Modifications>
        <AssetModification Name="_healthMin" Value="40" />
        <AssetModification Name="_healthMax" Value="60" />
        <AssetModification Name="_health" Value="80" />
      </Modifications>
    </AssetModifications>
    
    <!-- Animal modification (making cows aggressive) -->
    <AssetModifications Guid="b5da36615ef8412698cbd6db41ea383b" Name="Cow">
      <Modifications>
        <AssetModification Name="_behaviour" Value="OFFENSE" />
        <AssetModification Name="_regen" Value="0.1" />
        <AssetModification Name="_damage" Value="15" />
      </Modifications>
    </AssetModifications>
  </Assets>
</AssetModifierConfiguration>
```

## Usage Tips
1. Use the `/checkasset` command to find available properties for an asset
2. Start with small changes to test if they work as expected
3. Enable `<Debug>true</Debug>` in the config to see detailed logs
4. Join our Discord server or ask on our forum if you need help finding specific properties

## Common Modifications
- **Weapons:** Damage values, ammo capacity, attachments
- **Backpacks:** Storage dimensions
- **Vehicles:** Health, fuel capacity
- **Animals:** Behavior, damage, health regeneration