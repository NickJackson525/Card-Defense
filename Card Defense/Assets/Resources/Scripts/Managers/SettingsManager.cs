using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    #region Variables

    public GameObject settingsCanvas;
    public GameObject endGamePopup;
    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject hardButton;
    public GameObject somethingNewIcon;

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

    #region Update

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level Select")
        {
            if (GameManager.Instance.newCardsToLookAt)
            {
                somethingNewIcon.SetActive(true);
            }
            else
            {
                somethingNewIcon.SetActive(false);
            }
        }
    }

    #endregion

    #region Button Methods

    public void MuteMusic(Image muteButton)
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);

        if (AudioManager.Instance.isMusicMuted)
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
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);

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

    public void DeckBuilderButton()
    {
        GameManager.Instance.previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Deck Builder");
    }

    public void LevelSelect()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);
        GameManager.Instance.Paused = false;
        GameManager.Instance.ResetVariables();
        SceneManager.LoadScene("Level Select");
    }

    public void ResumeGame()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);
        GameManager.Instance.Paused = false;
    }

    public void RestartLevel()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);
        GameManager.Instance.ResetVariables();
        GameManager.Instance.Paused = false;
        SceneManager.LoadScene("Map 1");
    }

    public void SettingsPopup()
    {
        if (settingsCanvas.activeSelf)
        {
            settingsCanvas.SetActive(false);

            if(GameManager.Instance.Paused)
            {
                GameManager.Instance.Paused = false;
            }
        }
        else
        {
            settingsCanvas.SetActive(true);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SelectDifficulty(string difficulty)
    {
        if (SceneManager.GetActiveScene().name != "Map 1")
        {
            switch (difficulty)
            {
                case "Easy":
                    easyButton.GetComponentsInChildren<Image>()[1].color = Color.white;
                    mediumButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    hardButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    GameManager.Instance.currenfDifficulty = Difficulty.Easy;
                    break;
                case "Medium":
                    easyButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    mediumButton.GetComponentsInChildren<Image>()[1].color = Color.white;
                    hardButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    GameManager.Instance.currenfDifficulty = Difficulty.Medium;
                    break;
                case "Hard":
                    easyButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    mediumButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    hardButton.GetComponentsInChildren<Image>()[1].color = Color.white;
                    GameManager.Instance.currenfDifficulty = Difficulty.Hard;
                    break;
                default:
                    easyButton.GetComponentsInChildren<Image>()[1].color = Color.white;
                    mediumButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    hardButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    GameManager.Instance.currenfDifficulty = Difficulty.Easy;
                    break;
            }
        }
    }

    #endregion

    #region Private Methods

    private void OnEnable()
    {
        if ((unMuted == null) || (muted == null))
        {
            unMuted = Resources.Load<Sprite>("Sprites/UI/UnMuted");
            muted = Resources.Load<Sprite>("Sprites/UI/Muted");
        }

        if (GameObject.Find("Music Toggle"))
        {
            if (AudioManager.Instance.isMusicMuted)
            {
                GameObject.Find("Music Toggle").GetComponentsInChildren<Image>()[1].sprite = muted;
            }
            else
            {
                GameObject.Find("Music Toggle").GetComponentsInChildren<Image>()[1].sprite = unMuted;
            }
        }

        if (GameObject.Find("Effects Toggle"))
        {
            if (AudioManager.Instance.areEffectsMuted)
            {
                GameObject.Find("Effects Toggle").GetComponentsInChildren<Image>()[1].sprite = muted;
            }
            else
            {
                GameObject.Find("Effects Toggle").GetComponentsInChildren<Image>()[1].sprite = unMuted;
            }
        }

        if (easyButton && mediumButton && hardButton)
        {
            switch (GameManager.Instance.currenfDifficulty)
            {
                case Difficulty.Easy:
                    easyButton.GetComponentsInChildren<Image>()[1].color = Color.white;
                    mediumButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    hardButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    break;
                case Difficulty.Medium:
                    easyButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    mediumButton.GetComponentsInChildren<Image>()[1].color = Color.white;
                    hardButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    break;
                case Difficulty.Hard:
                    easyButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    mediumButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    hardButton.GetComponentsInChildren<Image>()[1].color = Color.white;
                    break;
                default:
                    easyButton.GetComponentsInChildren<Image>()[1].color = Color.white;
                    mediumButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    hardButton.GetComponentsInChildren<Image>()[1].color = new Color(0, 0, 0, .39f);
                    break;
            }
        }
    }

    #endregion
}