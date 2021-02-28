using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private GameObject[] _itemImages;

    private Transform _inventoryFrame;
    private Transform _itemSlot1;
    private Image _itemSlot1image;

    private void Start()
    {
        _inventoryFrame = transform.Find("Inventory Frame");
        _itemSlot1 = _inventoryFrame.Find("ItemSlot1_img");
        _itemSlot1image = _itemSlot1.Find("Item_img").GetComponent<Image>();

        if (_inventory == null)
        {
            Debug.Log("No inventory");
        }
        else
        {
            Debug.Log(_inventory.gameObject.name);
        }

        RefreshInventoryItems();
    }

    /*public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;
    }*/

    private void RefreshInventoryItems()
    {
        foreach (Items item in _inventory.GetItemList())
        {
            if (_itemSlot1image.sprite == null) // prevents substituting image if slot is already taken
            {
                _itemSlot1image.sprite = item.itemSprite;
            }
            
        }
    }
 
}
