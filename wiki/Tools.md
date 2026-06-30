# Summary

* [Prerequisites](#prerequisites)
* [Introduction](#introduction)
* [Pickaxes](#pickaxes)
    * [Example](#example-1)
    * [Vanilla References](#vanilla-references)
* [Axes](#axes)
    * [Example](#example-1)
    * [Vanilla References](#vanilla-references-1)
* [Hammers](#hammers)
    * [Example](#example-2)
    * [Vanilla References](#vanilla-references-2)
* [Drills](#drills)
    * [Vanilla References](#vanilla-references-3)
* [Multi-tools](#multi-tools)
    * [Example](#example-4)

# Prerequisites

- [**C#**](https://dotnet.microsoft.com/languages/csharp)
- [[Items]]

# Introduction

This guide demonstrates how to create all sorts of custom tools. By the end of it, you will have learned how to create:

- Pickaxes.
- Axes.
- Hammers.
- Drills.
- Multi-tools.

# Pickaxes

> [!NOTE]
> [**Click here to view full implementation**](https://github.com/treehouse-modding/toolkit/blob/main/Content/Tools/ExamplePickaxe.cs).

Pickaxes are items that use the `Item.pick` field. The value stored in `Item.pick` corresponds directly to the item's pickaxe power.

## Example

```cs
public override void SetDefaults()
{
    // Sets the power of the pickaxe.
    Item.pick = 50;
}
```

## Vanilla References

| Pickaxe | Power | `Item.pick` |
| --- | ---: | ---: |
| Copper Pickaxe | 35% | `35` |
| Tin Pickaxe | 35% | `35` |
| Cactus Pickaxe | 35% | `35` |
| Iron Pickaxe | 40% | `40` |
| Lead Pickaxe | 43% | `43` |
| Silver Pickaxe | 45% | `45` |
| Tungsten Pickaxe | 50% | `50` |
| Gold Pickaxe | 55% | `55` |
| Bone Pickaxe | 55% | `55` |
| Fossil Pickaxe | 55% | `55` |
| Candy Cane Pickaxe | 55% | `55` |
| Platinum Pickaxe | 59% | `59` |
| Reaver Shark | 59% | `59` |
| Nightmare Pickaxe | 65% | `65` |
| Deathbringer Pickaxe | 70% | `70` |
| Molten Pickaxe | 100% | `100` |
| Cobalt Pickaxe | 110% | `110` |
| Palladium Pickaxe | 130% | `130` |
| Mythril Pickaxe | 150% | `150` |
| Orichalcum Pickaxe | 165% | `165` |
| Adamantite Pickaxe | 180% | `180` |
| Titanium Pickaxe | 190% | `190` |
| Chlorophyte Pickaxe | 200% | `200` |
| Pickaxe Axe | 200% | `200` |
| Shroomite Digging Claw | 200% | `200` |
| Spectre Pickaxe | 200% | `200` |
| Picksaw | 210% | `210` |
| Solar Flare Pickaxe | 225% | `225` |
| Vortex Pickaxe | 225% | `225` |
| Nebula Pickaxe | 225% | `225` |
| Stardust Pickaxe | 225% | `225` |

# Axes

> [!NOTE]
> [**Click here to view full implementation**](https://github.com/treehouse-modding/toolkit/blob/main/Content/Tools/ExampleAxe.cs).

Axes are items that use the `Item.axe` field. Unlike most tool power values, axe power is calculated as `Item.axe * 5`, meaning the value stored in `Item.axe` is one-fifth of the displayed axe power. For example, an `Item.axe` value of `5` results in **25% axe power**.

## Example

```cs
public override void SetDefaults()
{
    // Sets the power of the axe. This value is multiplied by 5, so setting this to 5 actually makes it have 25% axe power.
    Item.axe = 5;
}
```

## Vanilla References

| Axe | Power | `Item.axe` |
| --- | ---: | ---: |
| Copper Axe | 35% | `7` |
| Tin Axe | 40% | `8` |
| Iron Axe | 45% | `9` |
| Lead Axe | 50% | `10` |
| Silver Axe | 50% | `10` |
| Tungsten Axe | 55% | `11` |
| Gold Axe | 55% | `11` |
| Platinum Axe | 60% | `12` |
| War Axe of the Night | 75% | `15` |
| Blood Lust Cluster | 75% | `15` |
| Meteor Hamaxe | 100% | `20` |
| Molten Hamaxe | 150% | `30` |
| Cobalt Waraxe | 70% | `14` |
| Palladium Waraxe | 75% | `15` |
| Mythril Waraxe | 85% | `17` |
| Orichalcum Waraxe | 90% | `18` |
| Adamantite Waraxe | 100% | `20` |
| Titanium Waraxe | 105% | `21` |
| Pickaxe Axe | 110% | `22` |
| Chlorophyte Greataxe | 115% | `23` |
| Picksaw | 125% | `25` |
| Shroomite Digging Claw | 125% | `25` |
| Spectre Hamaxe | 150% | `30` |
| The Axe | 175% | `35` |
| Axe of Regrowth | 125% | `25` |
| Lucy the Axe | 150% | `30` |
| Haemorrhaxe | 150% | `30` |
| Axearang | 150% | `30` |
| Solar Flare Hamaxe | 150% | `30` |
| Vortex Hamaxe | 150% | `30` |
| Nebula Hamaxe | 150% | `30` |
| Stardust Hamaxe | 150% | `30` |

# Hammers

> [!NOTE]
> [**Click here to view full implementation**](https://github.com/treehouse-modding/toolkit/blob/main/Content/Tools/ExampleHammer.cs).

Hammers are tools that use the `Item.hammer` field. The value stored in `Item.hammer` corresponds directly to the item's displayed hammer power.

## Example

```cs
public override void SetDefaults()
{
    // Sets the power of the hammer.
    Item.hammer = 50;
}
```

## Vanilla References

| Hammer | Power | `Item.hammer` |
| --- | ---: | ---: |
| Wooden Hammer | 25% | `25` |
| Copper Hammer | 35% | `35` |
| Rich Mahogany Hammer | 35% | `35` |
| Boreal Wood Hammer | 35% | `35` |
| Palm Wood Hammer | 35% | `35` |
| Ash Wood Hammer | 45% | `45` |
| Tin Hammer | 38% | `38` |
| Iron Hammer | 40% | `40` |
| Ebonwood Hammer | 40% | `40` |
| Shadewood Hammer | 40% | `40` |
| Lead Hammer | 43% | `43` |
| Silver Hammer | 45% | `45` |
| Tungsten Hammer | 50% | `50` |
| Gold Hammer | 55% | `55` |
| Pearlwood Hammer | 55% | `55` |
| The Breaker | 55% | `55` |
| Flesh Grinder | 55% | `55` |
| Platinum Hammer | 59% | `59` |
| Meteor Hamaxe | 60% | `60` |
| Rockfish | 70% | `70` |
| Molten Hamaxe | 70% | `70` |
| Pwnhammer | 80% | `80` |
| Haemorrhaxe | 80% | `80` |
| Hammush | 85% | `85` |
| Chlorophyte Jackhammer | 90% | `90` |
| Chlorophyte Warhammer | 90% | `90` |
| Spectre Hamaxe | 90% | `90` |
| The Axe | 100% | `100` |
| Solar Flare Hamaxe | 100% | `100` |
| Vortex Hamaxe | 100% | `100` |
| Nebula Hamaxe | 100% | `100` |
| Stardust Hamaxe | 100% | `100` |

# Drills

// TODO: ExampleDrill

> [!NOTE]
> [**Click here to view full implementation**](https://github.com/treehouse-modding/toolkit/blob/main/Content/Tools/ExampleDrill.cs).

## Vanilla References

| Drill | Power | `Item.pick` |
| --- | ---: | ---: |
| Cobalt Drill | 110% | `110` |
| Palladium Drill | 130% | `130` |
| Mythril Drill | 150% | `150` |
| Orichalcum Drill | 165% | `165` |
| Adamantite Drill | 180% | `180` |
| Titanium Drill | 190% | `190` |
| Chlorophyte Drill | 200% | `200` |
| Drax | 200% | `200` |
| Spectre Drill | 200% | `200` |
| Solar Flare Drill | 225% | `225` |
| Vortex Drill | 225% | `225` |
| Nebula Drill | 225% | `225` |
| Stardust Drill | 225% | `225` |

# Multi-tools

> [!NOTE]
> [**Click here to view full implementation**](https://github.com/treehouse-modding/toolkit/blob/main/Content/Tools/ExampleMultitool.cs).

Some tools combine multiple tool types by setting more than one tool property. For example, [**Hamaxes**](https://terraria.wiki.gg/wiki/Hamaxes) set both `Item.hammer` and `Item.axe`, while the [**Pickaxe Axe**](https://terraria.wiki.gg/wiki/Pickaxe_Axe) and [**Picksaw**](https://terraria.wiki.gg/wiki/Picksaw) set both `Item.pick` and `Item.axe`.

You are free to create your own combinations by assigning multiple tool properties to the same item. Each field is evaluated independently, so all normal rules still apply. For example, `Item.axe` is still multiplied by `5` to determine axe power, while `Item.pick` and `Item.hammer` correspond directly to their displayed power values.

## Example

```cs
public override void SetDefaults()
{
    // Sets the pickaxe power of the item.
    Item.pick = 50;

    // Sets the axe power of the item. This value is multiplied by 5, so setting this to 5 actually makes it have 25% axe power.
    Item.axe = 5;

    // Sets the hammer power of the item.
    Item.hammer = 50;
}
```