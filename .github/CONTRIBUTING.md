# Guidelines

## Syntax

Our syntax is defined in the [**.editorconfig**](https://github.com/treehouse-modding/toolkit/blob/main/.editorconfig) file located at the project's root. Most modern IDEs will automatically detect and apply these settings. If your editor does not support `.editorconfig`, the following sections outline the conventions and style used throughout the project.

### Naming

| Member | Accessibility | Prefix | Convention |
| --- | --- | --- | --- |
| Classes | Any | None | `UpperCamelCase` |
| Structs | Any | None | `UpperCamelCase` |
| Records | Any | None | `UpperCamelCase` |
| Enums | Any | None | `UpperCamelCase` |
| Constants | Any | None | `UpperCamelCase` |
| Properties | Any | None | `UpperCamelCase` |
| Fields | Public | None | `UpperCamelCase` |
| Fields | Private | None| `camelCase` |
| Methods | Any | None | `UpperCamelCase` |
| Events | Any | None | `UpperCamelCase` |
| Delegates | Any | None | `UpperCamelCase` |
| Interfaces | Any | `I` | `UpperCamelCase` |

> [!NOTE]
> Classes deriving from a mod type should be suffixed with the corresponding type name. For example: `public class ExampleSwordItem : ModItem`.

---

### Syntax

Use expression-bodied accessors for properties, indexers, and events:

```cs
public static int Property
{
    get => field;
    set => field = value;
}
```

Use block bodies for methods:

```cs
public static void Execute()
{
    Console.WriteLine("The cake is a lie");
}
```

Use `var` when applicable:

```cs
var structure = new Structure();
```

---

### Tabs

Tabs have a size of **4 spaces**.
