using UnityEngine;

public class AudioManager : Singleton<AudioManager> {
    [SerializeField] AudioClip _insertCoinSound;
    [SerializeField] AudioClip _buyCardSound;

    public void PlayInsertCoinSound() => AudioSource.PlayClipAtPoint(_insertCoinSound, Camera.main.transform.position, 0.5f);
    public void PlayBuyCardSound() => AudioSource.PlayClipAtPoint(_buyCardSound, Camera.main.transform.position, 0.5f);

}  
