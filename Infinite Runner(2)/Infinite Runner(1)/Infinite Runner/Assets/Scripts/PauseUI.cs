using UnityEngine;
using TMPro;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI pauseButtonText;

    private bool _isPaused;

    void Awake()
    {
        pausePanel.SetActive(false);
    }

    private void SetPause(bool pause)
    {
        _isPaused = pause;
        pausePanel.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0f : 1f;
        pauseButtonText.text = _isPaused ? "I>" : "||";
    }

    public void TogglePause() => SetPause(!_isPaused);
    public void Resume() => SetPause(false);

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}