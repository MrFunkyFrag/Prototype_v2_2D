using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables used for controlling the game state. 
    public int spawnedItemCount; // Holds the number of spawned items.
    public int spawnedLocationCount; // Holds the number of locations currently on screen. 
    public bool itemsCollected; // Cheks if player is done collecting items, when true allows for destruction of remaining location (the one that player picked) and restarts the the game loop.
    

    public void StateChange(bool itemsState)
    {
        itemsCollected = itemsState;
    }    

}
