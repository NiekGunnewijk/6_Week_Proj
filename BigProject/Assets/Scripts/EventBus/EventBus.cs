using System;
using CMGTSA.Inventory;

/// <summary>
/// This is a simple implementation of the event bus pattern
/// </summary>
/// <typeparam name="T"></typeparam>
public class EventBus<T> where T: Event
{
    public static event Action<T> OnEvent;

    public static void Publish(T pEvent)
    {
        OnEvent?.Invoke(pEvent);
    }
}

/// <summary>
/// Base class for events, for this simple demonstration it is empty, more fields
/// could be added in real projects, e.g. eventData
/// </summary>
public abstract class Event{}


/// <summary>
/// An event to notify all subscibers that wants to know whenver a Enemy is killed
/// </summary>
public class DialogueEndEvent : Event
{
    
}

public class PickUpEvent : Event
{
    public readonly ItemData Item;

    public PickUpEvent(ItemData pItem)
    {
        Item = pItem;
    }
}
