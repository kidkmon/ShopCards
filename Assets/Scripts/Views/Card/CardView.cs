using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : View<CardViewController, CardView>
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] Image _cardImage;
    [SerializeField] Image _borderImage;
    [SerializeField] Button _cardButton;

    bool _canPurchase;
    CardAssetConfig _config;

    Action<CardPopupPayload> _onCardButtonClicked;
    Action<int> _onPurchase;

    public virtual void Setup(CardAssetConfig config, bool canPurchase, Action<CardPopupPayload> onCardButtonClicked, Action<int> onPurchase = null)
    {
        _config = config;
        _canPurchase = canPurchase;
        _onCardButtonClicked = onCardButtonClicked;
        _onPurchase = onPurchase;

        _nameText.text = config.Name;
        _cardImage.sprite = config.Image;
        _borderImage.sprite = EnvironmentConfigs.Instance.CardsAssetCollection.GetBorderConfig(config.CardType).BorderImage;
        _cardButton.onClick.AddListener(OnCardClick);
    }

    public CardAssetConfig GetConfig() => _config;
    public int Id => _config.Id;
    public void OnCardClick() {
        CardPopupPayload payload = new()
        {
            canPurchase = _canPurchase,
            cardAssetConfig = _config,
            onPurchaseSuccess = _onPurchase,
        };

        _onCardButtonClicked?.Invoke(payload);
    }
}
