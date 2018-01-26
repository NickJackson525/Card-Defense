using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    #region Variables

    public GameManager.CardType thisCardType; //The type of card this is
    public int towerCost;                     //the resource cost required to play the card
    public int towerDamage;                   //the damage that the tower does
    public int towerRange;                    //the range of the tower
    public string cardText;                   //the name of the card
    public Sprite towerWatermark;             //the image on the card that represents its type
    public Sprite thisTower;                  //the sprite the tower this card represents
    public Sprite thisCard;                          //the sprite for this card
    public bool inHand = true;                //used to see where the card currently is
    public bool isSpell = false;              //differenciation between spells and towers
    Vector3 startPosition;                    //stores the start position of this card
    const float outOfHandDist = 2f;           //the distance the card must be dragged in order to be played

    #endregion

    #region Constructor

    public Card(GameManager.CardType type, int cost, int damage, int range, string text, Sprite watermark, Sprite tower, Sprite card, bool spell)
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

    #region Start

    // Use this for initialization
    void Start()
    {
        //get the start position
        startPosition = transform.position;
        thisCard = GetComponent<Image>().sprite;
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update()
    {
        //check if the card has been dragged out of the hand
        if (transform.position.y >= (startPosition.y + 2f))
        {
            //if it has then change the sprite to be that of the tower
            GetComponent<Image>().sprite = thisTower;
        }
        else
        {
            //if it hasn't then make the sprite the card
            GetComponent<Image>().sprite = thisCard;
        }
    }

    #endregion

    #region Private Methods

    #region Mouse Enter

    private void OnMouseEnter()
    {
        //see if the card is in the hand or not
        if (inHand)
        {
            //if the card is in the hand, move up to indicate it is currently selected
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), .1f);
        }
    }

    #endregion

    #region Mouse Exit

    private void OnMouseExit()
    {
        //jump back to the start position to indicate it is no longer selected
        transform.position = startPosition;
        GetComponent<Image>().sprite = thisCard;
    }

    #endregion

    #region Mouse Over

    private void OnMouseOver()
    {
        //check if the left mouse button is being held
        if (Input.GetMouseButton(0))
        {
            //the card is being played, so it will follow the mouse
            inHand = false;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        else
        {
            //the card isn't being played
            inHand = true;
        }

        //check if the left mouse button was released, meaning the card was either played or put back in the hand
        if (Input.GetMouseButtonUp(0))
        {
            //check if the card is back in the hand or not
            if (GetComponent<Image>().sprite == thisCard)
            {
                //return the card to the hand
                transform.position = startPosition;
            }
            else
            {
                //play card
            }
        }
    }

    #endregion

    #endregion
}
