using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSectionView : View<CardSectionViewController, CardSectionView>
{
    [Header("Card References")]
    [SerializeField] RectTransform _contentTransform;
    [SerializeField] GameObject _container;
    [SerializeField] GameObject _cardPrefab;
    [SerializeField] CardType _cardType;

    List<CardView> _cards = new();

    public IReadOnlyList<CardView> Cards => _cards;
    public CardType CardType => _cardType;

    public void AddCard(CardAssetConfig config)
    {
        var card = Instantiate(_cardPrefab, _container.transform).GetComponent<CardView>();
        card.Setup(config);
        _cards.Add(card);
    }

    public void RemoveCard(CardView card)
    {
        if (_cards.Contains(card))
        {
            _cards.Remove(card);
            Destroy(card);
        }
    }

    private void OnEnable()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_contentTransform);
    }
}
