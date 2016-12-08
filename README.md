# TobPaeChargeAI2
This is one of my AI2 class assignments at Chulalongkorn University.
Tob Pae Charge (aka Ping Pong Charge) came from my local childhood game which actually uses high level game theory, 
prediction and calculation in very limited time (2 - 3 seconds per round).

##How to play
I have adjusted the rules a bit to be easier to play with AI.
* Player start with 5 HP (Health) and 0 MP (Charged)
* Max MP is 3
* Players have a very little limit of time to make action
  * __ATTACK__ (A) - use 1 MP to deal 1 damage to enemy. Only hit enemy while they're doing CHARGE.
  * __DEFEND__ (D) - defend enemy's ATTACK so they waste their MP;
  * __CHARGE__ (C) - gain 1 MP but can be interrupt by enemy's ATTACK or SUPER ATTACK.
  * __SUPER ATTACK__ (S) - use 3 MP to deal 5 damages to enemy. Only enemy SUPER ATTACK can stop yours.
* Goal is make your enemy's HP reach 0 first. 

(Actual rule, there're more than two players and no HP if you're hit once, you dead. 
Moreover, you need to _sing_ its song and doing hand sign while playing. Here's an example video.https://www.youtube.com/watch?v=eTUy_khZWLQ)

##What've I done?
* basic GUI
* Game manager so it's playable
* AI using MINIMAX algorithm

##What's next?
I'm not sure if I'll have time to do maintainance or add more features _BUT_ if I do...
 - [ ] Add SFX and BGM
 - [ ] Improve AI
 - [ ] Improve GUI
 - [ ] Add more charactor and their special charactoristic (E.g. damage per hit, Max HP, Max MP, MP gain, Super Attack)
 

