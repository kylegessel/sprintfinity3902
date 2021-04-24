# Sprintfinity 3902 Project

This is a public repository for an Ohio State class. The end goal is to
recreate the first dungeon from the classic NES game, *The Legend of Zelda*.
This README specifically addresses the Code base during Sprint 5.

## Initial Startup and Execution

Download the zip file above and extract. Open the solution (.sln) on your
machine. This will open vscode. From there execute the project by clicking the
green arrow at the top of the window.

## How to Play

Press Enter to start!

You can use either WASD keys or the arrow keys to control Link around the 
screen.

'x' and 'n' causes Link to sword attack in the direction that he is facing.

'b' and 'z' uses Link's equipped item

'l' and 'k' allows you to cycle through each of the rooms in the dungeon. (This
is intended for game testing and is NOT an intended game feature. For this
reason, it can causes issues like no longer locking rooms with enemies inside
upon entry)

'p' pauses the game and gives you a map menu. In this pause menu, you can use
either arrow keys or 'A' and 'D' to change the currently selected item.

'r' resets the program to its original state and 'ESC' quits the program.

## Guide

The goal is to get to the next floor by defeating the boss of each floor. Upon
beating the boss of floor 5 you can enter the triforce room and win the game! A
succesful run will take approximately 30 minutes in total.

The boss battle will always be behind a locked door that requires a key to 
enter. There is a guarenteed key somewhere else on the floor that you have to 
find before entering the boss room. There are other helpful items you can find
like the map or the compass that can point you in the direction of the boss room.

After defeating the boss of each floor, you'll be presented with a room that
gives you a heart container and an item for free. You'll also find a few items
for sale in this room that can be purchased with the rupees you have collected.
In the bottom left of this room you will find the staircase that can take you
to the next floor of the dungeon.

Each boss has a unique interaction with an item. If you would like to the most
*natural* way, I would suggest skipping this section. Spoilers Ahead.
* Floor 1: Aquamentus has no trick, but bombs can do a signficant amount of
damage.
* Floor 2: Dodongos can be slain by placing bombs in front of them so that they
eat them.
* Floor 3: Didoggers can be slain after pacifying them with the flute. This 
puts it in a vulnerable state for attack.
* Floor 4: Gohmas can be slain with the bow by shooting it while its eye is
open.
* Floor 5: Manhandla has no trick. As you kill parts of the Manhandla, the 
remaining body parts speed up.

If you have trouble, check out the Cheat Guide below.

## New Features and Gameplay

Critical hit chance have been added. This gives link a chance to do double
damage with his hit. You can tell you have had a critical hit, because it will
make a unique sound.

Dungeon layouts are now randomly generated to ensure a unique experience for 
each floor. New floors with new color schemes and difficulties were added.

A new enemy (Ropesnake) and many new bosses have been added. The game now 
extends past beating the Aquamentus and has 4 new bosses to beat. One lives at
the end of each floor.

Shops have been added. After beating each boss, you'll have a chance to buy
helpful items with your rupees.

Doors now close when you enter a room with enemies until you slay every enemy
in that room.

## Cheat Guide

The game is designed to be quite challenging, so we've created this guide if
you simply want to see all the new features quickly.

If you would like to simply see the new room generation and new bosses, we
recommend using 'l' and 'k'.

To get to the boss room hit "l" 6 times from the start room.

To get to the shop room hit "l" 7 times from the start room or once from the 
boss room. This is a good way to get to the next floor quickly as you can enter
the staircase in this room.

*We strongly recommend you give the floor a chance to load before hitting 'l' or
'k'.* That reason is briefly discussed in bugs below, but it can cause issues
where the dungeon generator may not fully complete operation.

## Authors

Bailey Ardrey, Kyle Gessel, Ben Hobson, Brad Knez, and Casey Vancauwenbergh


### Known bugs/ things to fix
* Goriya boomerang doesn't move down when the game is paused.
* Double hits at full health.
* Reseting the game doesn't clear out the pause menu's selectable inventory.
While the player can't use said item, it can still be selected.
* Early inputs of "l", "k" or reset can cause a runtime error. This is because
the files that build the game have not finished loading, and thus can't be
deleted. This error is seen on button press for reset and upon next floor entry
for "l" and "k". This can be avoided by waiting until after the room has loaded
to use these commands.
* Upon next floor entry, your secondary item is unequipped.
* Sometimes, an enemy may attack you as soon as you get through the door.
Given more time we would have experimented with I-frames upon entry.
* Enemies have a chance to push link through solid tiles.
* We would refactor more code given more time.




### Intentional game design
Here is a small list of things that *may* look to be bugs, but are intentional.
this is related to the bugs category, but slightly different.
* Fairies can leave the dungeon. You have to be quick to grab them!
* Link's sword or item animations can be canceled by new inputs. This may make 
it appear like the sword doesn't come out, but that is simply because a new
input has been received. We have the capability to lock link into the sword
animation, but found that to be less enjoyable, especially when dodging
fireballs. For the reason we chose to go with this implementation.
* Items drop quite frequently. Given more time we would have liked to tweak the
item drop table to create a more interesting playing experience.
