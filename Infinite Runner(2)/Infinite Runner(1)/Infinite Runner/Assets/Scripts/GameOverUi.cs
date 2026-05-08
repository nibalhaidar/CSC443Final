using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver && !gameOverPanel.activeSelf)
        {
            gameOverPanel.SetActive(true);
            finalScoreText.text = $"Score: {Mathf.FloorToInt(GameManager.Instance.Distance)}m";
            highScoreText.text = $"Best: {Mathf.FloorToInt(GameManager.Instance.HighScore)}m";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}