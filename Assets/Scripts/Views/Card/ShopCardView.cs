using TMPro;
using UnityEngine;

public class ShopCardView : CardView
{
    [SerializeField] TextMeshProUGUI _priceText;

    public override void Setup(CardAssetConfig config)
    {
        base.Setup(config);
        _priceText.text = config.Price.ToString();
    }

}
