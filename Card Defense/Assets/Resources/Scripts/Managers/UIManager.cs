using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Variables

    public GameObject instructionsWindow;
    public GameObject settingsWindow;
    public GameObject somethingNewIcon;

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
