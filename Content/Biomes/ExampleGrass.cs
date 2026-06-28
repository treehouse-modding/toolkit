using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Toolkit.Content.Biomes;

// For more implementation details, visit: https://github.com/treehouse-modding/toolkit/wiki/Example-Grass

public class ExampleGrassSeedsItem : ModItem
{
    public override void SetDefaults()
    {
        Item.maxStack = Item.CommonMaxStack;
        
        Item.consumable = true;

        Item.autoReuse = true;

        Item.useTurn = true;
        
        Item.width = 16;
        Item.height = 16;

        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Swing;
    }

    public override bool? UseItem(Player player)
    {
        if (player.whoAmI != Main.myPlayer)
        {
            return false;
        }

        var x = Player.tileTargetX;
        var y = Player.tileTargetY;
        
        var tile = Framing.GetTileSafely(x, y);

        if (!tile.HasTile || tile.TileType != TileID.Dirt)
        {
            return false;
        }
        
        var ranges = player.IsTargetTileInItemRange(Item);

        if (!ranges)
        {
            return false;
        }
        
        WorldGen.PlaceTile(x, y, ModContent.TileType<ExampleGrassTile>(), true);
        
        NetMessage.SendTileSquare(-1, x, y);
        
        return true;
    }
}

public class ExampleGrassTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBlendAll[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;

        TileID.Sets.Grass[Type] = true;

        TileID.Sets.ChecksForMerge[Type] = true;
        TileID.Sets.ForcedDirtMerging[Type] = true;
        
        TileID.Sets.NeedsGrassFraming[Type] = true;
        TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Dirt;
        
        TileID.Sets.SpreadOverground[Type] = true;
        TileID.Sets.SpreadUnderground[Type] = true;
        
        TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
        
        TileID.Sets.CanBeDugByShovel[Type] = true;
        TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
        TileID.Sets.ResetsHalfBrickPlacementAttempt[Type] = true;
        
        TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
        
        AddMapEntry(new Color(255, 255, 255));

        MineResist = 0.5f;
        
        HitSound = SoundID.Dig;
        DustType = DustID.Dirt;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (fail)
        {
            return;
        }

        var tile = Framing.GetTileSafely(i, j);

        tile.TileType = TileID.Dirt;
    }

    public override bool CanExplode(int i, int j)
    {
        WorldGen.KillTile(i, j);
        
        return true;
    }

    public override void FloorVisuals(Player player)
    {
        var speed = MathF.Abs(player.velocity.X);
        
        if (speed == 0f)
        {
            return;
        }
        
        const float rate = 30f;
        
        var chance = (int)MathHelper.Clamp(rate / speed, 1f, rate);

        if (!Main.rand.NextBool(chance))
        {
            return;
        }

        Dust.NewDust(player.BottomLeft, player.width, 0, DustType, 0f, -player.velocity.X / 10f);
    }

    public override void RandomUpdate(int i, int j)
    {
        UpdateVines(i, j);   
        UpdateFoliage(i, j);
    }

    private static void UpdateVines(int i, int j)
    {
        const int chance = 15;

        if (!WorldGen.genRand.NextBool(chance) || !WorldGen.GrowMoreVines(i, j))
        {
            return;
        }

        const int type = TileID.Vines;

        WorldGen.PlaceObject(i, j + 1, type);
        
        NetMessage.SendTileSquare(-1, i, j + 1);
    }

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
        
        const int type = TileID.Plants;

        var style = Main.rand.Next(0, 8);

        WorldGen.PlaceObject(i, j - 1, type, false, style);
        
        NetMessage.SendTileSquare(-1, i, j + 1);
    }
}