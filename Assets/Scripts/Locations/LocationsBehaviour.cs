using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _locationsToDestroy = new GameObject[2];
    [SerializeField]
    private Locations _locations;
    [SerializeField]
    private LocationsDatabase _locationsDatabase;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;

    private GameObject _locationNameTxt;
    private GameObject _locationDistanceTxt;


    
    public int distance;

    Camera cam;
    void Awake()
    {
        cam = Camera.main;
        
        // Assigns a random location from location database
        _locations = _locationsDatabase.locations[Random.Range(0,_locationsDatabase.locations.Length)];

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _locations.locationSprite;

        _locationNameTxt = gameObject.transform.GetChild(1).gameObject; // Asigns location name to from database and displays it below the location
        _locationNameTxt.GetComponent<TextMesh>().text = _locations.locationName.ToUpper();

        _locationDistanceTxt = gameObject.transform.GetChild(2).gameObject; // Assigns random distance value to the location
        distance = Random.Range(100, 901);
        _locationDistanceTxt.GetComponent<TextMesh>().text = distance.ToString() + "m";

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Can probably be subsituted with Delgate and Events

    }    

    void Update()
    {
        PlayerLocationChoice();        

        DestroyRemainingLocation();
    }

    /// <summary>
    /// Checks for which location was clicked by the player, destroys the remaining two locations using DestroyNeighbours method
    /// </summary>
    private void PlayerLocationChoice()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "Location")
            {
                hit.collider.GetComponent<LocationsBehaviour>().DestroyNeighbours();
                Destroy(hit.collider);
                _gameManager.spawnedLocationCount = 1;
            }

        }
    }


    /// <summary>
    /// Destroys the two remaining locations that weren't picked by the player.
    /// </summary>
    private void DestroyNeighbours()
    {
        foreach (var location in _locationsToDestroy)
        {
            Destroy(location);
        }
    }

    /// <summary>
    /// Destroys card picked by the player, when all items are collected and game loop restarts (next: new set of 3 locations are spawned).
    /// </summary>
    private void DestroyRemainingLocation()
    {
        if (_gameManager.spawnedItemCount < 1 && _gameManager.spawnedLocationCount == 1 && _gameManager.itemsCollected)
        {
            Destroy(transform.parent.gameObject);
            _gameManager.spawnedLocationCount = 0;
            _gameManager.itemsCollected = false;
        }
    }


}
