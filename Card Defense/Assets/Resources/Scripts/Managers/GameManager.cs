using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    #region Variables

    public Dictionary<CardType, Dictionary<CardElement, string>> CardLibrary = new Dictionary<CardType, Dictionary<CardElement, string>>
    {
        #region Fire Cards

        {
            #region Fire Resource Card

            CardType.FireResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Fire Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/Square" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Basic Fire Tower Card

            CardType.BasicFire, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Fire Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/Square" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Medium Fire Tower Card

            CardType.MediumFire, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Medium Fire Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/Square" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Heavy Fire Tower Card

            CardType.HeavyFire, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Heavy Fire Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/Square" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Fireball Spell Card

            CardType.FireballSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "4" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Fireball Spell" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/Square" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "True" },
            }

            #endregion
        },

        #endregion
    };

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

    public enum CardElement { Cost, Damage, Range, Level, CardText, WatermarkSprite, TowerSprite, CardSprite, IsSpell }

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
