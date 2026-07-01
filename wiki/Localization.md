# Summary

1. [Prerequisites](#prerequisites)
2. [Introduction](#introduction)
3. [Languages](#languages)
4. [Keys](#keys)
5. [Displays](#displays)
    * [Colors](#colors)
    * [Items](#items)
        * [Vanilla](#vanilla)
        * [Modded](#modded)

# Prerequisites

* [Hjson](https://hjson.github.io/)

# Introduction

Localization is what gives names and descriptions to things. And you may ask, why not just set them directly on code? The answer is, languages and translations! Through localization, you can easily provide language support to all languages supported by tModLoader.

This page demonstrates how to create and use localization. By the end of it, you will have learned how to:

* Create custom localization.

# Languages

| Language | Abbreviation | File
| --- | --- | --- |
| English | en-US | `en-US.hjson` |
| Italian | it-IT | `it-IT.hjson` |
| French | fr-FR | `fr-FR.hjson` |
| German | de-DE | `de-DE.hjson` |
| Spanish | es-ES | `es-ES.hjson` |
| Russian | ru-RU | `ru-RU.hjson` |
| Mandarin | zh-Hans | `zh-Hans.json` | 
| Brazilian Portuguese | pt-BR | `pt-BR.hjson` |

# Keys



# Displays

## Colors

You can apply colors to localized text using the `[c:<color>:<text>]` format.

> [!NOTE]
> Colors must be specified as hexadecimal RGB values.

### Example

```json
CustomItem: {
    # Displays the item name in red.
    DisplayName: "[c/ff0000:Custom Item]"

    # Displays the tooltip in green.
    Tooltip: "[c/00ff00:Custom Item Tooltip]"
}
```

## Items

### Vanilla

For vanilla items, use the `[i:<type>]` format, where `<type>` is the item's numeric type.

```json
CustomItem: {
    DisplayName: "Custom Item"

    # Displays a Dirt Block before the tooltip.
    Tooltip: "[i:2] Custom Item Tooltip"
}
```

### Modded

For modded items, use the `[i:<mod>/<item>]` format, where `<mod>` is the mod's internal name, and `<item>` is the item's internal name.

```json
CustomItem: {
    DisplayName: "Custom Item"

    # Displays a Custom Item before the tooltip.
    Tooltip: "[i:CustomMod/CustomItem] Custom Item Tooltip"
}
```