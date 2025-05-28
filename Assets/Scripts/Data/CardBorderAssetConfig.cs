using UnityEngine;

[CreateAssetMenu]
public class CardBorderAssetConfig : ScriptableObject
{
    [SerializeField] CardType _cardType;
    [SerializeField] Sprite _borderImage;

    public CardType CardType => _cardType;
    public Sprite BorderImage => _borderImage;
}