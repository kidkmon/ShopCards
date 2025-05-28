using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSectionView : View<CardSectionViewController, CardSectionView>
{
    [Header("Card References")]
    [SerializeField] RectTransform _contentTransform;
    [SerializeField] GameObject _container;
    [SerializeField] GameObject _cardPrefab;

    [Header("Card Settings")]
    [SerializeField] CardType _cardType;
    [SerializeField] bool _canPurchase;

    List<CardAssetConfig> _cardConfigs;
    List<CardView> _cards = new();

    public CardType CardType => _cardType;
    public bool CanPurchase => _canPurchase;
    public List<CardAssetConfig> CardConfigs => _cardConfigs;

    public event Action<CardPopupPayload> OnCardClick;
    public Action<CardAssetConfig> OnSectionUpdated;

    public void Setup(List<CardAssetConfig> cardConfigs)
    {
        _cardConfigs = cardConfigs;
    }

    public void AddCard(CardAssetConfig config)
    {
        var card = Instantiate(_cardPrefab, _container.transform).GetComponent<CardView>();
        card.Setup(config, CanPurchase, OnCardClick, OnPurchase);
        _cards.Add(card);
    }

    void RemoveCard(int id)
    {
        CardView cardToRemove = _cards.Find(card => card.Id == id);

        if (cardToRemove != null)
        {
            _cards.Remove(cardToRemove);
            Destroy(cardToRemove.gameObject);
        }
    }

    public void OnPurchase(int cardId)
    {
        RemoveCard(cardId);
    }

    private void OnEnable()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_contentTransform);
    }
}
