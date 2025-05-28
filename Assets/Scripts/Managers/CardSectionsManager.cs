using System;
using System.Collections.Generic;
using UnityEngine;

public class CardSectionsManager : MonoBehaviour
{
    [Header("Card Popup")]
    [SerializeField] CardPopupView _cardPopup;

    [Header("Card Sections References")]
    [SerializeField] List<CardSectionView> _cardSections;

    List<CardAssetConfig> _cardConfigs;
    Dictionary<CardType, List<CardAssetConfig>> _cardConfigByType;

    public List<CardSectionView> CardSections => _cardSections;

    void Awake()
    {
        InitializeCardConfigs();
        LoadCardConfigs();

        foreach (var section in _cardSections)
        {
            section.Setup(_cardConfigByType[section.CardType]);
            section.OnCardClick += OpenCardPopup;
        }
    }

    void OnDestroy()
    {
        foreach (var section in _cardSections)
        {
            section.OnCardClick -= OpenCardPopup;
        }
    }

    void OpenCardPopup(CardPopupPayload cardPopupPayload)
    {
        _cardPopup.gameObject.SetActive(true);
        _cardPopup.Setup(cardPopupPayload);
    }

    void InitializeCardConfigs()
    {
        _cardConfigs = new();
        _cardConfigByType = new Dictionary<CardType, List<CardAssetConfig>>();

        foreach (CardType type in Enum.GetValues(typeof(CardType)))
        {
            _cardConfigByType[type] = new List<CardAssetConfig>();
        }
    }

    void LoadCardConfigs()
    {
        _cardConfigs = InventorySystem.Instance.LoadInventory();

        foreach (var config in _cardConfigs)
        {
            _cardConfigByType[config.CardType].Add(config);
        }
    }

}
