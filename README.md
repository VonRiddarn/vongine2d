<p align="center">
  <img src="repo/logo.png" alt="Vongine 2d logo"/>
</p>
<p align="center">The simple engine for simple games!</p>

# Vongine2d
Vongine2d is a 2d game engine based on the Monogame framework.<br />

## Disclaimer
This engine is made as a fun learning experience. It aims to provide needed functionality to create a game, and perform said functionality as efficiently as possible. However it does not intend to compete with other existing game engine solutions. This game engine serves more as a framework or module atop the Monogame framework.<br />
**Use at your own discretion**

## Planned features

### Object - Componment approach
All objects exist in game space and run logic on ticks.
An object could be empty or contain components that changes the objects behaviour, such as: Transform, Physics, Collider etc...

### Tilemap integration
An easy way to create tilemaps and fill those tilemaps with objects. The objects inside the tilemap can have components added to them for easier logic manipulation. <br />

### Eventlisteners
Objects will have default overrideable events such as:
* OnPositionMove(oldPos, newPos);
* OnSpriteChanged(oldSprite, newSprite);
* OnCollision(other, collisionPoint);

### Particle system
Decorative system for creating particles in screen or world space.

## Licensing
This product is released under the MIT license.
Please reference to the provided "LICENSE" file for more information.