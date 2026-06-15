using UnityEngine;

public class SelectHouse : MonoBehaviour
{
    [SerializeField] private Collectible resident;
    private void OnEnable()
    {
        CharacterSelector.OnCollectedChar += BuildHouse;
    }
    private void OnDisable()
    {
        CharacterSelector.OnCollectedChar -= BuildHouse;

    }



    private void BuildHouse(Collectible collectible)
    {
        if (collectible.CharData.name == resident.CharData.name)
        {
            Mesh mesh = GetComponent<Mesh>();
            mesh = collectible.CharacterHouse.GetComponent<Mesh>();
        }
    }
}
