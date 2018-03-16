using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAudioSourceReference : MonoBehaviour
{
    #region Variables

    public AudioSource backgroundSource;
    public AudioSource effectSource;
    public AudioSource UISource;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        if(GameObject.FindGameObjectsWithTag("AudioSource").Length == 1)
        {
            DontDestroyOnLoad(this);
            AudioManager.Instance.backroundAudioSource = backgroundSource;
            AudioManager.Instance.effectsAudioSource = effectSource;
            AudioManager.Instance.UIAudioSource = UISource;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
