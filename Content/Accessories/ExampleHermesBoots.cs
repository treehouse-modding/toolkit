using Terraria;
using Terraria.ModLoader;

namespace Toolkit.Content.Accessories;

// For more implementation details, visit: https://github.com/tmodders/toolkit/blob/main/docs/content/accessories/example-hermes-boots.md

/// <summary>
///     Provides a practical example of an accessory that grants greater movement speed, similarly to
///     how the <see href="https://terraria.wiki.gg/wiki/Hermes_Boots">Hermes Boots</see> behaves.
/// </summary>
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