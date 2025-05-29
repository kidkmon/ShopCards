
public class InventoryCardSectionsManager : CardSectionsManager
{
    CardSectionView _commonCardSectionView;
    CardSectionView _rareCardSectionView;
    CardSectionView _epicCardSectionView;

    void Start()
    {
        InventorySystem.Instance.OnInventoryUpdated += AddNewCardToSection;
        SetupSectionType();
    }

    void OnDestroy()
    {
        InventorySystem.Instance.OnInventoryUpdated -= AddNewCardToSection;
    }

    void SetupSectionType()
    {
        foreach (var section in CardSections)
        {
            switch (section.CardType)
            {
                case CardType.Common:
                    _commonCardSectionView = section;
                    break;
                case CardType.Rare:
                    _rareCardSectionView = section;
                    break;
                case CardType.Epic:
                    _epicCardSectionView = section;
                    break;
            }
        }
    }

    void AddNewCardToSection(int cardId)
    {
        var cardConfig = EnvironmentConfigs.Instance.CardsAssetCollection.GetCardConfig(cardId);
        switch (cardConfig.CardType)
        {
            case CardType.Common:
                _commonCardSectionView.OnSectionUpdated?.Invoke(cardConfig);
                break;
            case CardType.Rare:
                _rareCardSectionView.OnSectionUpdated?.Invoke(cardConfig);
                break;
            case CardType.Epic:
                _epicCardSectionView.OnSectionUpdated?.Invoke(cardConfig);
                break;
        }
    }
}