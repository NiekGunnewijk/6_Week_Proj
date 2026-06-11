using System.Collections.Generic;
using System.Linq;
using CMGTSA.Inventory;
using UnityEngine;

public class Z_AItemSortingStrategy : ItemSortingStrategy
{
    public override Item[] GetSortedItems(List<Item> items)
    {
        return items.OrderByDescending(i => i.ItemName).ToArray();
    }
}
