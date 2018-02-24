using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region Enums

public enum AudioSourceType { Background, Effects, UI }

#endregion

public class AudioManager
{
    #region Variables

    public Dictionary<Sound, AudioClip> SoundClips = new Dictionary<Sound, AudioClip>
    {
        {Sound.BackgroundMusic1, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic1")},
        {Sound.BackgroundMusic2, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic2")},
        {Sound.BackgroundMusic3, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic3")},
        {Sound.BackgroundMusic4, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic4")},
        {Sound.BackgroundMusic5, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic5")},
    };

    public enum Sound { BackgroundMusic1, BackgroundMusic2, BackgroundMusic3, BackgroundMusic4, BackgroundMusic5, ButtonClick, DeckShuffle, DrawCard, Enemy1, Enemy2, Enemy3 }

    public AudioSource UIAudioSource;
    public AudioSource effectsAudioSource;
    public AudioSource backroundAudioSource;
    private int previousBackgroundTrack = 0;

    #endregion

    #region Singleton Constructor

    // create variable for storing singleton that any script can access
    private static AudioManager instance;

    // create GameManager
    private AudioManager()
    {
        //create internal updater object
        Object.DontDestroyOnLoad(new GameObject("Updater", typeof(Updater)));
    }

    // Property for Singleton
    public static AudioManager Instance
    {
        get { return instance ?? (instance = new AudioManager()); }
    }

    #endregion

    #region Update

    public void Update()
    {
        if (!backroundAudioSource.GetComponent<AudioSource>().isPlaying)
        {
            PlayBackgroundMusic();
        }
    }

    #endregion

    #region Play Sounds

    public void PlaySound(AudioSourceType source, Sound soundToPlay)
    {
        switch (source)
        {
            case AudioSourceType.Background:
                if (backroundAudioSource != null)
                {
                    backroundAudioSource.Stop();
                    backroundAudioSource.PlayOneShot(SoundClips[soundToPlay], 1f);
                }
                break;
            case AudioSourceType.Effects:
                if (effectsAudioSource != null)
                {
                    effectsAudioSource.Stop();
                    effectsAudioSource.PlayOneShot(SoundClips[soundToPlay], 1f);
                }
                break;
            case AudioSourceType.UI:
                if (UIAudioSource != null)
                {
                    UIAudioSource.Stop();
                    UIAudioSource.PlayOneShot(SoundClips[soundToPlay], 1f);
                }
                break;
            default:
                if (effectsAudioSource != null)
                {
                    effectsAudioSource.Stop();
                    effectsAudioSource.PlayOneShot(SoundClips[soundToPlay], 1f);
                }
                break;
        }
    }

    public void PlayBackgroundMusic()
    {
        int rand = Random.Range(0, 5);

        while(rand == previousBackgroundTrack)
        {
            rand = Random.Range(0, 5);
        }

        previousBackgroundTrack = rand;

        switch(rand)
        {
            case 0:
                PlaySound(AudioSourceType.Background, Sound.BackgroundMusic1);
                break;
            case 1:
                PlaySound(AudioSourceType.Background, Sound.BackgroundMusic2);
                break;
            case 2:
                PlaySound(AudioSourceType.Background, Sound.BackgroundMusic3);
                break;
            case 3:
                PlaySound(AudioSourceType.Background, Sound.BackgroundMusic4);
                break;
            case 4:
                PlaySound(AudioSourceType.Background, Sound.BackgroundMusic5);
                break;
            default:
                PlaySound(AudioSourceType.Background, Sound.BackgroundMusic1);
                break;
        }
    }

    #endregion

    #region Internal Updater Class

    //class to allow the gamemanager singleton to have an update method
    class Updater : MonoBehaviour
    {
        private void Update()
        {
            Instance.Update();
        }
    }

    #endregion
}