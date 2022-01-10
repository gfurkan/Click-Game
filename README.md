# Click-Game
I tried to develop a Click Game and make it well optimized.

## Planning && Preparing
When I read the GDD I decided to seperate step scripts and use inheritance. Also, I decided to use Singleton desing pattern to access a few scripts from another scripts easily. After planning, I dowloaded the environment asset and import it to Unity. After I designed the scene I created folders that I'll use later.

## Coding
### Player Controls
Firstly, I started to code object choosing mechanic. I used raycast to select object and this is the only script that I used Update method. I created an event in this script and added all steps object control methods when they get activated. So I didn't use Update method for all of them, event only worked when player clicks and it helped me to optimize the game.

### Step Change Controls
I created a switch case and added step transitions in it. I added it to the event and used Observer design pattern so I didn't use Update method here too. I created enum to define case names so someone who checks my code can understand all steps by the case names.

### Step Super Class
After finishing object choosing mechanic, I started to code super class of steps. I determined what sub classes might have common methods and I added them to this super class. So I didn't code these methods in all of step classes.

### Step Sub Classes
I generally used super class methods but some mechanics were different for each steps, so I coded some specific methods to create these mechanics. I created a method to use it at the end of the step for all of them and changed enum value to change step.

### Door Step Control
This script is the end game controller. It works when player finish all previous steps. This script shows an Image on the door handle and when player click on it particles are played and level finish UI is showed. I used IPointerClickHandler interface to check player clicked to the Image, this allowed me to don't use Update method in this script.

### DoTween
I used dotween tool to move,rotate and fade objects. It helped me to work with events because It's methods are just requires to call once.

## UI
I compressed all pngs to reduce their sizes.

## For the Performance
I reload the level using Scene Manager. It's not a good way to change level, levels should be designed in a prefab and controlled by a Level Manager script. I checked profiler and didn't see anyt performance issue.
