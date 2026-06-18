using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "DiscoverQuest", menuName = "Scriptable Objects/Quests/DiscoverQuest")]
public class DiscoverQuest : Quest
{

    public GameObject DiscoverObject;

    private void OnDisable()
    {
        completed = false;
    }
}
