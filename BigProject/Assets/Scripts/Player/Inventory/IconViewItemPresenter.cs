using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CMGTSA.Inventory
{
    /// <summary>
    /// Todo: finish this class, then replace this header with your own class description.
    /// </summary>
    public class IconViewItemPresenter : ItemPresenter
    {
        public static Action<Item> OnUseItem;
        public Image icon;
        private string _itemInfo;
        private Item _item;

        public override void PresentItem(Item inItem)
        {
            icon.sprite = inItem.itemIcon;
            _item = inItem;
        }

        public void DisplayItemInfo()
        {
            ItemInfoDisplayer.itemInfo = _itemInfo; 
            //todo: display the item info by modifying ItemInfoDisplayer.itemInfo
        }

        public void ClearItemInfo()
        {
            ItemInfoDisplayer.itemInfo = "";
        }
    }
}
