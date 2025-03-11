Game-351-P3
 
Contributors:
Sam Dalton
Matthew Rust
Samiur Rahman
Connor Hubble

What each person did: 
Sam Dalton
- Set up the dolly track and vcams for cutscene
- wrote and implemented a script to exit the cutscene with ctrl
- implemented rain and lightning for monsoon via particle system

Matthew Rust
- wrote barrel script
- wrote footsteps script
- wrote lightening audio script
- wrote soundmanager script
- wrote bandit taunt script
- modified various other scripts to account for audio and animations
- gave the sheriff and each bandit a gun prefab and made it a child of the appropriate hand
- created firepoint object
- created and implemented muzzle flash effect for bandits (this is technically just a very bright sphere but it does the trick.  Also this is not on the sheriff because of how bright it is.)
- implemented shooting mechanic and animation
- implemented kicking mechanic and animation
- added audio to rain and thunder (would've added it to lightening as well be the scene became obnoxiusly loud when I did that so I scrapped the idea.)
- added bandit taunts and death animation to each bandit
- added shooting animation to sheriff and bandits
- created explosion particle effect
- implemented explosion to the dynamite barrels.
- added rigidbodies to barrels, buckets, tumbleweeds and crates (Note: the props around the player are the only props I can confirm I did this too.  I tried to go around and do it for all the props but I gave up midway through because I was having difficulty finding everything in the heirarchy.)  
- added background music and implemented script to change it accordingly.
- added health bar UI
- wrote player health script
- added audio for player getting hit
- implemented player health system
- created a Bandit wandering script (this did not end up getting implemented due to the fact the result just looked weird, especially when the bandits wandered up onto porches and into buildings.)
- implemented camera toggle

Connor Hubble
- wrote script for 1st to 3rd person camera change 
- assisted in debugging the dolly track
- created first person camera
- edit cam settings

Samiur Rahman
- wrote shooting script for player
- wrote kicking script for player
- wrote death animation script for bandits
- wrote bullet script

Choice elements implemented:
- Bandits Shoot back
- Monsoon Weather
- 1st to third person camera toggle

Process of Installation:
Step 1. Unzip the file and put the resulting folder somewhere on your computer.
Step 2. In the Unity hub click Open and from there click add project from disk.
Step 3. Find where you stored the folder, select it then click add project.
Step 4. Open the newly created Unity project.
Step 5. Once open and loaded, press play and enjoy.

Known Errata (assuming that means issues):
- transition between shooting and walking animations is not that smooth
- unable to implement the cutscene cancel
- cutscene resets whenever camera is toggled to 3rd-person

Key Mappings:
- W - forward
- S - backwards
- A - left
- D - right
- F - Shoot
- space - kick
- (hold) left ctrl - freeze Sheriff animation (NOTE: this was just used for early testing, ideally shouldn't be needed in the completed project.)

References -
EASY Rain Particle in Unity (Particle System Tutorial)
https://www.youtube.com/watch?v=SrWrUN56UWU 
made monsoon rain

Lightning 
https://www.youtube.com/watch?v=5zec4nUewgk
https://www.youtube.com/watch?v=IahWKsxXzx0
