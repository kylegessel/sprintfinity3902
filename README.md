# Sprintfinity 3902 Project

This is a public repository for an Ohio State class. The end goal is to
recreate the first dungeon from the classic NES game, *The Legend of Zelda*.
This README specifically addresses the Code base during Sprint 4.

## Initial Startup and Execution

Download the zip file above and extract. Open the solution (.sln) on your
machine. This will open vscode. From there execute the project by clicking the
green arrow at the top of the window.

## How to Play

Press Enter to start!

You can use either WASD keys or the arrow keys to control Link around the 
screen.

'z' and 'n' causes Link to sword attack in the direction that he is facing.

'1' (one) key uses Link's equipped item

'e' key shows a demo of what Link looks like in his damaged state.

'l' and 'k' allows you to cycle through each of the rooms in the dungeon.

'p' pauses the game and gives you a map menu. On this map menu, you can click
on a room to go there.

'r' resets the program to its original state and 'q' quits the program.

## Authors

Bailey Ardrey, Kyle Gessel, Ben Hobson, Brad Knez, and Casey Vancauwenbergh


## Known bugs/ things to fix
* Room with the Old Man is not a locked door.
* If you die during a room transition, the game goes into a broken state.
* Fire attacks don't track link.
* Dungeon rooms can be off by a few pixels after moving rooms.
* Sometimes doors push link back into previous room after walking into it.
* Fairys can leave the dungeon.
* Goriya boomerang doesn't move down when the game is paused.