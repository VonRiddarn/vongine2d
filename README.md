<p align="center">
  <img src="repo/logo.png" alt="Vongine 2d logo"/>
</p>
<p align="center"><strong>The simple engine for simple games!</strong></p>

# Vongine2d

Vongine2d is a 2D game engine based on the MonoGame framework.

## Disclaimer

This engine is made as a fun learning experience. It aims to provide the necessary functionality to create a game and perform said functionality as efficiently as possible. However, it does not intend to compete with other existing game engine solutions. This game engine serves more as a framework or module atop the MonoGame framework.

**Use at your own discretion**

## Planned Features

### Entity-Component Approach

All objects exist in game space and run logic on ticks. An object could be empty or contain components that change the object's behavior, such as: Transform, Physics, Collider, etc.

### Tilemap Integration

An easy way to create tilemaps and fill those tilemaps with objects. The objects inside the tilemap can have components added to them for easier logic manipulation.

### Event Listeners

Objects will have default overrideable events such as:

- `OnPositionMove(oldPos, newPos)`
- `OnSpriteChanged(oldSprite, newSprite)`
- `OnCollision(other, collisionPoint)`

### Particle System

A decorative system for creating particles in screen or world space.

### Scripting Compatibility

User-created C# scripts that are initialized at runtime and integrate with the engine seamlessly.

### Integrated Development Environment

A full-fledged IDE complete with:

- Object hierarchies
- Scene management
- Component editing
- Visual state representations

## Licensing

This product is released under the MIT license. Please refer to the provided [LICENSE](LICENSE) file for more information.
