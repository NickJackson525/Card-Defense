using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAudioSourceReference : MonoBehaviour
{
    public AudioSource backgroundSource;
    public AudioSource effectSource;
    public AudioSource UISource;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
        AudioManager.Instance.backroundAudioSource = backgroundSource;
        AudioManager.Instance.effectsAudioSource = effectSource;
        AudioManager.Instance.UIAudioSource = UISource;
    }
}
