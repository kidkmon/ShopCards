using UnityEngine;
using UnityEngine.Events;

public class CoinSystem : Singleton<CoinSystem>
{
    [HideInInspector] public UnityEvent<int> OnCoinUpdated;

    int _coins;
    int _insertedCoins;

    public void Initialize()
    {
        _insertedCoins = EnvironmentConfigs.Instance.GameConfig.InsertedCoins;
        SetCoins(EnvironmentConfigs.Instance.GameConfig.InitialCoins);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Simulate coin insertion
        {
            InsertCoins();
        }
    }

    void InsertCoins()
    {
        AudioManager.Instance.PlayInsertCoinSound();
        AddCoins(_insertedCoins);
    }

    void SetCoins(int value)
    {
        _coins = value;
        OnCoinUpdated?.Invoke(_coins);
    }

    #region Public Methods

    public int Coins => _coins;
    public void AddCoins(int value) => SetCoins(_coins + value);

    public bool TryDeductCoin(int deductValue)
    {
        int newCoinsValue = _coins - deductValue;
        if (newCoinsValue < 0) return false;
        SetCoins(newCoinsValue);
        return true;
    }

    #endregion
}
