using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instace;
    [SerializeField] private AudioSource audioSource;

    void Awake()
    {
        Instace = this;
    }

    public void PlayMusic(AudioClip music, bool isLoop)
    {
        audioSource.clip = music;
        audioSource.loop = isLoop;
        audioSource.playOnAwake = true;
        audioSource.Play();
    }

    public void PlayOneShot(AudioClip oneShot)
    {
        var volume = audioSource.volume;
        audioSource.PlayOneShot(oneShot, volume);
    }
}
