using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _locations;   
    private GameManager _gameManager;

    private Vector3 spawnPos = new Vector3(0, 3.25f, 0);

    
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        LocationSpawn();        
    }

    private void LocationSpawn()
    {
        if (_gameManager.spawnedItemCount == 0 && _gameManager.spawnedLocationCount == 0)
        {
            Instantiate(_locations, spawnPos, Quaternion.identity);
            _gameManager.spawnedLocationCount = 3;
        }
    }
}
