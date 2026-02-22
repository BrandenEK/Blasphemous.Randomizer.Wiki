---
title: Randomizer Settings
nav_order: 2
---

# Randomizer Settings

<!-- Core -->

### Seed

This determines the seed for the random number generation, setting this to a predetermined number means that every generation will have the exact same item, enemy, and door placement.

### LogicDifficulty

This determines what skips and techniques will be considered 'in logic'.  Harder difficulties will require harder and more obscure techniques.

<table>
  <tr>
    <td align="center"> Easy </td>
    <td>
      <p>- Best for beginner players -</p>
      <ul>
        <li>No skips or glitches will be necessary</li>
        <li>Only the expected method of reaching items will be considered in logic</li>
        <li>Bosses require an extra 10% strength to be in logic</li>
      </ul>
    </td>
  </tr>
  <tr>
    <td align="center"> Normal </td>
    <td>
      <p>- Best for the average player -</p>
      <ul>
        <li>Using dawn heart skips & mid-air stalls may be necessary</li>
        <li>Tiento may be required to access items in poison clouds without Silvered Lung</li>
      </ul>
    </td>
  </tr>
  <tr>
    <td align="center"> Hard </td>
    <td>
      <p>- Best for veteran players -</p>
      <ul>
        <li>Mourning and Havoc skip may be required</li>
        <li>Using enemies to perform skips may be required</li>
        <li>Slash Upwarp skips, Dive Laser skips, and using Tirana to break switches are considered in logic</li>
        <li>Some items in poison clouds are considered in logic without Tiento or Silvered Lung</li>
        <li>Bosses require 10% less strength to be in logic</li>
      </ul>
    </td>
  </tr>
</table>

### StartingLocation

This determines which area of the game you will start in; all rooms besides the Brotherhood have a prie dieu.

---

<!-- General -->

### AllowHints

If enabled, the 34 corpses throughout the game will give vague hints about the location of progression items.  They do not require the 'Shroud of Dreamt Sins' to be interacted with.

### AllowPenitence

If enabled, you will be able to select a penitence from the statue in the Brotherhood of Silent Sorrows.

---

<!-- Item pool -->

### ShuffleReliquaries

If enabled, the 3 reliquary items will be shuffled into the item pool

### ShuffleDash

If enabled, the ability to dash will be removed at first and shuffled into the item pool.  This setting is only available with specific starting locations or full door shuffle.

### ShuffleWallClimb

If enabled, the ability to wall climb will be removed at first and shuffled into the item pool.  This setting is only available with specific starting locations or full door shuffle.

### ShuffleBootsOfPleading

If enabled, the item from the 'Boots of Pleading' mod and its corresponding location will be shuffled into the item and location pools.  This setting is only available if the mod is installed.

### ShufflePurifiedHand

If enabled, the item from the 'Double Jump' mod and its corresponding location will be shuffled into the item and location pools.  This setting is only available if the mod is installed.

### ShuffleSwordSkills

If enabled, the 15 sword skills and their corresponding locations will be shuffled into the item and location pools.

### ShuffleThorns

If enabled, the 8 thorn upgrades and their corresponding locations will be shuffled into the item and location pools.

### JunkLongQuests

If enabled, a non-progression item will be forced at certain inconvenient locations, such as:
- Donate 50000 Tears
- Ossuary reward 11
- Miriam's gift
- Jocinero's final reward

### StartWithWheel

If enabled, the starting gift will always be the 'Young Mason's Wheel' and it will be automatically equipped.

---

<!-- Enemy shuffle -->

### EnemyShuffleType

This determines how the enemies will be placed.

| Disabled | All enemies will remain in their original locations |
| Simple | Enemies will be placed randomly, with each enemy appearing the same number of times as it appeared in the original game |
| Full | Enemies will be placed randomly, with each enemy appearing any number of times |

### MaintainClass

Enemies are constrained to their original group, so flying enemies only replace flying enemies etc.  This setting only takes effect if enemy shuffle is on.

### AreaScaling

Enemy health and damage is scaled up/down based on the area they appear in.  This setting only takes effect if enemy shuffle is on.

---

<!-- Door shuffle -->

### DoorShuffleType

This determines how the doors will be placed.

| Disabled | Room transitions will always lead to their original destinations |
| Simple | Only room transitions that lead to a different region will be shuffled with each other |
| Full | All room transtitions will be shuffled with each other |