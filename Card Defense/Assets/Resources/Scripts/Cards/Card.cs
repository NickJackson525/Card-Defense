using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Card : PauseableObject
{
    #region Variables

    #region Public

    public Cards thisCardName;    //the name of this card
    public string type;           //the type of card this is
    public GameObject tower;      //the tower object that this card will create
    public GameObject cardSlot;   //the card slot that this card is in
    public GameObject deck;       //the deck this card came from
    public Text costText;         //card cost text for this card object
    public Text damageText;       //card damage text for this card object
    public Text rangeText;        //card range text for this card object
    public Text cardNameText;     //card name text for this card object
    public Text cardText;         //text description of the card
    public Image cardWatermark;   //watermark image for this card object
    public Image manaSymbol;      //image to represent mana
    public Image cardBack;        //card back image for this card object
    public int cardLevel = 1;     //used for upgrading cards
    public int numberInDeck = 0;  //used for deck bulding
    public Sprite towerWatermark; //the image on the card that represents its type
    public Sprite thisTower;      //the sprite the tower this card represents
    public bool isLocked = false; //used for deck bulding
    public bool inDeck = false;   //used for deck building
    public bool isSpell = false;  //differenciation between spells and towers
    public bool inHand = true;    //used to see where the card currently is

    #endregion

    #region Private

    private GameObject createdTower;        //the tower object that is created
    private bool mouseHover = false;        //checks when the mouse is over this card or not
    private const float outOfHandDist = 2f; //the distance the card must be dragged in order to be played
    private Vector3 startPosition;          //stores the start position of this card
    private Vector3 mousePosition;          //the position of the mouse
    private Sprite thisCard;

    #endregion

    #endregion

    #region Awake

    //override parent Awake method
    protected override void Awake()
    {
        //call parent method
        base.Awake();

        //get the start position of this card
        startPosition = transform.position;
    }

    #endregion

    #region Start

    private void Start()
    {
        thisCard = Resources.Load<Sprite>(GameManager.Instance.CardLibrary[thisCardName][CardElement.CardSprite]);

        if (GetComponentInChildren<LockImage>())
        {
            GetComponentInChildren<LockImage>().thisCard = gameObject;
        }
    }

    #endregion

    #region Update

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Deck Builder")
        {
            if(isLocked)
            {
                GetComponent<Button>().interactable = false;
            }
            else
            {
                GetComponent<Button>().interactable = true;
            }
        }

        //check that the game isn't paused
        if (!GameManager.Instance.Paused)
        {
            if (SceneManager.GetActiveScene().name != "Deck Builder")
            {
                //check if the mouse is over this card
                if (mouseHover)
                {
                    //check if the left mouse button is being held
                    if (Input.GetMouseButton(0))
                    {
                        //get mouse position and convert it to world space
                        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                        //lerp towards mouse position
                        transform.position = Vector3.Lerp(transform.position, new Vector3(mousePosition.x, mousePosition.y, 0), 1f);
                    }
                }

                //check if the card has been dragged out of the hand
                if (transform.position.y >= (startPosition.y + 5f))
                {
                    inHand = false;                                     //the card isn't in the hand
                    GetComponent<Image>().sprite = thisTower;           //change the sprite to be that of the tower
                    cardWatermark.gameObject.SetActive(false);          //disable the watermark sprite
                    manaSymbol.gameObject.SetActive(false);             //disable the mana sprite
                    costText.gameObject.SetActive(false);               //disable the cost text
                    cardNameText.gameObject.SetActive(false);           //disable the name text
                    cardText.gameObject.SetActive(false);               //disable the card text
                    transform.localScale = new Vector3(.25f, .25f, 1f); //rescale the object
                }
                else
                {
                    inHand = true;                                  //the card isn't in the hand
                    GetComponent<Image>().sprite = thisCard;        //make the current sprite the card
                    cardWatermark.gameObject.SetActive(true);       //enable the watermark sprite
                    manaSymbol.gameObject.SetActive(true);          //enable the mana sprite
                    costText.gameObject.SetActive(true);            //enable the cost text
                    cardNameText.gameObject.SetActive(true);        //enable the name text
                    cardText.gameObject.SetActive(true);            //enable the card text
                    transform.localScale = new Vector3(1f, 1f, 1f); //rescale the object
                }
            }
        }
    }

    #endregion

    #region Private Methods

    #region Mouse Enter

    private void OnMouseEnter()
    {
        //check that the game isn't paused, if the card is in the hand or not, and that the left mouse button isn't being held
        if (!GameManager.Instance.Paused && inHand && !Input.GetMouseButton(0))
        {
            if (SceneManager.GetActiveScene().name != "Deck Builder")
            {
                //move up to indicate the card is currently selected
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 40f, transform.position.z), .1f);
            }

            //the mouse is over the card
            mouseHover = true;
        }
    }

    #endregion

    #region Mouse Exit

    private void OnMouseExit()
    {
        //check that the game isn't paused and that the left mouse button isn't being held down
        if (!GameManager.Instance.Paused && !Input.GetMouseButton(0))
        {
            //jump back to the start position to indicate it is no longer selected
            transform.position = startPosition;

            //change the sprite back to the card
            GetComponent<Image>().sprite = cardBack.sprite;

            //the mouse is no longer over the card
            mouseHover = false;

            //the card is back in the hand
            inHand = true;
        }
    }

    #endregion

    #region Mouse Over

    private void OnMouseOver()
    {
        //checkthat the game isn't paused and if the left mouse button was released
        if (!GameManager.Instance.Paused && Input.GetMouseButtonUp(0))
        {
            if (SceneManager.GetActiveScene().name != "Deck Builder")
            {
                //check that the card isn't in the hand
                if (!inHand)
                {
                    //create tower object
                    createdTower = Instantiate(tower, transform.position, transform.rotation);

                    switch (type)
                    {
                        case "Basic":
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.white;
                            break;
                        case "Fire":
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.red;
                            break;
                        case "Ice":
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.blue;
                            break;
                        case "Lightning":
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.yellow;
                            break;
                        case "Void":
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.magenta;
                            break;
                        default:
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.white;
                            break;
                    }

                    //update deck to draw a new card in the appropriate slot
                    deck.GetComponent<Deck>().nextOpenCardSlot = cardSlot;
                    deck.GetComponent<Deck>().cardsInHand--;
                    deck.GetComponent<Deck>().Draw();

                    //destroy the card
                    Destroy(gameObject);
                }
            }
            else
            {
                //jump back to the start position to indicate it is no longer selected
                transform.position = startPosition;

                //the mouse is no longer over the card
                mouseHover = false;

                //the card is back in the hand
                inHand = true;
            }
        }

        if((SceneManager.GetActiveScene().name == "Deck Builder") && Input.GetMouseButtonUp(0))
        {
            if(inDeck)
            {
                GameManager.Instance.currentDeck.RemoveAt(numberInDeck);
            }
            else if((GameManager.Instance.currentDeck.Count < GameManager.deckSize) && !isLocked)
            {
                GameManager.Instance.currentDeck.Add(GameManager.Instance.CreateCard(thisCardName));
            }
        }
    }

    #endregion

    #endregion
}