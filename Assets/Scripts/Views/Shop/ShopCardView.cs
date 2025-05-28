using System;
using TMPro;
using UnityEngine;

public class ShopCardView : CardView
{
    [SerializeField] TextMeshProUGUI _priceText;

    public override void Setup(CardAssetConfig config, bool canPurchase, Action<CardPopupPayload> onCardButtonClicked,  Action<int> onPurchase)
    {
        base.Setup(config, true, onCardButtonClicked, onPurchase);
        _priceText.text = config.Price.ToString();
    }

}
