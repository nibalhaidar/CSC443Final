using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameConfig config;

    public float HighScore { get; private set; }
    public float ScrollSpeed { get; private set; }
    public float Distance { get; private set; }
    public bool IsGameOver { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        ScrollSpeed = config.startSpeed;
        HighScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    void Update()
    {
        if (IsGameOver) return;

        ScrollSpeed = Mathf.Min(ScrollSpeed + config.speedIncreaseRate * Time.deltaTime, config.maxSpeed);
        Distance += ScrollSpeed * Time.deltaTime;

    // Distance-based speed tiers
    if (Distance >= 800f)
        ScrollSpeed = Mathf.MoveTowards(ScrollSpeed, 24f, 2f * Time.deltaTime);
    else if (Distance >= 400f)
        ScrollSpeed = Mathf.MoveTowards(ScrollSpeed, 18f, 2f * Time.deltaTime);
    else if (Distance >= 200f)
        ScrollSpeed = Mathf.MoveTowards(ScrollSpeed, 14f, 2f * Time.deltaTime);
    else
        ScrollSpeed = Mathf.MoveTowards(ScrollSpeed, 10f, 2f * Time.deltaTime);
    }

    public void TriggerGameOver()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        ScrollSpeed = 0f;
        AudioManager.Instance.PlayGameOver(); // this stops music AND plays game over sound

        if (Distance > HighScore)
        {
            HighScore = Distance;
            PlayerPrefs.SetFloat("HighScore", HighScore);
            PlayerPrefs.Save();
        }
    }
}