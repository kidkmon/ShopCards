using UnityEngine;

public class CardPopupViewController : ViewController<CardPopupView>
{
    protected override void OnInitialized()
    {
        View.SetupVisual();
        View.SetupButtonsHandlers();
    }

    protected override void SetupEventHandlers()
    {
        View.OnPurchaseClicked += OnPurchase;
    }

    protected override void RemoveEventHandlers()
    { 
        View.OnPurchaseClicked -= OnPurchase;
    }

    public void OnPurchase(int cardId)
    {
        if (CoinSystem.Instance.TryDeductCoin(View.Price))
        {
            Debug.Log($"Purchase successful! Card {cardId}.");
            InventorySystem.Instance.AddInventoryCard(cardId);
        }
        else
        {
            Debug.Log("Purchase failed! Not enough coins.");
            // TODO Popup purchase failed
        }

        View.OnCloseButton();
    }
}
