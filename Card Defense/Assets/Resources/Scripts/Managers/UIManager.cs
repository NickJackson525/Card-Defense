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
    public GameObject somethingNewIcon;
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
    }

    #endregion

    #region Update

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
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
        else if(SceneManager.GetActiveScene().name == "Deck Builder")
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
        SceneManager.LoadScene(sceneName);
    }

    public void AcceptDeck()
    {
        GameManager.Instance.savedDeck = GameManager.Instance.currentDeck.ToArray();
        GameManager.Instance.Save();
        SceneManager.LoadScene("Main Menu");
    }

    public void RejectDeck()
    {
        GameManager.Instance.currentDeck.Clear();
        GameManager.Instance.currentDeck = new List<CardInfo>(GameManager.Instance.savedDeck);
        SceneManager.LoadScene("Main Menu");
    }

    public void SettingsWindow()
    {
        if(settingsWindow.activeSelf)
        {
            settingsWindow.SetActive(false);
        }
        else
        {
            settingsWindow.SetActive(true);
        }
    }

    public void InstructionsWindow()
    {
        if (instructionsWindow.activeSelf)
        {
            instructionsWindow.SetActive(false);
        }
        else
        {
            instructionsWindow.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    #endregion
}
