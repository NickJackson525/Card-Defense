using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Public Methods

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    #endregion
}
