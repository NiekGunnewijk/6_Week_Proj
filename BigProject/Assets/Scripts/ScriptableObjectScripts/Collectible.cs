using UnityEngine;

[CreateAssetMenu(fileName = "Collectible", menuName = "Scriptable Objects/Collectible")]
public class Collectible : ScriptableObject
{
    public CharacterData CharData;
    public GameObject CharacterObject;
    public GameObject CharacterHouse;
}
