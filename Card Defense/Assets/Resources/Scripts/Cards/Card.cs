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
    public DeckType type;         //the type of card this is
    public GameObject tower;      //the tower object that this card will create
    public GameObject cardSlot;   //the card slot that this card is in
    public GameObject deck;       //the deck this card came from
    public GameObject radius;
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

    private GameObject createdTower;         //the tower object that is created
    private GameObject UICanvas;             //the ui canvas in the game
    private bool mouseHover = false;         //checks when the mouse is over this card or not
    private bool hasEnoughResources = false; //bool if the user has enough resources
    private const float outOfHandDist = 2f;  //the distance the card must be dragged in order to be played
    private Vector3 startPosition;           //stores the start position of this card
    private Vector3 mousePosition;           //the position of the mouse
    private Sprite thisCard;                 //the card sprite for this particular card

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

        if(SceneManager.GetActiveScene().name != "Deck Builder")
        {
            UICanvas = GameObject.FindGameObjectWithTag("InGameUI");
        }
    }

    #endregion

    #region Update

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Deck Builder")
        {
            if(GameManager.Instance.playerLevel >= cardLevel)
            {
                GameManager.Instance.CardLibrary[thisCardName][CardElement.IsLocked] = "False";
                isLocked = false;
            }

            if (isLocked)
            {
                GetComponent<Button>().interactable = false;
            }
            else if ((GameManager.Instance.deckType1 == type) || (GameManager.Instance.deckType2 == type) || (GameManager.Instance.deckType1 == DeckType.None) || (GameManager.Instance.deckType2 == DeckType.None))
            {
                GetComponent<Button>().interactable = true;
            }
            else
            {
                GetComponent<Button>().interactable = false;
            }
        }

        //check that the game isn't paused
        if (!GameManager.Instance.Paused)
        {
            if (SceneManager.GetActiveScene().name != "Deck Builder")
            {
                #region Check if player has enough resources

                if((GameManager.Instance.deckType1 == type) && (UICanvas.GetComponent<InGameUIManager>().numManaType1 >= int.Parse(costText.text)))
                {
                    hasEnoughResources = true;
                }
                else if ((GameManager.Instance.deckType2 == type) && (UICanvas.GetComponent<InGameUIManager>().numManaType2 >= int.Parse(costText.text)))
                {
                    hasEnoughResources = true;
                }
                else
                {
                    hasEnoughResources = false;
                }

                #endregion

                if (hasEnoughResources)
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
        if (!GameManager.Instance.Paused && !Input.GetMouseButton(0) || !hasEnoughResources)
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
                    createdTower.GetComponent<Tower>().type = type;
                    createdTower.GetComponent<Tower>().damage = int.Parse(damageText.text);
                    createdTower.GetComponent<Tower>().range = int.Parse(rangeText.text);
                    createdTower.GetComponent<SpriteRenderer>().sprite = thisTower;

                    switch (type)
                    {
                        case DeckType.Basic:
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.white;
                            break;
                        case DeckType.Fire:
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.red;
                            break;
                        case DeckType.Ice:
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.blue;
                            break;
                        case DeckType.Lightning:
                            createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = Color.yellow;
                            break;
                        case DeckType.Void:
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

                    //decrease mana stored
                    if (GameManager.Instance.deckType1 == type)
                    {
                        UICanvas.GetComponent<InGameUIManager>().numManaType1 -= int.Parse(costText.text);
                    }
                    else if (GameManager.Instance.deckType2 == type)
                    {
                        UICanvas.GetComponent<InGameUIManager>().numManaType2 -= int.Parse(costText.text);
                    }

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

        if ((SceneManager.GetActiveScene().name == "Deck Builder") && Input.GetMouseButtonUp(0))
        {
            if (inDeck)
            {
                GameManager.Instance.currentDeck.RemoveAt(numberInDeck);
                GameManager.Instance.UpdateDeckTypes();
            }
            else if ((GameManager.Instance.currentDeck.Count < GameManager.deckSize) && !isLocked)
            {
                if ((GameManager.Instance.deckType1 == type) || (GameManager.Instance.deckType2 == type))
                {
                    GameManager.Instance.currentDeck.Add(GameManager.Instance.CreateCard(thisCardName));
                }
                else if (GameManager.Instance.deckType1 == DeckType.None)
                {
                    GameManager.Instance.currentDeck.Add(GameManager.Instance.CreateCard(thisCardName));
                    GameManager.Instance.deckType1 = type;
                }
                else if (GameManager.Instance.deckType2 == DeckType.None)
                {
                    GameManager.Instance.currentDeck.Add(GameManager.Instance.CreateCard(thisCardName));
                    GameManager.Instance.deckType2 = type;
                }
            }
        }
    }

    #endregion

    #endregion
}