using UnityEngine;

public enum CardType
{
    Common,
    Rare,
    Epic,
}

[CreateAssetMenu]
public class CardAssetConfig : ScriptableObject
{
    [SerializeField] int _id;
    [SerializeField] string _name;
    [SerializeField] int _price;
    [SerializeField] CardType _cardType;
    [SerializeField] string _description;
    [SerializeField] Sprite _image;


    public int Id => _id;
    public string Name => _name;
    public int Price => _price;
    public CardType CardType => _cardType;
    public string Description => _description;
    public Sprite Image => _image;
}