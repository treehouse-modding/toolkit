using Terraria.ID;
using Terraria.ModLoader;

namespace Toolkit.Content.Tools;

// For more implementation details, visit: https://github.com/treehouse-modding/toolkit/wiki/Tools#axes

public class ExampleAxeItem : ModItem
{
    public override void SetDefaults()
    {
        Item.DamageType = DamageClass.Melee;
                
        Item.damage = 10;
        Item.knockBack = 1f;

        Item.attackSpeedOnlyAffectsWeaponAnimation = true;
        Item.autoReuse = true;
        Item.useTurn = true;
        
        Item.width = 16;
        Item.height = 16;
        
        Item.axe = 10;

        Item.UseSound = SoundID.Item1;

        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Swing;
    }
}