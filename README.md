# Event System

An Event System using ScriptableObjects as event channels. Scripts with the same event channel can Invoke / Listen to these connected events to react accordingly without the need of a direct reference. This package was inspired by one of Unity's Open Projects and [this article](https://unity.com/how-to/architect-game-code-scriptable-objects).

## Benefits

- Cross-scene events
- Remove the need for Singletons
- Easy search of which component uses what event by searching for references in scenes on a scriptable object event

## Planned Features

- Being able to easily create custom events without having to write a new SO class for it