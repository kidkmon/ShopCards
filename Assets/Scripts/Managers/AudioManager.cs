using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioClip _insertCoinSound;
    [SerializeField] AudioClip _buyCardSound;
    [SerializeField] AudioClip _clickSound;

    public void PlayInsertCoinSound() => AudioSource.PlayClipAtPoint(_insertCoinSound, Camera.main.transform.position, 0.5f);
    public void PlayBuyCardSound() => AudioSource.PlayClipAtPoint(_buyCardSound, Camera.main.transform.position, 0.5f);
    public void PlayClickSound() => AudioSource.PlayClipAtPoint(_clickSound, Camera.main.transform.position, 0.5f);
}  
