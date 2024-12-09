/*Is the game too easy or hard? Give 2 unique reasons why it is easy or hard.

I woul'd say it is a bit too easy. The game doesn't get harder, and the phase button actually negates the main gamplay feature of the game, which is the dodging and weaving between obstacles and collection of powerups to keep your timer from going down.

What 2 changes would you do to make it easier or harder?

I think as the game goes for longer, the obstacles could move faster and faster, and perhaps some different kinds of obstacles that moved in different ways.

List 2 things that would give it a "wow" factor.

I would redo the obstacles to be a bit more interesting/fitting for the theme, and I would redo the phasing mechanic to make it feel satisfying and rewarding to do over and over again.

What 2 parts of the game are fun? 

I like the straightforward controls, and I thoroughly enjoy the simplicity of keeping that counter up!

The variety in the obstacle placements keep the game exciting and replayable!

What 2 parts of the game are tedious?

For one, the lack of turning animations, even though they are present within the files.

Additionally, the lack of clear theming with the powerups and obstacles not being themed after the technological theme of the walls, floor, and player character.
 
 */

/*
 
I did eight different things to make the game a bit more fun: 

1. I added a progressive difficulty, meaning the better you do, the faster the game gets.

2. I redid the obstacles to be giant sawblades sawing through the ground. Not revolutionary, but their longer hitboxes makes the game block you off from certain sections for periods of time.

3. I changed the phasing mechanic into a dash, which can be used to get out of sticky situations, but just like the phase, makes you unable to pick up powerups. This mechanic can be activated when pressing spacebar and heading in a certain direction.

4. I changed the powerups to floating hourglasses, and made them spin.

5. I made the character have turning animations, which are managed by an internal variable to prevent the snapping from relating animations directly to InputAxis.

6. I extended the timer in order for it to house more than just integers. The tenths of seconds serve well, as I drastically lowered the amount of time the powerups give you.
 
7. I varied the spawn Cycle randomly as things spawn, so gameplay can feel more varied, with more clustered parts, and less clustered parts as the game moves on.

8. I changed the system in which the game chooses to spawn poweruips and obstacles, where it is random, and more likely to repeat clusters of power ups or obstacles, BUT it has a failsafe that makes it switch over if 12 of the powerups or obstacles spawn in a row, in order to ensure the game is always balanced and possible.

 */