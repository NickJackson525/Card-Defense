using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables

    public GameObject instructionsWindow;
    public GameObject settingsWindow;
    public GameObject creditsWindow;
    public Image manaImage1;
    public Image manaImage2;

    private Sprite basicImage;
    private Sprite fireImage;
    private Sprite iceImage;
    private Sprite lightningImage;
    private Sprite voidImage;

    #endregion

    #region Start

    private void Start()
    {
        basicImage = Resources.Load<Sprite>("Sprites/Cards/Basic/Basic Symbol");
        fireImage = Resources.Load<Sprite>("Sprites/Cards/Fire/Fire Symbol");
        iceImage = Resources.Load<Sprite>("Sprites/Cards/Ice/Ice Symbol");
        lightningImage = Resources.Load<Sprite>("Sprites/Cards/Lightning/Lightning Symbol");
        voidImage = Resources.Load<Sprite>("Sprites/Cards/Void/Void Symbol");

        if(GameObject.Find("Main Panel"))
        {
            GameObject.Find("Main Panel").GetComponent<Animator>().SetBool("isHidden", false);
        }
    }

    #endregion

    #region Update

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Deck Builder")
        {
            switch (GameManager.Instance.deckType1)
            {
                case DeckType.Basic:
                    manaImage1.sprite = basicImage;
                    manaImage1.gameObject.SetActive(true);
                    break;
                case DeckType.Fire:
                    manaImage1.sprite = fireImage;
                    manaImage1.gameObject.SetActive(true);
                    break;
                case DeckType.Ice:
                    manaImage1.sprite = iceImage;
                    manaImage1.gameObject.SetActive(true);
                    break;
                case DeckType.Lightning:
                    manaImage1.sprite = lightningImage;
                    manaImage1.gameObject.SetActive(true);
                    break;
                case DeckType.Void:
                    manaImage1.sprite = voidImage;
                    manaImage1.gameObject.SetActive(true);
                    break;
                case DeckType.None:
                    manaImage1.gameObject.SetActive(false);
                    break;
                default:
                    manaImage1.sprite = basicImage;
                    manaImage1.gameObject.SetActive(true);
                    break;
            }

            switch (GameManager.Instance.deckType2)
            {
                case DeckType.Basic:
                    manaImage2.sprite = basicImage;
                    manaImage2.gameObject.SetActive(true);
                    break;
                case DeckType.Fire:
                    manaImage2.sprite = fireImage;
                    manaImage2.gameObject.SetActive(true);
                    break;
                case DeckType.Ice:
                    manaImage2.sprite = iceImage;
                    manaImage2.gameObject.SetActive(true);
                    break;
                case DeckType.Lightning:
                    manaImage2.sprite = lightningImage;
                    manaImage2.gameObject.SetActive(true);
                    break;
                case DeckType.Void:
                    manaImage2.sprite = voidImage;
                    manaImage2.gameObject.SetActive(true);
                    break;
                case DeckType.None:
                    manaImage2.gameObject.SetActive(false);
                    break;
                default:
                    manaImage2.sprite = basicImage;
                    manaImage2.gameObject.SetActive(true);
                    break;
            }
        }
    }

    #endregion

    #region Public Methods

    public void LoadScene(string sceneName)
    {
        GameObject.Find("Main Panel").GetComponent<Animator>().SetBool("isHidden", true);
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);

        StartCoroutine(LoadSceneAfterAnim(.6f, sceneName));
    }

    public void AcceptDeck()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);
        GameManager.Instance.savedDeck = GameManager.Instance.currentDeck.ToArray();
        GameManager.Instance.Save();
        SceneManager.LoadScene(GameManager.Instance.previousScene);
    }

    public void RejectDeck()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);
        GameManager.Instance.currentDeck.Clear();
        GameManager.Instance.currentDeck = new List<CardInfo>(GameManager.Instance.savedDeck);
        SceneManager.LoadScene(GameManager.Instance.previousScene);
    }

    public void SettingsWindow()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);

        if (!settingsWindow.GetComponent<Animator>().GetBool("isHidden"))
        {
            settingsWindow.GetComponent<Animator>().SetBool("isHidden", true);
        }
        else
        {
            settingsWindow.GetComponent<Animator>().SetBool("isHidden", false);
        }
    }

    public void InstructionsWindow()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);

        if (!instructionsWindow.GetComponent<Animator>().GetBool("isHidden"))
        {
            instructionsWindow.GetComponent<Animator>().SetBool("isHidden", true);
        }
        else
        {
            instructionsWindow.GetComponent<Animator>().SetBool("isHidden", false);
        }
    }

    public void CreditssWindow()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);

        if (!creditsWindow.GetComponent<Animator>().GetBool("isHidden"))
        {
            creditsWindow.GetComponent<Animator>().SetBool("isHidden", true);
        }
        else
        {
            creditsWindow.GetComponent<Animator>().SetBool("isHidden", false);
        }
    }

    public void Quit()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);
        Application.Quit();
    }

    #endregion

    #region Private Methods

    public IEnumerator LoadSceneAfterAnim(float timeToWait, string sceneToLoad)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(sceneToLoad);
    }

    #endregion
}
