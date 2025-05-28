using UnityEngine;

[CreateAssetMenu]  
public class GameConfig : ScriptableObject {  

    [Header("Wallet Settings")]
    [SerializeField] int _initialCoins = 100;
    [SerializeField] int _insertedCoins = 100;
    
    public int InitialCoins => _initialCoins;
    public int InsertedCoins => _insertedCoins;
}  