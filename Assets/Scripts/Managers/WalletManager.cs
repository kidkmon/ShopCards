using TMPro;
using UnityEngine;

public class WalletManager : Singleton<WalletManager>
{
    [Header("Coin UI")]
    [SerializeField] TextMeshProUGUI _coinsText;

     void OnEnable() {  
        CoinSystem.Instance.OnCoinUpdated.AddListener(UpdateCoinsUI);
    }

    void OnDisable() {
        CoinSystem.Instance.OnCoinUpdated.RemoveListener(UpdateCoinsUI);
    }

    void UpdateCoinsUI(int coins) => _coinsText.text = coins.ToString();
}
