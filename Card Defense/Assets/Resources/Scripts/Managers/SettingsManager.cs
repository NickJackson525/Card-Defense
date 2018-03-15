using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private Sprite unMuted;
    private Sprite muted;

	// Use this for initialization
	void Start ()
    {
        unMuted = Resources.Load<Sprite>("Sprites/UI/UnMuted");
        muted = Resources.Load<Sprite>("Sprites/UI/Muted");
    }

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
}
