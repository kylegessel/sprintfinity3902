# Sprintfinity 3902 Project

This is a public repository for an Ohio State class. The end goal is to
recreate the first dungeon from the classic NES game, *The Legend of Zelda*.
This README specifically addresses the Code base during Sprint 3.

## Initial Startup and Execution

Download the zip file above and extract. Open the solution (.sln) on your
machine. This will open vscode. From there execute the project by clicking the
green arrow at the top of the window.

## How to Play

You can use either WASD keys or the arrow keys to control Link around the 
screen.

'z' and 'n' causes Link to sword attack in the direction that he is facing.

'1' key uses Link's bomb.

'2' key uses Link's Boomerang.

'e' key shows a demo of what Link looks like in his damaged state.

'l' and 'k' allows you to cycle through each of the rooms in the dungeon.

'p' pauses the game and gives you a map menu. On this map menu, you can click
on a room to go there.

'r' resets the program to its original state and 'q' quits the program.

## Authors

Bailey Ardrey, Kyle Gessel, Ben Hobson, Brad Knez, and Casey Vancauwenbergh

## Things to be implemented next sprint
* Inventory and Health Systems
* Smooth transitions between rooms
* Interactions with doors and exploding walls


## Known bugs
* Goriya does not always decorate.
* Link sometimes "jiggles" when running into two block's hitboxes.
* Link may be able to escape bounds of room.
* Dragon projectile collides with walls and can be destroyed.