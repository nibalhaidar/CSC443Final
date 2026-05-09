using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Music")]
    [SerializeField] private AudioClip backgroundMusic;

    [Header("SFX")]
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip gameOverSound;

    private AudioSource _musicSource;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // One AudioSource just for looping music
        _musicSource = gameObject.AddComponent<AudioSource>();
        _musicSource.loop = true;
        _musicSource.clip = backgroundMusic;
    }

    void Start()
    {
        if (backgroundMusic != null)
            _musicSource.Play();
    }

    public void PlayCoin()     => AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
    public void PlayJump()     => AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
    public void PlayGameOver()
    {
        _musicSource.Stop();
        AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position);
    }

    public void PauseMusic()  => _musicSource.Pause();
    public void ResumeMusic() => _musicSource.UnPause();
    public void RestartMusic()
{
    _musicSource.Stop();
    _musicSource.clip = backgroundMusic;
    _musicSource.Play();
}
}