using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CMGTSA.Inventory
{
    public class A_ZItemSortingStrategy : ItemSortingStrategy
    {
        public override Item[] GetSortedItems(List<Item> items)
        {
            return items.OrderBy(i => i.ItemName).ToArray();
        }
    }
}