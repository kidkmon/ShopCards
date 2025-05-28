using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPopupView : View<CardPopupViewController, CardPopupView>
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _description;
    [SerializeField] TextMeshProUGUI _priceText;
    [SerializeField] Image _cardImage;
    [SerializeField] Image _border;
    [SerializeField] Button _buyButton;
    [SerializeField] Button _closeButton;

    CardAssetConfig _config;
    bool _canPurchase;

    public event Action<int> OnPurchaseClicked;

    public void Setup(CardPopupPayload payload)
    {
        _config = payload.cardAssetConfig;
        _canPurchase = payload.canPurchase;
        OnPurchaseClicked += payload.onPurchase;

        SetupVisual();
    }

    public void SetupVisual()
    {
        _name.text = _config.Name;
        _description.text = _config.Description;
        _cardImage.sprite = _config.Image;
        _border.sprite = EnvironmentConfigs.Instance.CardsAssetCollection.GetBorderConfig(_config.CardType).BorderImage;

        _priceText.text = _config.Price.ToString();
        _buyButton.gameObject.SetActive(_canPurchase);
    }

    public void SetupButtonsHandlers()
    {
        if (_canPurchase) _buyButton.onClick.AddListener(OnBuyButtonClick);
        _closeButton.onClick.AddListener(OnCloseButton);
    }

    void OnBuyButtonClick()
    {
        OnPurchaseClicked?.Invoke(_config.Id);
    }

    public void OnCloseButton()
    {
        gameObject.SetActive(false);
    }

    public int Price => _config.Price;
}
