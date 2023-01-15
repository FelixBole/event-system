# Event System

An Event System using ScriptableObjects as event channels. Scripts with the same event channel can Invoke / Listen to these connected events to react accordingly without the need of a direct reference. This package was inspired by one of Unity's Open Projects and [this article](https://unity.com/how-to/architect-game-code-scriptable-objects).

## Installation

1. In Unity, from the package manager, click the `+` icon
2. Select `Add package from git URL...`.
3. In the text box that appears, enter this projects git url `https://github.com/FelixBole/event-system.git` 
4. That's it !

## Benefits

- Cross-scene events
- Remove the need for Singletons
- Easy search of which component uses what event by searching for references in scenes on a scriptable object event

## Planned Features

- Being able to easily create custom events without having to write a new SO class for it