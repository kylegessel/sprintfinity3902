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

'l' and 'k' allows you to cycle through each of the rooms in the dungeon. (This
is intended for game testing and is NOT an intended game feature. For this
reason, it can causes issues like no longer locking rooms with enemies inside
upon entry)

'p' pauses the game and gives you a map menu. In this pause menu, you can use
either arrow keys or 'A' and 'D' to change the currently selected room.

'r' resets the program to its original state and 'q' quits the program.

## New Features and gameplay

crit

map generation

new floors

shops

new bosses + enemy type

doors close


## Guide

## Cheat Guide

If you would like to simply see the new room generation and new bosses, we
reccomend using 'l' and 'k'.

To get to the boss room hit "l" 6 times from the start room.

To get to the shop room hit "l" 7 times from the start room or once from the 
boss room. This is a good way to get to the next floor quickly as you can enter
the staircase in this room.

We strongly reccomend you give the floor a chance to load before hitting 'l' or
'k'. That reason is briefly discussed in bugs below, but it can cause issues
where the dungeon generator may not fully complete operation.

## Authors

Bailey Ardrey, Kyle Gessel, Ben Hobson, Brad Knez, and Casey Vancauwenbergh


## Known bugs/ things to fix

* Fairys can leave the dungeon.
* Goriya boomerang doesn't move down when the game is paused.
* Double hits at full health.