using System;
using System.Collections.Generic;

public class InventorySystem : Singleton<InventorySystem>
{
    const string kInventoryCards = "PlayerInventoryCards";

    public event Action<int> OnInventoryUpdated;

    List<CardAssetConfig> _inventoryCards;

    public void Initialize()
    {
        _inventoryCards = new();
        //ResetInventory();
    }

    #region Public Methods

    public void AddInventoryCard(int cardId)
    {
        PlayerPrefsHelper.AddIntList(kInventoryCards, cardId);
        OnInventoryUpdated?.Invoke(cardId);
    }

    public List<CardAssetConfig> LoadInventory()
    {
        _inventoryCards = new();
        List<int> inventoryCardIds = PlayerPrefsHelper.LoadIntList(kInventoryCards);
        CardAssetConfig config = null;

        foreach (var cardId in inventoryCardIds)
        {
            config = EnvironmentConfigs.Instance.CardsAssetCollection.GetCardConfigById(cardId);
            if (config != null)
                _inventoryCards.Add(config);
        }

        return _inventoryCards;
    }


    public void ResetInventory()
    {
        PlayerPrefsHelper.DeleteIntList(kInventoryCards);
    }

    #endregion
}
