using CMGTSA.Inventory;
using UnityEngine;


public class PickUp : MonoBehaviour, IInteractable
{
    public bool testSelected = false;
    private bool _readyToPickUp = false;
    private ItemContainer _itemContainer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _itemContainer = GetComponent<ItemContainer>();

        if (_itemContainer != null)
        {
            MeshFilter itemMesh= GetComponent<MeshFilter>();
            Item item = _itemContainer.GiveItem();
            itemMesh.sharedMesh = item.itemModel.gameObject.GetComponent<MeshFilter>().sharedMesh;
            //itemSprite.sprite = item.itemIcon;
        }
    }
    private void OnEnable()
    {
        //PlayerControler.OnInteract += ItemPickUp;
    }

    private void OnDisable()
    {
        //PlayerControler.OnInteract -= ItemPickUp;
    }

    // Update is called once per frame
    public void ItemPickUp()
    {
        _readyToPickUp = false;
        Destroy(this.gameObject);
        EventBus<PickUpEvent>.Publish(new PickUpEvent(_itemContainer.ItemData));
    }
    
    public void Interact(GameObject gameObject)
    {
        ItemPickUp();
    }
    
    
}
