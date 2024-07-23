# console-card-game
C# 9.0

.NET 5.0.

Console-based turn-based card game for two players.

Project containing usage of design patterns in simple game aplication.

## Rules and gameplay

### 1. Board
Board consists of 8 cells (4 columns, 2 rows) A1 - D2, on which players can place their cards. Behind them, there is 9th cell ABCD3, which indicates the cell of player himself.
![image](https://github.com/user-attachments/assets/45576efa-c2e6-42f5-904b-3170308bde47)

### 2. Cards
Every card has 4 statistics:

| Statistic   | Symbol | Description |
| :---------: | :----: | ----------- |
| Attack      | a      | ammount of damage to be done when interracting with card that can take damage or a player |
| Health | h | ammount of damage required to destroy the card |
| Gold | g | ammount of gold that the oponent will receive by destroying the card |
| Type | T | one of 3 types described in table below, defining the behaviour of the card and possible interractions |

| Type  | Symbol | Description |
| :---------: | :----: | ----------- |
| Standard | Sta | card can be used to attack the first target in front of it, if there is no own card blocking the way |
| Flying | Fly | card can be used to attack one of the first 2 targets in front of it |
| Shooter | Sho | card can be used to attack any target in front of it. When attacking, card will only take damage if the target is directly in front of it with no field inbetweet, or if the target is also of type Shooter |

All of the cards are inside of deck - during game they are drawn in random order.

### 3. Tradesman and upgrades
From Tradesman, player can buy upgrade, which can boost their card Health or Attack statistics as well as modify the type of card. Type of card is never downgraded - for example Shooter card with applied Standard upgrade, will still behave as Shooter card. Upgrades can be bought using gold and have to be applied imidiatley on cards on the table.
Tradesman arrives in the second round. From that moment, every turn there is a new upgrade added in the offer. If there is an upgrade that has not been bought for 3 turns, it disappears.

### 4. Objective
The game is won, when oponent's health is reduced to 0. The game can end with draw, when objective hasn't been met and all the cards of both players have got destroyed. Each player starts with 20 health points and 5 gold.

### 5. Gameplay
**5.1.**  The game begins by players choosing their names and desired deck of cards. By default there are 2 decks to choose from with very similar 10 cards inside, of which 2 have type Shooter, 2 have type Flying, and 6 have type Standard.
![image](https://github.com/user-attachments/assets/ee22f93b-8998-45b9-a34a-effb21c369b7)

![image](https://github.com/user-attachments/assets/ee28874a-f981-4107-a96f-df6a178b931a)

**5.2.**  After that, the game begins and the board is displayed together with hand of 4 cards of player 1, from which he must play at least 2 before ending the turn.
![image](https://github.com/user-attachments/assets/889d5515-914c-465e-9570-e8a33f86a9bc)
![image](https://github.com/user-attachments/assets/ad168dbb-b9c0-497d-9915-8f591ef433b2)

**5.3.**  Then player 2 can respond - he also has to play at least 2 cards from his hand.
![image](https://github.com/user-attachments/assets/9ca30990-6861-4380-92ba-c0cc59a72029)
![image](https://github.com/user-attachments/assets/f0bcfde0-95d7-4e8e-af24-6febe525f4fc)

**5.4.**  After initial round is over, players draw one card from deck every next round. Also this is first round when players can buy upgrades from a tradesman and use cards to attack the enemy or destroy his cards.
![image](https://github.com/user-attachments/assets/86f01069-5d41-4aa2-a59a-acb154fa70ec)
- playing card:
![image](https://github.com/user-attachments/assets/240b2d5b-f8c0-4b7b-ade0-85169b8f770e)
- playing another card:
![image](https://github.com/user-attachments/assets/dd75c8c1-8f79-413e-b898-351adf4f175d)
- choosing to buy an upgrade and use it on the card on field A2:
![image](https://github.com/user-attachments/assets/e5debef4-91a5-47b2-9ffb-959927f50aa8)
- attacking:
![image](https://github.com/user-attachments/assets/b5db5903-a60a-4c8e-b52e-8a0170bc6bcc)
![image](https://github.com/user-attachments/assets/d2ee0d2c-d18a-428f-966f-f87bfd3e10af)
![image](https://github.com/user-attachments/assets/f20525b0-f013-4e79-9b34-50e97f7a6c8f)
[...]
![image](https://github.com/user-attachments/assets/70dda019-fec3-411f-b6f6-f341a265267e)

**5.5.**  After player 1 finished attacking, the same actions can be taken by the second player (view is changed so that the opponent is always on top of the screen).
![image](https://github.com/user-attachments/assets/b0435b08-d96e-4273-98bd-00d438e1af19)
![image](https://github.com/user-attachments/assets/fe0ff254-6612-4276-982d-2af4272b36df)
![image](https://github.com/user-attachments/assets/4188b775-3904-4af2-8265-9db14f0cfd3d)
![image](https://github.com/user-attachments/assets/438968f5-9484-4907-8355-e5a0449cd1c0)
![image](https://github.com/user-attachments/assets/7615b09e-5f4a-44fe-896a-12e6d08a5c2c)
[...]

**5.6.** The game continues - in every round, players get one new card in hand, and in every turn tradesman presents a new offer. 
Notice, that every upgrade in offer disappears after 3 turns:
- turn 4
![image](https://github.com/user-attachments/assets/a12ceaa1-2e72-47dd-ad84-e4aa01128f0e)
- turn 5
![image](https://github.com/user-attachments/assets/9bb57d49-24a2-4ce8-b887-b11f93527178)
- turn 6
![image](https://github.com/user-attachments/assets/3ffa9513-1161-493e-83d6-5ffdd9b6a958)

**5.7.**  Winning the game - game continues untill one player manages to reduce health of opponent to 0 - if both players have all their cards destroyed, game ends with draw regardless of players health.
![image](https://github.com/user-attachments/assets/d69e714c-817c-4c45-9d0b-1ff1f9694bd4)














