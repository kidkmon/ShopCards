
public class GameManager : Singleton<GameManager> {

    void Start()
    {
        CoinSystem.Instance.Initialize();
    }

}
