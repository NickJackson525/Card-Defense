using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    #endregion

    #region Singleton

    // create variable for storing singleton that any script can access
    private static GameManager instance;

    // create GameManager
    private GameManager()
    {

    }

    // Property for Singleton
    public static GameManager Instance
    {
        get
        {
            // If the singleton does not exist
            if (instance == null)
            {
                // create and return it
                instance = new GameManager();
            }

            // otherwise, just return it
            return instance;
        }
    }

    #endregion

    #region Public Methods

    #endregion
}
