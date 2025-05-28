using UnityEngine;

public class EnvironmentConfigs : Singleton<EnvironmentConfigs>
{
    [SerializeField] CardsAssetCollection _cardsAssetCollection;

    public CardsAssetCollection CardsAssetCollection => _cardsAssetCollection;

    private void Awake()
    {
        _cardsAssetCollection.Initialize();
    }
}
