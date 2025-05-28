
using System;

public class CardPopupPayload
{
    public CardAssetConfig cardAssetConfig;
    public bool canPurchase;
    public Action<int> onPurchaseSuccess;
    public Action onPurchaseFailed;
}