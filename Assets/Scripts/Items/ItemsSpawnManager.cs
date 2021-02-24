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

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();       

        
    }

    // Update is called once per frame
    void Update()
    {
        ItemSpawn();
    }


    private void ItemSpawn()
    {
        if (_gameManager.spawnedItemCount == 0 && _gameManager.spawnedLocationCount == 1 && _gameManager.itemsCollected == false)
        {
            _gameManager.spawnedItemCount = 3;
            foreach (var item in itemsToSpawn)
            {
                spawnPos = new Vector3(Random.Range(-3.7f, 3.71f), Random.Range(-1.05f, 1.051f), 0);
                Instantiate(item, spawnPos, Quaternion.identity);                
            }
        }
    }
}
