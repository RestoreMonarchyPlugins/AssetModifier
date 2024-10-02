# Asset Modifier
Modify any vanilla or workshop asset properties like vehicle, item or animal.

It is not possible to modify all asset properties for example guns recoil or movement speed. Plugin only changes the values of those properties on the server but client, which is player, still has original values.

For example if you modify clothing `movementMultiplier` property for some item that originally has 0.7 movement multiplier, but you set it to 1.0 the server will think the player speed is 1.0 while client thinks their speed is still 0.7 causing the player to lag and teleport because their position is de-synced with the server.

Another example is `isInvulnerable` property for weapons. Maplestrike originally can't damage structures or barricades like doors or sentries. Setting `isInvulnerable` and `structureDamage` will enable it to do that, but you will notice that when you shoot at the wall as a player it doesn't show this other kind of crosshair that indicates that you are dealing damage to a structure.

If you need help finding a property or want to ask if it's possible to change specific property feel free to join our Discord server. 

## Commands
- **/checkasset \<id\> \<assetType\> or /checkasset \<guid\>** - List all properties of specific asset.

## Configuration
```xml
<?xml version="1.0" encoding="utf-8"?>
<AssetModifierConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Debug>false</Debug>
  <Assets>
    <AssetModifications Id="363" Name="Maplestrike" AssetType="ITEM">
      <Modifications>
        <AssetModification Name="isInvulnerable" Value="true" />
        <AssetModification Name="magazineID" Value="17" />
        <AssetModification Name="sightID" Value="146" />
        <AssetModification Name="gripID" Value="143" />
        <AssetModification Name="barrelID" Value="7" />
        <AssetModification Name="tacticalID" Value="151" />
        <AssetModification Name="ammoMin" Value="255" />
        <AssetModification Name="ammoMax" Value="255" />
        <AssetModification Name="playerDamageMultiplier.damage" Value="40" />
        <AssetModification Name="playerDamageMultiplier.leg" Value="0.6" />
        <AssetModification Name="playerDamageMultiplier.arm" Value="0.6" />
        <AssetModification Name="playerDamageMultiplier.spine" Value="0.8" />
        <AssetModification Name="playerDamageMultiplier.skull" Value="1.1" />
        <AssetModification Name="zombieDamageMultiplier.damage" Value="99" />
        <AssetModification Name="zombieDamageMultiplier.leg" Value="0.3" />
        <AssetModification Name="zombieDamageMultiplier.arm" Value="0.3" />
        <AssetModification Name="zombieDamageMultiplier.spine" Value="0.6" />
        <AssetModification Name="zombieDamageMultiplier.skull" Value="1.1" />
        <AssetModification Name="animalDamageMultiplier.damage" Value="40" />
        <AssetModification Name="animalDamageMultiplier.leg" Value="0.6" />
        <AssetModification Name="animalDamageMultiplier.spine" Value="0.8" />
        <AssetModification Name="animalDamageMultiplier.skull" Value="1.1" />
        <AssetModification Name="barricadeDamage" Value="30" />
        <AssetModification Name="structureDamage" Value="30" />
        <AssetModification Name="vehicleDamage" Value="30" />
        <AssetModification Name="resourceDamage" Value="300" />
        <AssetModification Name="objectDamage" Value="300" />
      </Modifications>
    </AssetModifications>
    <AssetModifications Id="253" Name="Alicepack" AssetType="ITEM">
      <Modifications>
        <AssetModification Name="_width" Value="8" />
        <AssetModification Name="_height" Value="14" />
      </Modifications>
    </AssetModifications>
    <AssetModifications Guid="c45d7632cd5f44eab7ef7f1976a35544" Name="Taxi">
      <Modifications>
        <AssetModification Name="_healthMin" Value="40" />
        <AssetModification Name="_healthMax" Value="60" />
        <AssetModification Name="_health" Value="80" />
      </Modifications>
    </AssetModifications>
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