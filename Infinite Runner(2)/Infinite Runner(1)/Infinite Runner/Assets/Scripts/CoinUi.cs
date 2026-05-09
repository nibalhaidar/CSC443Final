using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    void Update()
{
    coinText.text = $"Coins {CoinManager.Instance.SessionCoins}";
}
}