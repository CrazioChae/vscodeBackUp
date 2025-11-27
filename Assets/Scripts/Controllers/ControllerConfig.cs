using UnityEngine;

public class ControllerConfig : MonoBehaviour
{
    public GameObject configContentPanel;
    public GameObject blockerPanel;

    void Start()
    {
        configContentPanel.SetActive(false);
        blockerPanel.SetActive(false);
    }

    public void OpenConfigPanel()
    {
        configContentPanel.SetActive(true);
        blockerPanel.SetActive(true);
    }
    public void CloseConfigPanel()
    {
        configContentPanel.SetActive(false);
        blockerPanel.SetActive(false);
    }
}