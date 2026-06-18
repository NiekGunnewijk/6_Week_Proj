using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    public GameObject bookPanel;
    public GameObject mapPanel;

    public void ToggleBook()
    {
        bool opening = !bookPanel.activeSelf;

        bookPanel.SetActive(opening);
        mapPanel.SetActive(false);
    }

    public void ToggleMap()
    {
        bool opening = !mapPanel.activeSelf;

        mapPanel.SetActive(opening);
        bookPanel.SetActive(false);
    }
}