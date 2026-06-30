using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Toolkit.Content.Biomes;

// For more implementation details, visit: https://github.com/treehouse-modding/toolkit/wiki/Example-Dirt

public class ExampleDirtItem : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<ExampleDirtTile>());    
        
        Item.width = 16;
        Item.height = 16;
    }
}

public class ExampleDirtTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBlendAll[Type] = true;
        Main.tileBlockLight[Type] = true;
        
        AddMapEntry(new Color(255, 255, 255));
        
        DustType = DustID.Dirt;
        HitSound = SoundID.Dig;
    }

    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}