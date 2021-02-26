using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemsToSpawn;
    private GameManager _gameManager;

    private Vector3 spawnPos;    


    //private int numberOfItemsToSpawn;
    void Awake()
    {
        /*numberOfItemsToSpawn = Random.Range(1, 4);
        itemsToSpawn = new GameObject[numberOfItemsToSpawn]*/

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();  // This can probably be substituted with Delegates and Events.  

        
    }

    // Update is called once per frame
    void Update()
    {
        ItemSpawn();
    }

    /// <summary>
    /// Method for spawning items. Bool values check if it's the game state at which items are supposed to be spawned. 
    /// </summary>
    private void ItemSpawn()
    {
        if (_gameManager.spawnedItemCount == 0 && _gameManager.spawnedLocationCount == 1 && _gameManager.itemsCollected == false)
        {
            _gameManager.spawnedItemCount = 3; // Sets the value to current number of spawned items (for now the number of spawned items is 3, later it will be random); needs to be changed to use method instead of direct value change.
            foreach (var item in itemsToSpawn) // Each spawned item is spawned in random position within Item Box; future feature - prevent from spawning one item on top of the other
            {
                spawnPos = new Vector3(Random.Range(-3.7f, 3.71f), Random.Range(-1.05f, 1.051f), 0);
                Instantiate(item, spawnPos, Quaternion.identity);                
            }
        }
    }
}
