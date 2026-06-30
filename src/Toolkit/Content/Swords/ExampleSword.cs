using Terraria.ID;
using Terraria.ModLoader;

namespace Toolkit.Content.Swords;

// For more implementation details, visit: https://github.com/treehouse-modding/toolkit/wiki/Example-Swords

public class ExampleSwordItem : ModItem
{
    public override void SetDefaults()
    {
        Item.DamageType = DamageClass.Melee;
        
        Item.damage = 10;
        Item.knockBack = 1f;

        Item.autoReuse = true;

        Item.width = 16;
        Item.height = 16;
        
        Item.UseSound = SoundID.Item1;

        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.useStyle = ItemUseStyleID.Swing;
    }
}