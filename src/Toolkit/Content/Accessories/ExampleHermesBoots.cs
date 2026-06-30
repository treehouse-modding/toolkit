using Terraria;
using Terraria.ModLoader;

namespace Toolkit.Content.Accessories;

// For more implementation details, visit: https://github.com/treehouse-modding/toolkit/wiki/Example-Hermes-Boots

[AutoloadEquip(EquipType.Shoes)]
public class ExampleHermesBootsItem : ModItem
{
    public override void SetDefaults()
    {
        Item.accessory = true;
        
        Item.width = 16;
        Item.height = 16;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.accRunSpeed = 6f;
        player.moveSpeed += 0.05f;
    }
}