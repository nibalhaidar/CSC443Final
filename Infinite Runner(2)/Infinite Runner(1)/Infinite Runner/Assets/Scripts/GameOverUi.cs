using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver && !gameOverPanel.activeSelf)
            gameOverPanel.SetActive(true);

       // if (GameManager.Instance.IsGameOver && Input.GetKeyDown(KeyCode.R))
          //  Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}