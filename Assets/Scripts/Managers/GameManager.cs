
public class GameManager : Singleton<GameManager> {

    void Awake()
    {
        CoinSystem.Instance.Initialize();
        InventorySystem.Instance.Initialize();
    }

}
