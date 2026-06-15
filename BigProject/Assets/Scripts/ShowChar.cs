using UnityEngine;

public class ShowChar : MonoBehaviour
{
    [SerializeField] private Camera camera;
    //[SerializeField] private GameObject obj;   

    private void OnEnable()
    {
        CharacterSelector.OnCollectedChar += ShowCharacter;
    }
    private void OnDisable()
    {
        CharacterSelector.OnCollectedChar -= ShowCharacter;
    }



    private void ShowCharacter(Collectible collectible)
    {
        camera.gameObject.SetActive(true);
        Mesh mesh = camera.gameObject.GetComponentInChildren<Mesh>();
        mesh = collectible.CharacterObject.GetComponent<Mesh>();
        Invoke("Stop", 10f);
    }

    private void Stop()
    {
        camera.gameObject.SetActive(false);
    }
}
