using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _isPlayerChosingLocations;
    public bool _isPlayerCollectingItems;
        
    public int itemsCreated = 3;
    public int locationsLeft;
    public bool destroyLocations;

    public int spawnedItemCount;
    public int spawnedLocationCount;
    public bool itemsCollected;    
    
    public void StateChange(bool itemsState)
    {
        itemsCollected = itemsState;
    }    

}
