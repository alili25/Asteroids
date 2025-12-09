# Asteroids - Homework1


## Hosted Game Link
Play the WebGL build here:  
https://play.unity.com/api/v1/games/game/1eacb3f3-f722-4c5a-bebd-251bc0797a7e/build/latest/frame


## Summary
In this project we were tasked with making a recreation of the arcade game, Asteroids, in Unity. The player uses their arrow keys that can rotate and accelerate, and the spacebar to shoot bullets, and destroy incoming asteroids. I used this video for reference: https://www.youtube.com/watch?v=wzQ9Xn406wc


## Additional Features Added 

- Added basic particle effects shown each time you destroy an asteroid or if the player is destroyed.  
- Unfortunately, adding this effect caused the player collider to glich. The player shakes and the death is triggered incorrectly. I don't know exactly what the reason is for this, but I think it had something to do with the particle effect object modifying the hierarchy or physics layer when the game would run. I still decided to keep it in the game becuase you could still do all the basic functions, you just die randomly lol. You were right Dr. Horn I should've started earlier :(
