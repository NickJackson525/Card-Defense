using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Variables

    public GameObject instructionsWindow;
    public GameObject settingsWindow;

    #endregion

    #region Public Methods

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
