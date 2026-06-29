# Summary

> [!NOTE]
> [**Click here to view full implementation**](https://github.com/treehouse-modding/toolkit/blob/main/Content/Biomes/ExampleGrass.cs).

* [Prerequisites](#prerequisites)
* [Introduction](#introduction)
* [Creating the Grass](#creating-the-grass)
    * [Effects](#effects)
    * [Kill](#kill)
    * [Vines](#vines)
    * [Foliage](#foliage)
* [Creating the Seeds](#creating-the-seeds)

# Prerequisites

- [**C#**](https://dotnet.microsoft.com/languages/csharp)
- [[Items]]
- [[Tiles]]

# Introduction

This guide demonstrates how to create custom grass. By the end of it, you will have:

- A tile that behaves like grass.
- An item that behaves like grass seeds.

# Creating the Grass

To make a tile behave like grass, several tile sets must be configured. These tile sets control how the grass spreads, merges with neighboring tiles, interacts with world generation, and behaves during tile framing:

```cs
public override void SetStaticDefaults()
{
    // Indicates that the tile spreads to dirt.
    TileID.Sets.Grass[Type] = true;

    // If your grass spreads to other tile types, set the field below to true:
    // TileID.Sets.GrassSpecial[Type] = true;
    
    // If your grass spreads to both dirt and other tile types, set both fields below to true:
    // TileID.Sets.Grass[Type] = true;
    // TileID.Sets.GrassSpecial[Type] = true;
    
    // If your grass spreads to other tile types, set both fields below accordingly:
    // Main.tileMerge[Type][tileType] = true;
    // Main.tileMerge[tileType][Type] = true;
    
    TileID.Sets.ChecksForMerge[Type] = true;
    TileID.Sets.ForcedDirtMerging[Type] = true;

    TileID.Sets.NeedsGrassFraming[Type] = true;
    TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Dirt;

    TileID.Sets.SpreadOverground[Type] = true;
    TileID.Sets.SpreadUnderground[Type] = true;

    // Indicates that the tile can be overridden when using WorldGen::OreRunner().
    TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;

    TileID.Sets.CanBeDugByShovel[Type] = true;
    TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
    TileID.Sets.ResetsHalfBrickPlacementAttempt[Type] = true;

    TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
}
```

## Effects

Walking across grass usually produces small dust particles. This effect can be reproduced by overriding `ModTile::FloorVisuals(Player)`:

```cs
public override void FloorVisuals(Player player)
{
    var speed = MathF.Abs(player.velocity.X);

    // Checks whether the player is walking.
    if (speed == 0f)
    {
        return;
    }

    // Makes dust spawn more frequently the faster the player is.
    const float rate = 30f;

    var chance = (int)MathHelper.Clamp(rate / speed, 1f, rate);

    if (!Main.rand.NextBool(chance))
    {
        return;
    }

    // Spawns dust effects whenever the player is walking on the tile.
    Dust.NewDust(player.BottomLeft, player.width, 0, DustType, 0f, -player.velocity.X / 10f);
}
```

## Kill

Unlike most tiles, grass is not normally destroyed when mined. Instead, it reverts to its corresponding dirt tile.

To reproduce this behavior, override `ModTile::KillTile(int, int, ref bool, ref bool, ref bool)`. If the tile is actually being destroyed, replace it with your dirt tile instead:

```cs
public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
{
    // Checks if the tile was meant to be destroyed.
    if (fail)
    {
        return;
    }

    var tile = Framing.GetTileSafely(i, j);

    // Instead of destroying the tile, we turn the tile into dirt.
    tile.TileType = ModContent.TileType<ExampleDirtTile>();
}
```

> [!NOTE]
> The `fail` parameters indicates whether the mining attempt has successfully destroyed the tile.

Explosions require special handling. Since `KillTile` also runs when a tile is destroyed by an explosion, your grass would incorrectly convert into dirt instead of being removed.

To preserve the vanilla behavior, override `ModTile::CanExplode(int, int)` and explicitly destroy the tile:

```cs
public override bool CanExplode(int i, int j)
{
    WorldGen.KillTile(i, j);

    return true;
}
```

## Vines

Grass can grow vines below itself.

The following method attempts to place a vine beneath the grass tile whenever the placement conditions are met, and must be called in `ModTile::RandomUpdate(int, int)`:

```cs
private static void UpdateVines(int i, int j)
{
    const int chance = 15;

    if (!WorldGen.genRand.NextBool(chance) || !WorldGen.GrowMoreVines(i, j))
    {
        return;
    }

    // TODO: Replace with ExampleVine.
    const int type = TileID.Vines;

    WorldGen.PlaceObject(i, j + 1, type);

    // Synchronizes the tile placement across the server. Automatically checks for current network mode.
    NetMessage.SendTileSquare(-1, i, j + 1);
}
```

> [!TIP]
> Replace `TileID.Vines` with your own vine tile type when creating your custom grass.

## Foliage

Similarly, grass can grow decorative plants above itself.

The following method attempts to place a plant above the grass tile whenever the placement conditions are met, and must be called in `ModTile::RandomUpdate(int, int)`:

```cs
private static void UpdateFoliage(int i, int j)
{
    const int chance = 15;

    if (!WorldGen.genRand.NextBool(chance))
    {
        return;
    }

    var above = Framing.GetTileSafely(i, j - 1);

    if (above.HasTile || above.LiquidAmount > 0)
    {
        return;
    }

    // TODO: Replace with ExampleFoliage.
    const int type = TileID.Plants;

    // TODO: Replace with ExampleFoliage styles.
    var style = Main.rand.Next(0, 8);

    WorldGen.PlaceObject(i, j - 1, type, false, style);

    // Synchronizes the tile placement across the server. Automatically checks for current network mode.
    NetMessage.SendTileSquare(-1, i, j + 1);
}
```

> [!TIP]
> Replace `TileID.Plants` and the style values with your own foliage tile type and styles when creating your custom grass.

# Creating the Seeds

Although a placeable item can simply assign `Item.createTile`, doing so would place the grass directly into empty space. Since grass is normally grown by converting existing dirt, override `ModItem::UseItem(Player)` instead and manually replace the targeted tile:

```cs
public override bool? UseItem(Player player)
{
    // Checks whether the local player is being handled.
    if (player.whoAmI != Main.myPlayer)
    {
        return false;
    }

    var x = Player.tileTargetX;
    var y = Player.tileTargetY;

    var tile = Framing.GetTileSafely(x, y);

    if (!tile.HasTile || tile.TileType != ModContent.TileType<ExampleDirtTile>())
    {
        return false;
    }

    // Checks whether the player is attempting to use the item in a tile within placement range.
    var ranges = player.IsTargetTileInItemRange(Item);

    if (!ranges)
    {
        return false;
    }

    WorldGen.PlaceTile(x, y, ModContent.TileType<ExampleGrassTile>(), true);

    // Synchronizes the tile placement across the server. Automatically checks for current network mode.
    NetMessage.SendTileSquare(-1, x, y);

    return true;
}
```