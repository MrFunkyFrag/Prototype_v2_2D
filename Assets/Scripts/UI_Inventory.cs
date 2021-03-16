using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{

    [SerializeField] private Inventory _inventory;
    [SerializeField] private ItemsDatabase _itemsDatabase;

    private Transform _itemsContainer;
    private Transform _inventoryItemTemplate;

    private void Start()
    {
        _itemsContainer = transform.Find("ItemsContainer");
        _inventoryItemTemplate = _itemsContainer.Find("InventoryItemTemplate");
        
    }

    private void Inventory_OnItemsListChanged(object sender, System.EventArgs eventArgs)
    {
        throw new System.NotImplementedException();
    }

    public void RefreshInventoryItems()
    {
        foreach (Transform child in _itemsContainer)
        {
            if (child == _inventoryItemTemplate) continue;
            Destroy(child.gameObject);
        }

        float x = 0;
        float y = 0;
        float itemSlotCellSizeX = 80f;
        float itemSlotCellSizeY = -75f;
        foreach (Items item in _inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(_inventoryItemTemplate, _itemsContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                // Use item
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {
                _inventory.RemoveItem(item);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSizeX, y * itemSlotCellSizeY);

            Image image = itemSlotRectTransform.GetComponent<Image>();
            image.sprite = item.itemSprite;

            Text amountTxt = itemSlotRectTransform.Find("Amount_txt").GetComponent<Text>();
            if (item.amount > 1)
            {
                amountTxt.text = item.amount.ToString();
            }
            else
            {
                amountTxt.text = "";
            }
            

            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }

        }
    }


}
