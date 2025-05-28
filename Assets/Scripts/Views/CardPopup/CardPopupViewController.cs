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
        View.OnPurchaseButtonClicked += OnPurchase;
    }

    protected override void RemoveEventHandlers()
    { 
        View.OnPurchaseButtonClicked -= OnPurchase;
    }

    public void OnPurchase(int cardId)
    {
        if (CoinSystem.Instance.TryDeductCoin(View.Price))
        {
            Debug.Log($"Purchase successful! Card {cardId}.");
            InventorySystem.Instance.AddInventoryCard(cardId);
            View.OnSuccessPurchase();
        }
        else
        {
            Debug.Log("Purchase failed! Not enough coins.");
            View.OnFailedPurchase();
            // TODO Popup purchase failed
        }

        View.OnCloseButton();
    }
}
