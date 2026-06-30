using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Toolkit.Content.Dyes;

// For more implementation details, visit: https://github.com/treehouse-modding/toolkit/wiki/Example-Dye

public class ExampleEquipmentDyeItem : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 3;
        
        if (Main.dedServ)
        {
            return;
        }

        // var data = new ArmorShaderData();
        // GameShaders.Armor.BindShader(Type, data);
    }
}