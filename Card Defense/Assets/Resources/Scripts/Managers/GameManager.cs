using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    #region Enums

    public enum CardType
    {
        //Fire card enums
        FireResource, BasicFire, MediumFire, HeavyFire, FireballSpell,

        //Ice card enums
        IceResource, BasicIce, MediumIce, HeavyIce, IceStormSpell,

        //Lightning card enums
        LightningResource, BasicLightning, MediumLightning, HeavyLightning, LightningStrikeSpell,

        //Void card enums
        VoidResource, BasicVoid, MediumVoid, HeavyVoid, VoidPortalSpell,
    }

    #endregion

    public const int deckSize = 20;

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
