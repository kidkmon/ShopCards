
public class CardSectionViewController : ViewController<CardSectionView>
{
    protected override void OnInitialized()
    {
        UpdateView();
    }

    void UpdateView()
    {
        var cards = EnvironmentConfigs.Instance.CardsAssetCollection.GetCardConfigsByType(View.CardType);

        foreach (var card in cards)
        {
            View.AddCard(card);
        }
    }


    protected override void SetupEventHandlers() { }
    protected override void RemoveEventHandlers() { }

}
