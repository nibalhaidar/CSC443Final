using UnityEngine;
using TMPro;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;

    void Awake()
    {
        startPanel.SetActive(true);
        Time.timeScale = 0f; // freeze everything until play is pressed
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}