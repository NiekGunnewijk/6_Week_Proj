using System;
using CMGTSA.Inventory;
using UnityEngine;

[CreateAssetMenu(fileName = "FetchQuest", menuName = "Scriptable Objects/Quests/FetchQuest")]
public class FetchQuest : Quest
{
    public int currentValue;
    public int questAmount;
    public ItemData item;

    private void OnDisable()
    {
        currentValue = 0;
        completed = false;
    }
}
