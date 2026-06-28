using Terraria;
using Terraria.ModLoader;

namespace Toolkit.Content.Accessories;

// For more implementation details, visit: https://github.com/tmodders/toolkit/blob/main/docs/content/accessories/example-lava-charm.md

/// <summary>
///     Provides a practical example of an accessory that grants temporary lava immunity, similarly to
///     how the <see href="https://terraria.wiki.gg/wiki/Lava_Charm">Lava Charm</see> behaves.
/// </summary>
[AutoloadEquip(EquipType.Neck)]
public class ExampleLavaCharmItem : ModItem
{
    public override void SetDefaults()
    {
        Item.accessory = true;
        
        Item.width = 16;
        Item.height = 16;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.lavaMax += 2 * 60;
    }
}