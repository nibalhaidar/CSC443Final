using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI highScoreText;
[SerializeField] private TextMeshProUGUI finalHighScoreText;

    void Update()
    {
        scoreText.text = $"{Mathf.FloorToInt(GameManager.Instance.Distance)}m";
          highScoreText.text = $"Best: {Mathf.FloorToInt(GameManager.Instance.HighScore)}m";


        if (GameManager.Instance.IsGameOver)
    {
        finalScoreText.text = $"Score: {Mathf.FloorToInt(GameManager.Instance.Distance)}m";
        finalHighScoreText.text = $"Best: {Mathf.FloorToInt(GameManager.Instance.HighScore)}m";
    }
    }
}