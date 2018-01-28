using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    #region Variables

    public GameManager.CardType thisCardType; //The type of card this is
    public GameObject tower;
    public Text costText;                     //card cost text for this card object
    public Text damageText;                   //card damage text for this card object
    public Text rangeText;                    //card range text for this card object
    public Text cardNameText;                 //card name text for this card object
    public Image cardWatermark;               //watermark image for this card object
    public Image cardBack;                    //card back image for this card object
    public int cardLevel = 1;                 //used for upgrading cards
    public Sprite towerWatermark;             //the image on the card that represents its type
    public Sprite thisTower;                  //the sprite the tower this card represents
    public Sprite thisCard;                   //the sprite for this card
    public bool isSpell = false;              //differenciation between spells and towers
    public bool inHand = true;                //used to see where the card currently is
    bool mouseHover = false;
    private const float outOfHandDist = 2f;   //the distance the card must be dragged in order to be played
    private Vector3 startPosition;            //stores the start position of this card

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
        if (mouseHover)
        {
            //check if the left mouse button is being held
            if (Input.GetMouseButton(0))
            {
                //the card is being played, so it will follow the mouse
                inHand = false;
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, 0), 1f);
            }
            else
            {
                //the card isn't being played
                inHand = true;
            }
        }

        //check if the card has been dragged out of the hand
        if (transform.position.y >= (startPosition.y + 2f))
        {
            //if it has then change the sprite to be that of the tower
            GetComponent<Image>().sprite = thisTower;

            cardWatermark.gameObject.SetActive(false);
            costText.gameObject.SetActive(false);
            damageText.gameObject.SetActive(false);
            rangeText.gameObject.SetActive(false);
            cardNameText.gameObject.SetActive(false);
            transform.localScale = new Vector3(.25f, .25f, 1f);
        }
        else
        {
            //if it hasn't then make the sprite the card
            GetComponent<Image>().sprite = thisCard;

            cardWatermark.gameObject.SetActive(true);
            costText.gameObject.SetActive(true);
            damageText.gameObject.SetActive(true);
            rangeText.gameObject.SetActive(true);
            cardNameText.gameObject.SetActive(true);
            transform.localScale = new Vector3(1f, 1f, 1f);
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
        if (!Input.GetMouseButton(0))
        {
            //jump back to the start position to indicate it is no longer selected
            transform.position = startPosition;
            GetComponent<Image>().sprite = thisCard;
        }
    }

    #endregion

    #region Mouse Over

    private void OnMouseOver()
    {
        mouseHover = true;

        //check if the left mouse button was released, meaning the card was either played or put back in the hand
        if (Input.GetMouseButtonUp(0))
        {
            //check if the card is back in the hand or not
            if (GetComponent<Image>().sprite == thisCard)
            {
                //return the card to the hand
                transform.position = startPosition;

                cardWatermark.gameObject.SetActive(true);
                costText.gameObject.SetActive(true);
                damageText.gameObject.SetActive(true);
                rangeText.gameObject.SetActive(true);
                cardNameText.gameObject.SetActive(true);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                //play card
                Instantiate(tower, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    #endregion

    #endregion
}
