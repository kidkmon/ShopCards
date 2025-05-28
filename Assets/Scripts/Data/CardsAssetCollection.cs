using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardsAssetCollection : ScriptableObject
{
    [SerializeField] CardAssetConfig[] CardAssetConfigs;
    [SerializeField] CardBorderAssetConfig[] CardBorderAssetConfigs;

    Dictionary<int, CardAssetConfig> _cardAssetConfigs;
    Dictionary<CardType, CardBorderAssetConfig> _cardBorderAssetConfigs;

    public int Size => CardAssetConfigs.Length;

    public void Initialize()
    {
        InitializeCardAssetConfigs();
        InitializeCardBorderAssetConfigs();
    }

    #region  Card Methods

    void InitializeCardAssetConfigs()
    {
        _cardAssetConfigs = new Dictionary<int, CardAssetConfig>();
        foreach (var config in CardAssetConfigs)
        {
            _cardAssetConfigs.Add(config.Id, config);
        }
    }

    public CardAssetConfig GetCardConfig(int id)
    {
        return _cardAssetConfigs[id];
    }

    public List<CardAssetConfig> GetCardConfigsByType(CardType type)
    {
        List<CardAssetConfig> cards = new();
        foreach (var config in CardAssetConfigs)
        {
            if (config.CardType == type)
            {
                cards.Add(config);
            }
        }

        return cards;
    }

    #endregion

    #region Card Border Methods

    void InitializeCardBorderAssetConfigs()
    {
        _cardBorderAssetConfigs = new Dictionary<CardType, CardBorderAssetConfig>();
        foreach (var config in CardBorderAssetConfigs)
        {
            _cardBorderAssetConfigs.Add(config.CardType, config);
        }
    }

    public CardBorderAssetConfig GetBorderConfig(CardType type)
    {
        return _cardBorderAssetConfigs[type];
    }

    #endregion
}