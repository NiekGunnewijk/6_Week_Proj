using UnityEngine;

public class SwapOut : MonoBehaviour, IInteractable
{
    Mesh ToSwapTo;
    void Interact(GameObject gameObject)
    {
        this.gameObject.GetComponent<MeshFilter>().mesh = ToSwapTo;
    }
}