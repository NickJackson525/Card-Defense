using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region Enums

//used to determine which audiosource will be used to play a sound
public enum AudioSourceType { Background, Effects, UI }

//list of sound names as enums
public enum Sound
{
    //background
    BackgroundMusic1, BackgroundMusic2, BackgroundMusic3, BackgroundMusic4, BackgroundMusic5,

    //sound effects
    ButtonClick, DeckShuffle, DrawCard, Enemy1, Enemy2, Enemy3
}

#endregion

public class AudioManager
{
    #region Variables

    //Dictionary that loads all the sounds for the game
    public Dictionary<Sound, AudioClip> SoundClips = new Dictionary<Sound, AudioClip>
    {
        {Sound.BackgroundMusic1, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic1")},
        {Sound.BackgroundMusic2, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic2")},
        {Sound.BackgroundMusic3, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic3")},
        {Sound.BackgroundMusic4, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic4")},
        {Sound.BackgroundMusic5, Resources.Load<AudioClip>("Sounds/Background Music/BackgroundMusic5")},
    };

    //audio sources for ui, effects, and background music
    public AudioSource UIAudioSource;
    public AudioSource effectsAudioSource;
    public AudioSource backroundAudioSource;

    public bool isMusicMuted = false;
    public bool areEffectsMuted = false;

    private int previousBackgroundTrack = 0; //used so that a background tract isn't played 2 times in a row
    private float backgroundVolume = .5f;    //volume level of background music
    private float UIVolume = .5f;            //volume level of ui sounds
    private float effectVolume = .5f;        //volume level of sound effects

    #endregion

    #region Singleton Constructor

    // create variable for storing singleton that any script can access
    private static AudioManager instance;

    // create AudioManager
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
        //check if background music track has ended, if so play another
        if (!backroundAudioSource.GetComponent<AudioSource>().isPlaying && !isMusicMuted)
        {
            PlayBackgroundMusic();
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Plays any sound in the stored dictionary, on the specified audiosource
    /// </summary>
    public void PlaySound(AudioSourceType source, Sound soundToPlay)
    {
        //switch to determine which audiosource to use
        switch (source)
        {
            case AudioSourceType.Background:
                //check that the audiosource exists
                if ((backroundAudioSource != null) && !isMusicMuted)
                {
                    //stop whatever is already playing and play a new sound
                    backroundAudioSource.Stop();
                    backroundAudioSource.PlayOneShot(SoundClips[soundToPlay], backgroundVolume);
                    backroundAudioSource.volume = backgroundVolume;
                }
                break;
            case AudioSourceType.Effects:
                //check that the audiosource exists
                if ((effectsAudioSource != null) && !areEffectsMuted)
                {
                    //stop whatever is already playing and play a new sound
                    effectsAudioSource.Stop();
                    effectsAudioSource.PlayOneShot(SoundClips[soundToPlay], effectVolume);
                    effectsAudioSource.volume = effectVolume;
                }
                break;
            case AudioSourceType.UI:
                //check that the audiosource exists
                if (UIAudioSource != null)
                {
                    //stop whatever is already playing and play a new sound
                    UIAudioSource.Stop();
                    UIAudioSource.PlayOneShot(SoundClips[soundToPlay], UIVolume);
                    UIAudioSource.volume = UIVolume;
                }
                break;
            default:
                //check that the audiosource exists
                if ((effectsAudioSource != null) && !areEffectsMuted)
                {
                    //stop whatever is already playing and play a new sound
                    effectsAudioSource.Stop();
                    effectsAudioSource.PlayOneShot(SoundClips[soundToPlay], effectVolume);
                    effectsAudioSource.volume = effectVolume;
                }
                break;
        }
    }

    /// <summary>
    /// Method to randomly pick a background track to play. It also stops a track from being placed twice in a row.
    /// </summary>
    public void PlayBackgroundMusic()
    {
        int rand = Random.Range(0, 5);

        //loop until a new track number is picked
        while(rand == previousBackgroundTrack)
        {
            rand = Random.Range(0, 5);
        }

        //reset track number
        previousBackgroundTrack = rand;

        //play the selected track
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

    public void MuteSounds(AudioSourceType source)
    {
        switch (source)
        {
            case AudioSourceType.Background:
                backroundAudioSource.Stop();
                break;
            case AudioSourceType.Effects:
                effectsAudioSource.Stop();
                break;
            case AudioSourceType.UI:
                UIAudioSource.Stop();
                break;
            default:
                effectsAudioSource.Stop();
                break;
        }
    }

    #endregion

    #region Internal Updater Class

    //class to allow the audiomanager singleton to have an update method
    class Updater : MonoBehaviour
    {
        private void Update()
        {
            Instance.Update();
        }
    }

    #endregion
}