# Project README

###  Time spent on this part
I spent just shy of 8 hours recreating the first level, and 2 hours after that doing the iterations on it

###  Architectural and technical choices
This project was made using only free Assets from the store, as well as some Assets that I had personnaly developped in the past (Hand pointer and the drawing mechanic among others).

I used Unity 2019.26.4f which is the Unity version I'm more accustomed to. 

I chose to divide the game's main managers into separate GameObjects, each with a corresponding Singleton script.

![Sans titre](https://user-images.githubusercontent.com/71012726/160062868-24b9fa70-aab5-4dad-b5ec-eb11e239a086.png)

Game Manager manages the "global" aspect of the game, like the player level, golds or even the number of turrets placed. Here they are saved as temporary variables in the game, which means that everything will reset after each game, but they could be saved using the PlayerPrefs.

Waves Manager manages the waves behaviour, ranging from the number of monsters spawned to their level (which then changes their health, attack value and move speed).

Finally, Sound Manager is a collection of all the SFX that are played during the gameplay.

The UI is managed in another manager, which is attached to the main Canvas of the game, and the turret buttons are managed somewhere else, directly in the Canvas by a script called "UIButtons". 
###  Choice of features
As I had limited time, I had to choose and sort by order of importance the features from the main game that I wanted to reproduce.
Some were scrapped, some stayed, but in the end that's what it looks like : 
#### Features available in my game are : 
- Turrets
- Monsters
- Castle
- Golds
- Waves
- Player level
- Full working UI
- Sound effects
- Ambiance
#### Features I chose not to reproduce : 
- Turrets connection
- Castle death 

They are however one feature I chose to add to the main game, which is the "finger" following the mouse.
My experience in Hyper Casual showed me that ads with a hand pointer had much better results, mainly because of the fact that it emphasizes the player's actions and help viewers understand the gameplay much faster.

![2](https://user-images.githubusercontent.com/71012726/160065486-9dcc4ad4-cb98-4859-b4e9-d73f51aee5ce.png)



### What was hard
To be honest, nothing was truly challenging, but the part I spent the most time was coding the Turrets behaviour, I first chose an Asset from the store but I wasn't pleased at how it was working so I did one myself.
### Base Game
![3](https://user-images.githubusercontent.com/71012726/160066214-b4ff43e7-3341-41ba-9698-59f3b94e73ce.png)

You can play the base game up to theoretically forever as long as you don't die. Each wave adds monster to it, monsters that are spawning from a random spawner among two. You gain gold when you kill a monster, and gold is used to either purchase a turret, level up or refresh the store.
You can merge turret by placing a new turret on an existing one, and the merged turret will grow stronger each time.

Turrets of different rarity will randomply pop in the shop when your refresh it, rarity picked among Green (common), Blue (Rare) and Purple (Epic)

![4](https://user-images.githubusercontent.com/71012726/160068594-55cd0b9f-cba9-4eb6-90f2-c16b908e114e.png)


### Iteration 1 : Winter Theme
My experience in Hyper Casual showed me that seasonnal events (such as Halloween/Superbowl map, icons or special missions) are working really well in games, so I figured my first iteration would be a winter map ! 
I changed the design of the map to be more snowy, with a frost effect. All the texture have been "snow-ified" and I added a little santa hat to the monsters. Furthermore, I changed the ambiance music to a more Christmas sounding melody. 

![5](https://user-images.githubusercontent.com/71012726/160071543-739a8a26-6258-4fbf-952c-5235eb42b0a7.png)

### Iteration 2 : Drawing mechanic
A populat trend right now is the drawing mechanic, which consist of drawing an item that you can use in game or something to help you beat the level. Here I created a feeling of urgency that the player could fix by drawing the fences that'll protect him from the horde of monsters.

![6](https://user-images.githubusercontent.com/71012726/160071972-10fdeaf4-bbed-43ae-bb2e-9bc508dcd6fd.png)


### Iteration 3 : Legendary Item
The hyper casual ads are usually divided into "intentions", whether its a pro or a frustrating gameplay, something is always made in the game to make the viewer react. My favorite intention is the Frustrating one, so I created this fake weapon on the ground, with some particles to increase its appealing effect,  which if taken could be of great use to the player, but during the whole rush I'm obviously never touching it.
This will trigger the viewers' curiosity as they would want to know what would happen if you took it, making them more likely to click on the ad.




###  Final word
This was a great opportunity, I actually learned some things with the tower aggro mechanic, and it was super fun to recreate a tower defense style level !

Thanks for reading, 

William LINA
