using UnityEngine;

public class EnvironmentConfigs : Singleton<EnvironmentConfigs>
{
    [SerializeField] GameConfig _gameConfig;
    [SerializeField] CardsAssetCollection _cardsAssetCollection;

    public GameConfig GameConfig => _gameConfig;
    public CardsAssetCollection CardsAssetCollection => _cardsAssetCollection;

    private void Awake()
    {
        _cardsAssetCollection.Initialize();
    }
}
