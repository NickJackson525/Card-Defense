using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    #region Variables

    private Sprite unMuted;
    private Sprite muted;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        unMuted = Resources.Load<Sprite>("Sprites/UI/UnMuted");
        muted = Resources.Load<Sprite>("Sprites/UI/Muted");
    }

    #endregion

    #region Button Methods

    public void MuteMusic(Image muteButton)
    {
        if(AudioManager.Instance.isMusicMuted)
        {
            AudioManager.Instance.isMusicMuted = false;
            muteButton.sprite = unMuted;
        }
        else
        {
            AudioManager.Instance.isMusicMuted = true;
            AudioManager.Instance.MuteSounds(AudioSourceType.Background);
            muteButton.sprite = muted;
        }
    }

    public void MuteSoundEffects(Image muteButton)
    {
        if (AudioManager.Instance.areEffectsMuted)
        {
            AudioManager.Instance.areEffectsMuted = false;
            muteButton.sprite = unMuted;
        }
        else
        {
            AudioManager.Instance.areEffectsMuted = true;
            AudioManager.Instance.MuteSounds(AudioSourceType.Effects);
            muteButton.sprite = muted;
        }
    }

    public void MainMenu()
    {
        GameManager.Instance.ResetVariables();
        SceneManager.LoadScene("Main Menu");
    }

    public void ResumeGame()
    {
        GameManager.Instance.Paused = false;
    }

    #endregion

    #region Private Methods

    private void OnEnable()
    {
        if((unMuted == null) || (muted == null))
        {
            unMuted = Resources.Load<Sprite>("Sprites/UI/UnMuted");
            muted = Resources.Load<Sprite>("Sprites/UI/Muted");
        }

        if(AudioManager.Instance.isMusicMuted)
        {
            GameObject.Find("Music Toggle").GetComponent<Image>().sprite = muted;
        }
        else
        {
            GameObject.Find("Music Toggle").GetComponent<Image>().sprite = unMuted;
        }

        if (AudioManager.Instance.areEffectsMuted)
        {
            GameObject.Find("Effects Toggle").GetComponent<Image>().sprite = muted;
        }
        else
        {
            GameObject.Find("Effects Toggle").GetComponent<Image>().sprite = unMuted;
        }
    }

    #endregion
}
