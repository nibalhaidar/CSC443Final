using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public int SessionCoins { get; private set; } // coins this run
    public int TotalCoins { get; private set; }   // all time coins

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        SessionCoins = 0; // always reset on awake
    }

    public void AddCoins(int amount)
    {
        SessionCoins += amount;
        TotalCoins += amount;
        PlayerPrefs.SetInt("TotalCoins", TotalCoins);
        PlayerPrefs.Save();
    }
}