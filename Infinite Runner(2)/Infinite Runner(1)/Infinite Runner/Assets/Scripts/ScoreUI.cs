using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject gameOverPanel;

    void Update()
    {
        scoreText.text = $"{Mathf.FloorToInt(GameManager.Instance.Distance)}m";

        if (GameManager.Instance.IsGameOver)
            finalScoreText.text = $"Score: {Mathf.FloorToInt(GameManager.Instance.Distance)}m";
    }
}