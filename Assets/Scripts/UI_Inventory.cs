using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private Image[] _itemImages;
    [SerializeField]
    private Text[] _itemAmount;

    private void Awake()
    {

        foreach (Image image in _itemImages)
        {
            image.GetComponent<Image>();
            image.enabled = false;
        }

        foreach (Text text in _itemAmount)
        {
            text.GetComponent<Text>();
        }
        
    }

    /*public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;
    }*/

    public void RefreshInventoryItems()
    {
        for (int i = 0; i < _inventory.GetItemList().Count; i++)
        {
            if (_itemImages[i].sprite != null && _inventory.GetItemList()[i].itemSprite != _itemImages[i].sprite) // Remove image if sprite in list at index i is different from sprite in inventory (to be used upon removing items from the list); NOT TESTED YET
            {
                _itemImages[i].enabled = false;
                _itemImages[i].sprite = null;
                _itemAmount[i].text = "";

                // WIP remove last sprite from inventory
                int x = _inventory.GetItemList().Count;
                _itemImages[x].enabled = false;
                _itemImages[x].sprite = null;
                _itemAmount[x].text = "";
                                
                RefreshInventoryItems();
            }
            else if (_itemImages[i].sprite == null) // prevents substituting image if slot is already taken
            {
                _itemImages[i].enabled = true;
                _itemImages[i].sprite = _inventory.GetItemList()[i].itemSprite;
                _itemAmount[i].text = _inventory.GetItemList()[i].amount.ToString();
               
            }
            else if (_itemImages[i].sprite == _inventory.GetItemList()[i].itemSprite) // if it's the same item - update its amount
            {
                _itemAmount[i].text = _inventory.GetItemList()[i].amount.ToString();
            }
            
        }

    }   

    public void RemoveLastUIItem()
    {
        _itemImages[0].enabled = false;
        _itemImages[0].sprite = null;        
        _itemAmount[0].text = "";
    }

    public Image[] GetItemImageList()
    {
        return _itemImages;
    }




 
}
