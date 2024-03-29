using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBehaviour : MonoBehaviour
{
    [SerializeField]
    private Items _items;
    [SerializeField]
    private ItemsDatabase _itemsDatabase;
    [SerializeField]
    private Inventory _inventory;

    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;

    private Camera _cam;

    void Start()
    {
        _itemsDatabase = GameObject.Find("ItemsDatabase").GetComponent<ItemsDatabase>();

        _cam = Camera.main; // Asigning in the Start to reduce cost.

       _items = _itemsDatabase.items[Random.Range(0, _itemsDatabase.items.Length)];    // Assigns random items from the ItemsDatabase

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _items.itemSprite;

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // This can certainly be substituted with Events and Delegates
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();        

    }

    // Update is called once per frame
    void Update()
    {
        ItemCollection();
    }



    /// <summary>
    /// Checks for player click on objects tagged "Item". When clicked it destroys them.
    /// </summary>
    private void ItemCollection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(_cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            

            if (hit.collider != null && hit.collider.tag == "Item") // This line causes issue, needs to be more specific about which item is clicked.
            {
                Items clickedItem = hit.collider.gameObject.GetComponent<ItemsBehaviour>()._items;
                _inventory.AddItem(clickedItem);
                if (_inventory.canDestroyItem)
                {
                    Destroy(hit.collider.gameObject);
                    _inventory.canDestroyItem = false;
                    _gameManager.spawnedItemCount--; // Subtracts itemsCreated counter, which is used to control game sequence changes in GameManger.

                    if (_gameManager.spawnedItemCount < 1)
                    {
                        _gameManager.itemsCollected = true; // This needs to be changed to change the bool value via method
                    }
                }
                else if (_inventory.isInventorySpaceFull)
                {
                    Debug.Log("Cannot add item. No space in inventory");
                }
                else if (_inventory.isCarryingCapacityFull)
                {
                    Debug.Log("Cannot add item. Cannot carry more");
                }
                


            }

        }
    }

    public Items GetItem()
    {
        return _items;
    }

}
