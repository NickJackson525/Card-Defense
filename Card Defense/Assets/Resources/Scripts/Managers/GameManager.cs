﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enums

//all the card types available
public enum CardType
{
    //Basic card enums
    BasicResource, Basic, MediumBasic, HeavyBasic,

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

class GameManager
{
    #region Variables

    //dictionary of every card in the game and their properties
    public Dictionary<CardType, Dictionary<CardElement, string>> CardLibrary = new Dictionary<CardType, Dictionary<CardElement, string>>
    {
        #region Basic Cards

        {
            #region Basic Resource Card

            CardType.BasicResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Basic Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Basic Tower Card

            CardType.Basic, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Basic Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Medium Basic Tower Card

            CardType.MediumBasic, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Medium Basic Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Basic Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Heavy Basic Tower Card

            CardType.HeavyBasic, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Heavy Basic Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Basic Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },

        #endregion

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
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
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
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
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
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
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
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
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
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "True" },
            }

            #endregion
        },

        #endregion

        #region Ice Cards

        {
            #region Ice Resource Card

            CardType.IceResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Ice Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Basic Ice Tower Card

            CardType.BasicIce, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Ice Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Medium Ice Tower Card

            CardType.MediumIce, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Medium Ice Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Heavy Ice Tower Card

            CardType.HeavyIce, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Heavy Ice Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Ice Storm Spell Card

            CardType.IceStormSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "4" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Ice Storm Spell" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "True" },
            }

            #endregion
        },

        #endregion

        #region Lightning Cards

        {
            #region Lightning Resource Card

            CardType.LightningResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Lightning Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Basic Lightning Tower Card

            CardType.BasicLightning, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Lightning Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Medium Lightning Tower Card

            CardType.MediumLightning, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Medium Lightning Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Heavy Lightning Tower Card

            CardType.HeavyLightning, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Heavy Lightning Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Lightning Strike Spell Card

            CardType.LightningStrikeSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "4" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Lightning Storm Spell" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "True" },
            }

            #endregion
        },

        #endregion

        #region Void Cards

        {
            #region Void Resource Card

            CardType.VoidResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Void Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Basic Void Tower Card

            CardType.BasicVoid, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Void Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Medium Void Tower Card

            CardType.MediumVoid, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Medium Void Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Heavy Void Tower Card

            CardType.HeavyVoid, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Heavy Void Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "False" },
            }

            #endregion
        },
        {
            #region Void Portal Spell Card

            CardType.VoidPortalSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "4" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Void Portal Spell" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "True" },
            }

            #endregion
        },

        #endregion
    };

    public Deck deck = Resources.Load<Deck>("Scripts/Cards/Deck"); //a reference to a deck script
    public List<CardInfo> defaultDeck = new List<CardInfo>();      //the default deck at the start of the game
    public const int deckSize = 20;                                //the maximum deck size for the game
    bool isPaused;                                                 //variable to pause the game

    #endregion

    #region Properties

    //pauseable object list to store all objects that need to be paused
    public List<PauseableObject> PauseableObjects
    { get; set; }

    //paused property for objects to see if the game is paused or not
    public bool Paused
    {
        get
        {
            return isPaused;
        }
        set
        {
            //see if the existing and incoming values are the same
            if(value && isPaused)
            {
                return;
            }

            //update isPaused to the new value
            isPaused = value;

            //check if the game is now paused
            if(isPaused)
            {
                //TODO: Pause Audio Manager

                //cycle through each object in th epauseable objects list and pause them
                foreach(PauseableObject pauseObject in PauseableObjects)
                {
                    pauseObject.PauseObject();
                }
            }
            else
            {
                //TODO: Unpause Audio Manager

                //cycle through each object in th epauseable objects list and un-pause them
                foreach (PauseableObject pauseObject in PauseableObjects)
                {
                    pauseObject.UnPauseObject();
                }
            }
        }
    }

    #endregion

    #region Singleton Constructor

    // create variable for storing singleton that any script can access
    private static GameManager instance;

    // create GameManager
    private GameManager()
    {
        //create internal updater object
        Object.DontDestroyOnLoad(new GameObject("Updater", typeof(Updater)));

        //create list of pausable objects
        PauseableObjects = new List<PauseableObject>();
    }

    // Property for Singleton
    public static GameManager Instance
    {
        get { return instance ?? (instance = new GameManager()); }
    }

    #endregion

    #region Public Methods

    //method to add an object to the pauseable objects list
    public void AddPausableObject(PauseableObject pauseObject)
    {
        PauseableObjects.Add(pauseObject);
    }

    //method to remmove an object to the pauseable objects list
    public void RemovePausableObject(PauseableObject pauseObject)
    {
        PauseableObjects.Remove(pauseObject);
    }

    //method to create a card using the values in the CardLibrary dictionary
    public CardInfo CreateCard(CardType cardToMake)
    {
        CardInfo createdCard = new CardInfo(
            cardToMake,
            int.Parse(Instance.CardLibrary[cardToMake][CardElement.Cost]),
            int.Parse(Instance.CardLibrary[cardToMake][CardElement.Damage]),
            int.Parse(Instance.CardLibrary[cardToMake][CardElement.Range]),
            Instance.CardLibrary[cardToMake][CardElement.CardText],
            Resources.Load<Sprite>(Instance.CardLibrary[cardToMake][CardElement.WatermarkSprite]),
            Resources.Load<Sprite>(Instance.CardLibrary[cardToMake][CardElement.TowerSprite]),
            Resources.Load<Sprite>(Instance.CardLibrary[cardToMake][CardElement.CardSprite]),
            bool.Parse(Instance.CardLibrary[cardToMake][CardElement.IsSpell]));

        return createdCard;
    }

    //create the default deck with specified cards
    public void CreateDefaultDeck(CardType type)
    {
        for(int i = 0; i < 20; i++)
        {
            defaultDeck.Add(CreateCard(type));
        }
    }

    #endregion

    #region Update

    private void Update()
    {
        //testing the pause functionality
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
        }
    }

    #endregion

    #region Internal Updater Class

    //class to allow the gamemanager singleton to have an update method
    class Updater: MonoBehaviour
    {
        private void Update()
        {
            Instance.Update();   
        }
    }

    #endregion
}