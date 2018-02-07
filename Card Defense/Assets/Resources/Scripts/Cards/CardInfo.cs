using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo
{
    #region Variables

    public CardType thisCardType;           //The type of card this is
    public int towerCost;                   //the resource cost required to play the card
    public int towerDamage;                 //the damage that the tower does
    public int towerRange;                  //the range of the tower
    public int cardLevel = 1;               //used for upgrading cards
    public string cardText;                 //the name of the card
    public Sprite towerWatermark;           //the image on the card that represents its type
    public Sprite thisTower;                //the sprite the tower this card represents
    public Sprite thisCard;                 //the sprite for this card
    public bool isLocked = false;           //used for deck building
    public bool isSpell = false;            //differenciation between spells and 
    private const float outOfHandDist = 2f; //the distance the card must be dragged in order to be played

    #endregion

    #region Constructor

    //constructor for the class
    public CardInfo(CardType type, int cost, int damage, int range, string text, Sprite watermark, Sprite tower, Sprite card, bool spell)
    {
        thisCardType = type;
        towerCost = cost;
        towerDamage = damage;
        towerRange = range;
        cardText = text;
        towerWatermark = watermark;
        thisTower = tower;
        thisCard = card;
        isSpell = spell;
    }

    #endregion
}
