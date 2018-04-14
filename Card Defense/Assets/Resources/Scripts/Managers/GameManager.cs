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

public enum CardElement { Cost, Damage, Range, Level, CardText, WatermarkSprite, TowerSprite, CardSprite, CardOutlineSprite, CardArtSprite, IsSpell, IsLocked, CardType, HasBeenLookedAt }

public enum DeckType { Basic, Fire, Ice, Lightning, Void, None }

public enum Difficulty { Easy, Medium, Hard }

#endregion

class GameManager
{
    #region Variables

    //dictionary of every card in the game and their properties
    public Dictionary<Cards, Dictionary<CardElement, string>> CardLibrary = new Dictionary<Cards, Dictionary<CardElement, string>>
    {
        #region Basic Cards

        {//TODO: type
            #region Basic Resource Card

            Cards.BasicResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "0" },
                { CardElement.CardText, "Resource tower that generates basic mana" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Basic/Basic Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Basic/Basic Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Basic/Basic Resource Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "False" },
                { CardElement.CardType, "Basic" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Basic Tower Card

            Cards.Basic, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "0" },
                { CardElement.CardText, "Basic tower that shoots arrows" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Basic/Basic Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Basic/Basic Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Basic/Basic Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "False" },
                { CardElement.CardType, "Basic" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Medium Basic Tower Card

            Cards.MediumBasic, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium tower that shoots arrows" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Basic/Basic Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Basic/Basic Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Basic/Medium Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Basic" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Heavy Basic Tower Card

            Cards.HeavyBasic, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy tower that shoots arrows" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Basic/Basic Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Basic/Basic Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Basic/Basic Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Basic/Heavy Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Basic" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },

        #endregion

        #region Fire Cards

        {//TODO: type
            #region Fire Resource Card

            Cards.FireResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Resource tower that generates fire mana" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Fire/Fire Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Fire/Fire Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Fire/Fire Resource Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Basic Fire Tower Card

            Cards.BasicFire, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic tower that shoots fireballs" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Fire/Fire Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Fire/Fire Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Fire/Basic Fire Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Medium Fire Tower Card

            Cards.MediumFire, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium tower that shoots fireballs" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Fire/Fire Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Fire/Fire Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Fire/Medium Fire Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Heavy Fire Tower Card

            Cards.HeavyFire, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy tower that shoots fireballs" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Fire/Fire Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Fire/Fire Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Fire/Heavy Fire Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Fireball Spell Card

            Cards.FireballSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Massive fireball explosion in a radius" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Fire/Fire Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Fire/Fire Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Fire/Fire Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Fire/Fireball Spell Art" },
                { CardElement.IsSpell, "True" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Fire" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },

        #endregion

        #region Ice Cards

        {//TODO: type
            #region Ice Resource Card

            Cards.IceResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Resource tower that generates ice mana" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Ice/Ice Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Ice/Ice Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Ice/Ice Resource Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Basic Ice Tower Card

            Cards.BasicIce, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic tower that shoots icicles" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Ice/Ice Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Ice/Ice Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Ice/Basic Ice Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Medium Ice Tower Card

            Cards.MediumIce, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium tower that shoots icicles" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Ice/Ice Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Ice/Ice Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Ice/Medium Ice Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Heavy Ice Tower Card

            Cards.HeavyIce, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy tower that shoots icicles" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Ice/Ice Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Ice/Ice Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Ice/Heavy Ice Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Ice Storm Spell Card

            Cards.IceStormSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Ice storm that freezes all enemies within the radius" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Ice/Ice Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Ice/Ice Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Ice/Ice Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Ice/Ice Storm Spell Art" },
                { CardElement.IsSpell, "True" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Ice" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },

        #endregion

        #region Lightning Cards

        {//TODO: type
            #region Lightning Resource Card

            Cards.LightningResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Resource tower that generates lightning mana" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning/Lightning Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Lightning/Lightning Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Lightning/Lightning Resource Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Lightning" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Basic Lightning Tower Card

            Cards.BasicLightning, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic tower that shoots lightning" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning/Lightning Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Lightning/Lightning Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Lightning/Basic Lightning Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Lightning" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Medium Lightning Tower Card

            Cards.MediumLightning, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium tower that shoots lightning" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning/Lightning Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Lightning/Lightning Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Lightning/Medium Lightning Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Lightning" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Heavy Lightning Tower Card

            Cards.HeavyLightning, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy tower that shoots lightning" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning/Lightning Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Lightning/Lightning Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Lightning/Heavy Lightning Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.HasBeenLookedAt, "False" },
                { CardElement.CardType, "Lightning" },
            }

            #endregion
        },
        {//TODO: type
            #region Lightning Strike Spell Card

            Cards.LightningStrikeSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Lightning storm that shocks all enemies within range" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Lightning/Lightning Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Lightning/Lightning Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Lightning/Lightning Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Lightning/Lightning Storm Art" },
                { CardElement.IsSpell, "True" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Lightning" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },

        #endregion

        #region Void Cards

        {//TODO: type
            #region Void Resource Card

            Cards.VoidResource, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "0" },
                { CardElement.Damage, "0" },
                { CardElement.Range, "0" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Resource tower that generates void mana" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Void/Void Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Void/Void Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Void/Void Resource Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Void" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Basic Void Tower Card

            Cards.BasicVoid, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "1" },
                { CardElement.Damage, "1" },
                { CardElement.Range, "1" },
                { CardElement.Level, "1" },
                { CardElement.CardText, "Basic tower that can instant kill or teleport enemy" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower2" },
                { CardElement.CardSprite, "Sprites/Cards/Void/Void Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Void/Void Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Void/Basic Void Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Void" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Medium Void Tower Card

            Cards.MediumVoid, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "2" },
                { CardElement.Damage, "2" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Medium tower that can instant kill or teleport enemy" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower3" },
                { CardElement.CardSprite, "Sprites/Cards/Void/Void Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Void/Void Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Void/Medium Void Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Void" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Heavy Void Tower Card

            Cards.HeavyVoid, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "3" },
                { CardElement.Damage, "3" },
                { CardElement.Range, "3" },
                { CardElement.Level, "3" },
                { CardElement.CardText, "Heavy tower that can instant kill or teleport enemy" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower4" },
                { CardElement.CardSprite, "Sprites/Cards/Void/Void Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Void/Void Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Void/Heavy Void Art" },
                { CardElement.IsSpell, "False" },
                { CardElement.IsLocked, "True" },
                { CardElement.CardType, "Void" },
                { CardElement.HasBeenLookedAt, "False" },
            }

            #endregion
        },
        {//TODO: type
            #region Void Portal Spell Card

            Cards.VoidPortalSpell, new Dictionary<CardElement, string>
            {
                { CardElement.Cost, "4" },
                { CardElement.Damage, "4" },
                { CardElement.Range, "2" },
                { CardElement.Level, "2" },
                { CardElement.CardText, "Void Portal that sends all enemies that enter back to the start" },
                { CardElement.WatermarkSprite, "Sprites/Cards/Void/Void Symbol" },
                { CardElement.TowerSprite, "Sprites/Towers/GreyTower1" },
                { CardElement.CardSprite, "Sprites/Cards/Void/Void Card Back" },
                { CardElement.CardOutlineSprite, "Sprites/Cards/Void/Void Card Back Outline" },
                { CardElement.CardArtSprite, "Sprites/Cards/Void/Void Portal Art" },
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
    public GameObject endGamePopup;
    public DeckType deckType1 = DeckType.None;                     //the first type that the deck is
    public DeckType deckType2 = DeckType.None;                     //the second type that the deck is
    public LevelNumber currentLevel = LevelNumber.One;
    public Difficulty currenfDifficulty = Difficulty.Medium;
    public WaveNumber currentWave = WaveNumber.Zero;
    public const int deckSize = 20;                                //the maximum deck size for the game
    public int playerLevel = 0;                                    //the level of the player, used for unlocking cards
    public int baseHealth = 100;
    public const float rangeConst = 2f;                            //the default range of the towers
    public float currentXP = 0;
    public float xpToNextLevel = 500;
    public bool newCardsToLookAt = true;
    public CardInfo[] savedDeck = new CardInfo[deckSize];          //a saved copy of the current deck, so it can be reset
    public string previousScene;

    bool isPaused;                                                 //variable to pause the game
    private GameObject UICanvas;                                   //the ui canvas in the game
    private DeckType createdCardType;                              //used for creating cards
    private int generateResourceTimer = 1200;
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

    #region Start

    private void Start()
    {
        foreach (KeyValuePair<Cards, Dictionary<CardElement, string>> card in GameManager.Instance.CardLibrary)
        {
            if (!bool.Parse(card.Value[CardElement.IsLocked]))
            {
                card.Value[CardElement.HasBeenLookedAt] = "True";
            }
        }
    }

    #endregion

    #region Update

    private void Update()
    {
        CheckForNewCards();

        #region Check Game Over

        if(baseHealth <= 0)
        {
            Paused = true;
            endGamePopup.SetActive(true);
            endGamePopup.GetComponent<EndGamePopup>().xpGainText.text = "0";
            endGamePopup.GetComponent<EndGamePopup>().title.text = "Defeat!";
        }

        #endregion

        #region Get References

        if((UICanvas == null) && (GameObject.FindGameObjectWithTag("InGameUI")))
        {
            UICanvas = GameObject.FindGameObjectWithTag("InGameUI");
        }

        if(!endGamePopup && (SceneManager.GetActiveScene().name == "Map 1"))
        {
            endGamePopup = GameObject.FindGameObjectWithTag("EndGamePopup");
            endGamePopup.SetActive(false);
        }

        #endregion

        #region Generate Resources

        if (!Paused && (SceneManager.GetActiveScene().name == "Map 1") && (generateResourceTimer > 0))
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
        }

        #endregion

        #region Test Stuff

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            UICanvas.GetComponent<InGameUIManager>().numManaType1++;
        }

        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            Save();
            SceneManager.LoadScene("Main Menu");
        }

        //test leveling to unlock cards
        if (Input.GetKeyUp(KeyCode.Alpha1))
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

        if (Input.GetKeyUp(KeyCode.R))
        {
            ResetPlayerData();
        }

        #endregion

        #region Level Up

        if (currentXP >= xpToNextLevel)
        {
            playerLevel++;

            xpToNextLevel *= 2;
            currentXP = 0;
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
            Resources.Load<Sprite>(Instance.CardLibrary[cardToMake][CardElement.CardArtSprite]),
            Resources.Load<Sprite>(Instance.CardLibrary[cardToMake][CardElement.CardSprite]),
            Resources.Load<Sprite>(Instance.CardLibrary[cardToMake][CardElement.CardOutlineSprite]),
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
                card.Value[CardElement.IsLocked] = "False";
                newCardsToLookAt = true;
            }
        }
    }

    public void ResetVariables()
    {
        Paused = false;
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

            savedDeck = currentDeck.ToArray();

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
        private void Start()
        {
            Instance.Start();
        }

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