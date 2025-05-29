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
            View.OnSuccessPurchase();
            InventorySystem.Instance.AddInventoryCard(cardId);
            View.OnCloseButton();
            AudioManager.Instance.PlayBuyCardSound();
            ToastMessage.Instance.Show("Purchase successful!");
        }
        else
        {
            Debug.Log("Purchase failed! Not enough coins.");
            View.OnFailedPurchase();
            View.OnCloseButton();
            ToastMessage.Instance.Show("Purchase Failed!\nNot enough coins.\nPress 'SPACE' to insert more coins.");
            // TODO Popup purchase failed
        }
    }
}
