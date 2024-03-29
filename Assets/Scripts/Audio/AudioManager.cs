using UnityEngine;
/// <summary>
///     Music Audio source shoud be attachet to the first child GameObject and
///     SFX Audio source shoud be attachet to the second child GameObject
/// </summary>
public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;//singletone-ish
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);    
        }
        else
            Destroy(gameObject);

    }
    public AudioSource GetMusicAudioSource()
    {
        return transform.GetChild(0).GetComponent<AudioSource>();
    }
    public AudioSource GetSFXAudioSource()
    {
        return transform.GetChild(1).GetComponent<AudioSource>();
    }
    public static void PlaySFX(AudioClip clip, float volume)
    {
        AudioSource source = instance.GetSFXAudioSource();
        source.PlayOneShot(clip, volume);
    }
    public static void PlayMusic(AudioClip clip)
    {
        AudioSource source = instance.GetMusicAudioSource();
        source.clip = clip;
        source.Play();
    }
}