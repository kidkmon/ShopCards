
public class CardViewController : ViewController<CardView>
{
    private CardAssetConfig _config;

    public void Initialize()
    {
        _config = View.GetConfig();
    }

    protected override void SetupEventHandlers() { }
    protected override void RemoveEventHandlers(){}
}
