using UnityEngine;

public class UIToggle : MonoBehaviour
{
    public GameObject targetUI;

    public void ToggleUI()
    {
        targetUI.SetActive(!targetUI.activeSelf);
    }
}
