using System.Collections.Generic;
using System.Linq;

public class CardSectionViewController : ViewController<CardSectionView>
{
    protected override void OnInitialized()
    {
        UpdateView();
    }

    protected override void SetupEventHandlers()
    {
        View.OnSectionUpdated += AddNewCard;
    }
    protected override void RemoveEventHandlers()
    {
        View.OnSectionUpdated -= AddNewCard;
    }
    void UpdateView()
    {
        var availableCards = GetAvailableCards();

        foreach (var card in availableCards)
        {
            View.AddCard(card);
        }
    }

    List<CardAssetConfig> GetAvailableCards()
    {
        if (View.CanPurchase)
        {
            var allCardsByType = EnvironmentConfigs.Instance.CardsAssetCollection.GetCardConfigsByType(View.CardType);
            List<CardAssetConfig> inventoryCards = View.CardConfigs;
            List<CardAssetConfig> availableCards = allCardsByType.Except(inventoryCards).ToList();

            return availableCards;
        }

        return View.CardConfigs;
    }

    void AddNewCard(CardAssetConfig config)
    {
        View.AddCard(config);
    }

}
