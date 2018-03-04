using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

#region Enums

//all the card types available
public enum Cards
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

public enum CardElement { Cost, Damage, Range, Level, CardText, WatermarkSprite, TowerSprite, CardSprite, IsSpell, IsLocked, CardType, HasBeenLookedAt }

public enum DeckType { Basic, Fire, Ice, Lightning, Void, None }

#endregion

class GameManager
{
    #region Variables

    //dictionary of every card in the game and their properties
    public Dictionary<Cards, Dictionary<CardElement, string>> CardLibrary = new Dictionary<Cards, Dictionary<CardElement, string>>
    {
        #region Basic Cards

        {
            #region Basic Resource Card

            Cards.BasicResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "0" },
                { CardElement.CardText, "Basic Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Basic Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "False" },
                { CardElement.CardType, "Basic" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Basic Tower Card

            Cards.Basic, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "0" },
                { CardElement.CardText, "Basic Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Basic Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "False" },
                { CardElement.CardType, "Basic" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Medium Basic Tower Card

            Cards.MediumBasic, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium Basic Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Basic Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Basic" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Heavy Basic Tower Card

            Cards.HeavyBasic, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy Basic Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Basic Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Basic" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },

        #endregion

        #region Fire Cards

        {
            #region Fire Resource Card

            Cards.FireResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Fire Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Basic Fire Tower Card

            Cards.BasicFire, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Fire Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Medium Fire Tower Card

            Cards.MediumFire, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium Fire Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Heavy Fire Tower Card

            Cards.HeavyFire, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy Fire Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Fireball Spell Card

            Cards.FireballSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "4" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Fireball Spell" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Fire Card Back" },
                { CardElement.IsSpell, "True" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },

        #endregion

        #region Ice Cards

        {
            #region Ice Resource Card

            Cards.IceResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Ice Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Basic Ice Tower Card

            Cards.BasicIce, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Ice Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Medium Ice Tower Card

            Cards.MediumIce, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium Ice Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Heavy Ice Tower Card

            Cards.HeavyIce, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy Ice Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Ice Storm Spell Card

            Cards.IceStormSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "4" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Ice Storm Spell" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Ice Card Back" },
                { CardElement.IsSpell, "True" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },

        #endregion

        #region Lightning Cards

        {
            #region Lightning Resource Card

            Cards.LightningResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Lightning Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Lightning" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Basic Lightning Tower Card

            Cards.BasicLightning, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Lightning Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Lightning" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Medium Lightning Tower Card

            Cards.MediumLightning, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium Lightning Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Lightning" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Heavy Lightning Tower Card

            Cards.HeavyLightning, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy Lightning Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.HasBeenLookedAt, "False" },
                { CardElement.CardType, "Lightning" },
            }

            #endregion
        },
        {
            #region Lightning Strike Spell Card

            Cards.LightningStrikeSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "4" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Lightning Storm Spell" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning Card Back" },
                { CardElement.IsSpell, "True" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Lightning" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },

        #endregion

        #region Void Cards

        {
            #region Void Resource Card

            Cards.VoidResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Void Resource" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Void" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Basic Void Tower Card

            Cards.BasicVoid, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic Void Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Void" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Medium Void Tower Card

            Cards.MediumVoid, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium Void Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Void" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Heavy Void Tower Card

            Cards.HeavyVoid, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy Void Tower" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Void" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {
            #region Void Portal Spell Card

            Cards.VoidPortalSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "4" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Void Portal Spell" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Void Card Back" },
                { CardElement.IsSpell, "True" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Void" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },

        #endregion
    };

    public Deck deck = Resources.Load<Deck>("Scripts/Cards/Deck"); //a reference to a deck script
    public List<CardInfo> currentDeck = new List<CardInfo>();      //the current deck
    public DeckType deckType1 = DeckType.None;                     //the first type that the deck is
    public DeckType deckType2 = DeckType.None;                     //the second type that the deck is
    public const int deckSize = 20;                                //the maximum deck size for the game
    public int playerLevel = 0;                                    //the level of the player, used for unlocking cards
    public int baseHealth = 100;
    public const float rangeConst = 2f;                            //the default range of the towers
    public float currentXP = 0;
    public bool newCardsToLookAt = true;
    public CardInfo[] savedDeck = new CardInfo[deckSize];          //a saved copy of the current deck, so it can be reset

    bool isPaused;                                                 //variable to pause the game
    private GameObject UICanvas;                                   //the ui canvas in the game
    private DeckType createdCardType;                              //used for creating cards
    private int generateResourceTimer = 1200;
    private float xpToNextLevel = 500;
    private bool justGeneratedResourceType1 = false;

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
        UnityEngine.Object.DontDestroyOnLoad(new GameObject("Updater", typeof(Updater)));

        //create list of pausable objects
        PauseableObjects = new List<PauseableObject>();
    }

    // Property for Singleton
    public static GameManager Instance
    {
        get { return instance ?? (instance = new GameManager()); }
    }

    #endregion

    #region Update

    private void Update()
    {
        CheckForNewCards();

        #region Check Game Over

        if(baseHealth <= 0)
        {
            //TODO: add code here to open up the game over screen
            ResetVariables();
            SceneManager.LoadScene("Main Menu");
        }

        #endregion

        #region Get UICanvas Reference

        if((UICanvas == null) && (GameObject.FindGameObjectWithTag("InGameUI")))
        {
            UICanvas = GameObject.FindGameObjectWithTag("InGameUI");
        }

        #endregion

        #region Generate Resources

        if ((SceneManager.GetActiveScene().name == "Map 1") && (generateResourceTimer > 0))
        {
            generateResourceTimer--;

            if(generateResourceTimer == 0)
            {
                generateResourceTimer = 1200;

                if (deckType2 != DeckType.None)
                {
                    if (justGeneratedResourceType1)
                    {
                        justGeneratedResourceType1 = false;
                        UICanvas.GetComponent<InGameUIManager>().numManaType2++;
                    }
                    else
                    {
                        justGeneratedResourceType1 = true;
                        UICanvas.GetComponent<InGameUIManager>().numManaType1++;
                    }
                }
                else
                {
                    UICanvas.GetComponent<InGameUIManager>().numManaType1++;
                }
            }
        }

        #endregion

        #region Pause Game

        //testing the pause functionality
        if (Input.GetKeyDown(KeyCode.P))
        {
            Paused = !Paused;
        }

        #endregion

        #region Main Menu

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            ResetVariables();
            SceneManager.LoadScene("Main Menu");
        }

        #endregion

        #region Test Stuff

        //test leveling to unlock cards
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            playerLevel = 1;
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            playerLevel = 2;
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            playerLevel = 3;
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            ResetPlayerData();
        }

        #endregion

        #region Level Up

        if(currentXP >= xpToNextLevel)
        {
            playerLevel++;

            xpToNextLevel *= 2;
        }

        #endregion
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
    public CardInfo CreateCard(Cards cardToMake)
    {
        switch(Instance.CardLibrary[cardToMake][CardElement.CardType])
        {
            case "Basic":
                createdCardType = DeckType.Basic;
                break;
            case "Fire":
                createdCardType = DeckType.Fire;
                break;
            case "Ice":
                createdCardType = DeckType.Ice;
                break;
            case "Lightning":
                createdCardType = DeckType.Lightning;
                break;
            case "Void":
                createdCardType = DeckType.Void;
                break;
            default:
                createdCardType = DeckType.Basic;
                break;
        }

        CardInfo createdCard = new CardInfo(
            cardToMake,
            createdCardType,
            int.Parse(Instance.CardLibrary[cardToMake][CardElement.Cost]),
            int.Parse(Instance.CardLibrary[cardToMake][CardElement.Damage]),
            int.Parse(Instance.CardLibrary[cardToMake][CardElement.Range]),
            int.Parse(Instance.CardLibrary[cardToMake][CardElement.Level]),
            Instance.CardLibrary[cardToMake][CardElement.CardText],
            Resources.Load<Sprite>(Instance.CardLibrary[cardToMake][CardElement.WatermarkSprite]),
            Resources.Load<Sprite>(Instance.CardLibrary[cardToMake][CardElement.TowerSprite]),
            Resources.Load<Sprite>(Instance.CardLibrary[cardToMake][CardElement.CardSprite]),
            bool.Parse(Instance.CardLibrary[cardToMake][CardElement.IsSpell]),
            bool.Parse(Instance.CardLibrary[cardToMake][CardElement.IsLocked]),
            bool.Parse(Instance.CardLibrary[cardToMake][CardElement.HasBeenLookedAt]));

        return createdCard;
    }

    //create the default deck with specified cards
    public void CreateDefaultDeck(Cards resourceType ,Cards type)
    {
        currentDeck.Clear();

        for(int i = 0; i < deckSize / 4; i++)
        {
            currentDeck.Add(CreateCard(resourceType));
        }

        for (int i = 0; i < ((3 * deckSize) / 4); i++)
        {
            currentDeck.Add(CreateCard(type));
        }

        savedDeck = currentDeck.ToArray();
    }

    public void UpdateDeckTypes()
    {
        Instance.deckType1 = DeckType.None;
        Instance.deckType2 = DeckType.None;

        foreach (CardInfo card in Instance.currentDeck)
        {
            if ((Instance.deckType1 == card.cardType) || (Instance.deckType2 == card.cardType))
            {
                //Do nothing
            }
            else if (Instance.deckType1 == DeckType.None)
            {
                Instance.deckType1 = card.cardType;
            }
            else if (Instance.deckType2 == DeckType.None)
            {
                Instance.deckType2 = card.cardType;
            }
        }
    }

    public void CheckForNewCards()
    {
        newCardsToLookAt = false;

        foreach(KeyValuePair<Cards, Dictionary<CardElement, string>> card in CardLibrary)
        {
            if ((playerLevel >= int.Parse(card.Value[CardElement.Level])) && !bool.Parse(card.Value[CardElement.HasBeenLookedAt]))
            {
                newCardsToLookAt = true;
            }
        }
    }

    public void ResetVariables()
    {
        Instance.baseHealth = 100;
        Instance.currentDeck.Clear();

        Instance.currentDeck = new List<CardInfo>(Instance.savedDeck);
    }


    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.OpenOrCreate);

        PlayerData data = new PlayerData(playerLevel, currentXP, currentDeck, deckType1, deckType2);

        formatter.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/PlayerInfo.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(file);

            playerLevel = data.level;
            currentXP = data.experience;
            deckType1 = data.type1;
            deckType2 = data.type2;

            currentDeck.Clear();

            for(int i = 0; i < data.playersDeck.Count; i++)
            {
                currentDeck.Add(CreateCard(data.playersDeck[i]));
            }

            file.Close();
        }
    }

    public void ResetPlayerData()
    {
        playerLevel = 0;
        currentXP = 0;
        CreateDefaultDeck(Cards.BasicResource, Cards.Basic);
        Instance.deckType1 = DeckType.Basic;
        Instance.deckType2 = DeckType.None;

        Instance.Save();
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

#region Player Data Class

[Serializable]
class PlayerData
{
    public int level;
    public float experience;
    public List<Cards> playersDeck = new List<Cards>();
    public DeckType type1;
    public DeckType type2;

    public PlayerData(int playerLevel, float playerExperience, List<CardInfo> deck, DeckType type1, DeckType type2)
    {
        level = playerLevel;
        experience = playerExperience;
        this.type1 = type1;
        this.type2 = type2;

        for(int i = 0; i < deck.Count; i++)
        {
            playersDeck.Add(deck[i].thisCardName);
        }
    }
}

#endregion