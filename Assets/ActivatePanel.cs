using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject start;

    public void ShowPanel()
    {
        panel.SetActive(true);
        start.SetActive(false);
    }
}
