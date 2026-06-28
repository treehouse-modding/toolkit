# Intro to Procedural WorldGen using `WorldUtils.Gen`
> written by: maxie

### Prerequisites:
> This guide assumes you are familiar with C# syntax and terms, and basic world generation code.
### Other resources:
 - The original tModLoader Wiki guide: https://github.com/tModLoader/tModLoader/wiki/World-Generation#procedural-syntax

One approach to writing world generation code is to use Vanilla's *procedural syntax*, using the method `WorldUtils.Gen`. It's what Vanilla uses for a number of more complex, and more recent structures, like the Sword Shrine and Living Mahogany Trees. It uses a declarative syntax that allows you to write worldgen code quickly and effectively. Let's take a look:

## `WorldUtils.Gen`

```cs
Point point = new Point(i, j);
WorldUtils.Gen(point, new Shapes.Circle(8, 8), new Actions.SetTile(TileID.Dirt));
```
The above code takes a point and places dirt in a circle with a radius of 8 tiles. 
The main attraction here is that `WorldUtils.Gen` method, as it's what actually runs the procedure. You can see that it takes in 3 arguments: A point, a Shape, and an Action. 
The **Shape** essentially constructs a collection of points, running the **Action** at each point.
You can add in your own custom shapes and actions, but vanilla already has most of them, including some interesting ones. 


## Using Shapes, Modifiers, and Actions for Fun and Recreation
Let's look at a more advanced example...

```cs
Point point = new Point(i, j);
WorldUtils.Gen(point, new Shapes.Circle(8, 8), Actions.Chain(
  new Modifiers.Blotches(),
  new Actions.ClearTile(),
  new Actions.SetTileKeepWall(TileID.Dirt, true, true)
));
```

>### Notice:
>Actions.Chain is a static method, while most other actions are classes that need to be instantiated. Sometimes, I accidentally write `new Actions.Chain`, and it's a mild inconveinence. Hopefully you won't make that same mistake now!

The key differences with this example is that instead of using just one Action, we use the method `Actions.Chain` to chain (wow!) multiple actions together, as well as using a new kind of Action, a Modifier. The only difference between `Actions` and `Modifiers` is the class they're a part of. They work identically under the hood, but the `Modifiers` class is generally reserved for Actions that *modify the Shape* that subsequent actions apply to, either by terminating the chain (skipping all subsequent actions) or by adding new tiles to the shape. In this example, we use the `Blotches` modifier, which randomly adds small spots to our shape, giving it a more lumpy, natural look.
Now that you know how to use procedural WorldGen, I would recommend using your IDE to peruse through some of the Shapes, Modifiers, and Actions that vanilla provides. There's a lot of neat stuff you can do with just the stuff that vanilla provides. 


## ShapeData & ModShapes; Saving for Later

Oftentimes, especially when using modifiers like `Modifiers.OnlyTiles` or `Modifiers.SkipTiles` to mask out certain tiles, you will want to save a shape for later to perform multiple passes. Let's take our example from earlier, and save the tiles it acts on:
```cs
ShapeData shape = new();
WorldUtils.Gen(point, new Shapes.Circle(8, 8), Actions.Chain(
  new Modifiers.Blotches(),
  new Actions.ClearTile(),
  // By calling .Output() from an Action, you can save the coordinate of the tile you're acting on to a ShapeData instance. These points are relative to the origin of the shape, and do not correspond to points in the world.
  new Actions.SetTileKeepWall(TileID.Dirt, true, true).Output(shape)
));
```

You can also call .Output directly on a shape:
>TODO: This might be broken!
```cs
ShapeData shape = new();
(new Shapes.Circle(8, 8)).Output(shape);
```

Now that we saved the points, we can use them again and again, and move them around, using `ModShapes`. `ModShapes` essentially apply a procedure to a collection of points.
```cs
// Let's place the same shape that we just put down, but 20 tiles to the right, filling it in with mud:
WorldUtils.Gen(point + new Point(20, 0), new ModShapes.All(shape), Actions.Chain(
  new Actions.SetTileKeepWall(TileID.Mud, true, true)
));
```

ModShapes also includes some more interesting ways to use ShapeData. Maybe you want to give your dirt blob a ruby outline:
```cs
WorldUtils.Gen(point), new ModShapes.OuterOutline(shape), Actions.Chain(
  new Actions.SetTileKeepWall(TileID.RubyGemspark, true, true)
));
```

## Actions.Custom
Sometimes, you may want to do something more complex to a shape, that can't be covered by an existing Action or Modifier. For this, you can use `Actions.Custom`, which takes in a delegate as an argument:
```
WorldUtils.Gen(point + new Point(20, 0), new ModShapes.All(shape), Actions.Chain(
  new Actions.Custom((i, j, args) => {
    // Do all sorts of cool stuff here!
    Tile tile = Framing.GetTileSafely(i, j);
    if (CoolThing) {
      CoolerThing(tile);
    } else if (CoolestThing) {
      SecondCoolestThing(tile);
    }

    // The value you return doesn't actually matter. It's expected that returning false would terminate the chain and stop subsequent actions from executing, but it doesn't, for some reason.
    return true;
  })
));
```
Counterintuitively, it can be much more freeing to write using just a single custom action if you want more complex logic, as the standard action chains dont have any methods for complex control flow.

>TODO: Add section for optimizing usage after profiling a few methods.
