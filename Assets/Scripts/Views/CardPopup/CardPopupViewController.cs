
public class CardPopupViewController : ViewController<CardPopupView>
{
    protected override void OnInitialized()
    {
        View.SetupVisual();
        View.SetupButtonsHandlers();
    }

    protected override void SetupEventHandlers() { }

    protected override void RemoveEventHandlers() { }
}
