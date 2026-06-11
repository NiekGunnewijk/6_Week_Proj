using System;
using CMGTSA.Inventory;
using UnityEngine;

/// <summary>
/// An item container that invoke the onGetItem action to
/// give an item, basicevent bus pattern implemention, which
/// will be introduced in bootcamp 3.
/// </summary>
public class ItemContainer : MonoBehaviour
{
    public static Action<Item> OnGetItem;
    [SerializeField]
    private ItemData itemData;
    public ItemData ItemData => itemData;

    public Item GiveItem()
    {
        Item item = itemData.CreateItem();
        OnGetItem?.Invoke(item);
        return item;
    }

        
}