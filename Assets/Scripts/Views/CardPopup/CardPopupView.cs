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
    [SerializeField] Button _purchaseButton;
    [SerializeField] Button _closeButton;

    CardAssetConfig _config;
    bool _canPurchase;

    public Action<int> OnPurchaseButtonClicked;
    public event Action<int> OnPurchaseSuccess;
    public event Action OnPurchaseFailed;

    public void Setup(CardPopupPayload payload)
    {
        _config = payload.cardAssetConfig;
        _canPurchase = payload.canPurchase;

        OnPurchaseSuccess += payload.onPurchaseSuccess;

        SetupVisual();
    }

    public void SetupVisual()
    {
        _name.text = _config.Name;
        _description.text = _config.Description;
        _cardImage.sprite = _config.Image;
        _border.sprite = EnvironmentConfigs.Instance.CardsAssetCollection.GetBorderConfig(_config.CardType).BorderImage;

        _priceText.text = _config.Price.ToString();
        _purchaseButton.gameObject.SetActive(_canPurchase);
    }

    public void SetupButtonsHandlers()
    {
        if (_canPurchase) _purchaseButton.onClick.AddListener(OnPurchaseButtonClick);
        _closeButton.onClick.AddListener(OnCloseButton);
    }

    void OnPurchaseButtonClick()
    {
        OnPurchaseButtonClicked?.Invoke(_config.Id);
    }

    public void OnSuccessPurchase()
    {
        OnPurchaseSuccess?.Invoke(_config.Id);
    }

    public void OnFailedPurchase()
    {
        OnPurchaseFailed?.Invoke();
    }

    public void OnCloseButton()
    {
        gameObject.SetActive(false);
    }

    public int Price => _config.Price;
}
