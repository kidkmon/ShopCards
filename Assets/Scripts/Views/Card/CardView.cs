using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : View<CardViewController, CardView>
{
    [Header("Card Elements")]
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] Image _icon;

    CardAssetConfig _config;

    public virtual void Setup(CardAssetConfig config)
    {
        _config = config;
        _nameText.text = config.Name;
        _icon.sprite = config.Icon;
    }

    public CardAssetConfig GetConfig() => _config;
    public int Id => _config.Id;
}
