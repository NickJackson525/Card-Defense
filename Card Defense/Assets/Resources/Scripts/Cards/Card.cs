using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Card : PauseableObject
{
    #region Variables

    #region Public

    public Cards thisCardName;          //the name of this card
    public DeckType type;               //the type of card this is
    public GameObject cardSlot;         //the card slot that this card is in
    public GameObject deck;             //the deck this card came from
    public GameObject radius;
    public GameObject somethingNewIcon;
    public Text costText;               //card cost text for this card object
    public Text damageText;             //card damage text for this card object
    public Text rangeText;              //card range text for this card object
    public Text cardNameText;           //card name text for this card object
    public Text cardText;               //text description of the card
    public Image cardArt;               //card art image for this card object
    public Image cardWatermark;         //watermark image for this card object
    public Image manaSymbol;            //image to represent mana
    public Image cardBack;              //card back image for this card object
    public Image cardBackOutline;       //card back outline image for this card object
    public int cardLevel = 1;           //used for upgrading cards
    public int numberInDeck = 0;        //used for deck bulding
    public Sprite towerWatermark;       //the image on the card that represents its type
    public Sprite thisTower;            //the sprite the tower this card represents
    public bool isLocked = false;       //used for deck bulding
    public bool inDeck = false;         //used for deck building
    public bool isSpell = false;        //differenciation between spells and towers
    public bool hasBeenSeen = true;
    public bool inHand = true;          //used to see where the card currently is
    public BoxCollider2D coll1;
    public BoxCollider2D coll2;
    public CircleCollider2D cirColl1;

    #endregion

    #region Private

    private List<GameObject> enemiesInRange = new List<GameObject>(); //
    private GameObject tower;                                         //the tower object that this card will create
    private GameObject createdTower;                                  //the tower object that is created
    private GameObject CreatedPortal;
    private GameObject UICanvas;                                      //the ui canvas in the game
    private GameObject fireExplosion;
    private GameObject iceExplosion;
    private GameObject lightningBolt;                                 // Used as a template for creating lightning bolts
    private GameObject voidPortal;
    private bool mouseHover = false;                                  //checks when the mouse is over this card or not
    private bool hasEnoughResources = false;                          //bool if the user has enough resources
    private const float outOfHandDist = 2f;                           //the distance the card must be dragged in order to be played
    private int numResourceTowers = 0;
    private Vector3 startPosition;                                    //stores the start position of this card
    private Vector3 mousePosition;                                    //the position of the mouse
    private Sprite thisCard;                                          //the card sprite for this particular card

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

        lightningBolt = Resources.Load<GameObject>("Prefabs/Towers/LightningBolt");
        voidPortal = Resources.Load<GameObject>("Prefabs/Cards/Void Portal");
    }

    #endregion

    #region Start

    private void Start()
    {
        tower = Resources.Load<GameObject>("Prefabs/Towers/Tower");
        fireExplosion = Resources.Load<GameObject>("Prefabs/Cards/Fire Explosion");
        iceExplosion = Resources.Load<GameObject>("Prefabs/Cards/Ice Explosion");
        thisCard = Resources.Load<Sprite>(GameManager.Instance.CardLibrary[thisCardName][CardElement.CardSprite]);

        if (GetComponentInChildren<LockImage>())
        {
            GetComponentInChildren<LockImage>().thisCard = gameObject;
            GetComponentInChildren<LockImage>().gameObject.GetComponent<Image>().enabled = false;
        }

        if (SceneManager.GetActiveScene().name != "Deck Builder")
        {
            UICanvas = GameObject.FindGameObjectWithTag("InGameUI");
        }

        hasBeenSeen = bool.Parse( GameManager.Instance.CardLibrary[thisCardName][CardElement.HasBeenLookedAt]);

        if(inDeck)
        {
            hasBeenSeen = true;
        }
    }

    #endregion

    #region Update

    void Update()
    {
        #region Deck Builder

        if (SceneManager.GetActiveScene().name == "Deck Builder")
        {
            hasBeenSeen = bool.Parse(GameManager.Instance.CardLibrary[thisCardName][CardElement.HasBeenLookedAt]);

            if (!isLocked && !hasBeenSeen)
            {
                somethingNewIcon.SetActive(true);
            }
            else if (hasBeenSeen)
            {
                somethingNewIcon.SetActive(false);
            }

            if (GameManager.Instance.playerLevel >= cardLevel)
            {
                GameManager.Instance.CardLibrary[thisCardName][CardElement.IsLocked] = "False";
                isLocked = false;
            }

            if (isLocked)
            {
                cardArt.color = new Color(.52f, .52f, .52f);
                cardBackOutline.color = new Color(.52f, .52f, .52f);
                GetComponent<Button>().interactable = false;
            }
            else if ((GameManager.Instance.deckType1 == type) || (GameManager.Instance.deckType2 == type) || (GameManager.Instance.deckType1 == DeckType.None) || (GameManager.Instance.deckType2 == DeckType.None))
            {
                GetComponent<Button>().interactable = true;
            }
            else
            {
                cardArt.color = new Color(.52f, .52f, .52f);
                cardBackOutline.color = new Color(.52f, .52f, .52f);
                GetComponent<Button>().interactable = false;
            }

            if(mouseHover && !isLocked)
            {
                cardArt.color = new Color(.52f, .52f, .52f);
                cardBackOutline.color = new Color(.52f, .52f, .52f);
            }
            else if(!mouseHover && !isLocked)
            {
                cardArt.color = Color.white;
                cardBackOutline.color = Color.white;
            }
        }

        #endregion

        //check that the game isn't paused
        if (!GameManager.Instance.Paused && (SceneManager.GetActiveScene().name != "Deck Builder"))
        {
            #region Scale Resource Tower Cost

            if(thisCardName.ToString().Contains("Resource"))
            {
                numResourceTowers = GameObject.FindGameObjectsWithTag(type.ToString() + "Resource").Length;

                foreach(GameObject resourceTower in GameObject.FindGameObjectsWithTag(type.ToString() + "Resource"))
                {
                    if(!resourceTower.GetComponent<Tower>().isPlaced)
                    {
                        numResourceTowers--;
                    }
                }

                costText.text = numResourceTowers.ToString();
            }

            #endregion

            #region Check if player has enough resources

            if ((GameManager.Instance.deckType1 == type) && (UICanvas.GetComponent<InGameUIManager>().numManaType1 >= int.Parse(costText.text)))
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

            #region Card Being Played

            if (hasEnoughResources)
            {
                // Check if the mouse is over this card
                if (mouseHover)
                {
                    // Check if the left mouse button is being held
                    if (Input.GetMouseButton(0))
                    {
                        // Get mouse position and convert it to world space
                        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                        // Lerp towards mouse position
                        transform.position = Vector3.Lerp(transform.position, new Vector3(mousePosition.x, mousePosition.y, 0), 1f);
                    }
                    else if (!Input.GetMouseButton(0) && radius.activeSelf)
                    {
                        //Player used a spell card
                        CastSpell(thisCardName);

                        //decrease mana stored
                        if (GameManager.Instance.deckType1 == type)
                        {
                            UICanvas.GetComponent<InGameUIManager>().numManaType1 -= int.Parse(costText.text);
                        }
                        else if (GameManager.Instance.deckType2 == type)
                        {
                            UICanvas.GetComponent<InGameUIManager>().numManaType2 -= int.Parse(costText.text);
                        }
                    }
                }

                #region Card Leaving Hand

                // Check if the card has been dragged out of the hand
                if (transform.position.y >= (startPosition.y + 5f))
                {
                    // Check if this is a spell or a tower
                    if (!isSpell)
                    {
                        CreateTower();
                        Destroy(gameObject);
                    }
                    else
                    {
                        #region Disable Card Visuals

                        coll1.enabled = false;
                        coll2.enabled = false;
                        cirColl1.enabled = true;
                        radius.transform.localScale = new Vector3(int.Parse(rangeText.text), int.Parse(rangeText.text), int.Parse(rangeText.text));
                        radius.SetActive(true);
                        GetComponent<Image>().enabled = false;
                        costText.enabled = false;
                        manaSymbol.enabled = false;
                        cardNameText.enabled = false;
                        cardText.enabled = false;
                        cardWatermark.enabled = false;
                        cardBackOutline.enabled = false;
                        cardArt.enabled = false;

                        #endregion
                    }
                }
                else
                {
                    #region Re-Enable Card Visuals

                    coll1.enabled = true;
                    coll2.enabled = true;
                    cirColl1.enabled = false;
                    radius.SetActive(false);
                    GetComponent<Image>().enabled = true;
                    costText.enabled = true;
                    manaSymbol.enabled = true;
                    cardNameText.enabled = true;
                    cardText.enabled = true;
                    cardWatermark.enabled = true;
                    cardBackOutline.enabled = true;
                    cardArt.enabled = true;

                    #endregion
                }

                #endregion
            }

            #endregion
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
            else
            {
                if (!isLocked)
                {
                    hasBeenSeen = true;
                    GameManager.Instance.CardLibrary[thisCardName][CardElement.HasBeenLookedAt] = hasBeenSeen.ToString();
                }
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
            if (SceneManager.GetActiveScene().name == "Deck Builder")
            {
                if (inDeck)
                {
                    AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.AddCard);

                    GameManager.Instance.currentDeck.RemoveAt(numberInDeck);
                    GameManager.Instance.UpdateDeckTypes();
                }
                else if ((GameManager.Instance.currentDeck.Count < GameManager.deckSize) && !isLocked)
                {
                    AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.AddCard);

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
    }

    #endregion

    #region Create Tower

    private void CreateTower()
    {
        createdTower = Instantiate(tower, transform.position, transform.rotation);
        createdTower.GetComponent<Tower>().type = type;
        createdTower.GetComponent<Tower>().damage = int.Parse(damageText.text);
        createdTower.GetComponent<Tower>().range = int.Parse(rangeText.text);
        createdTower.GetComponent<Tower>().deck = deck;
        createdTower.GetComponent<Tower>().cardSlot = cardSlot;
        createdTower.GetComponent<Tower>().costText = costText;
        createdTower.GetComponent<Tower>().startPosition = startPosition;
        createdTower.GetComponent<Tower>().thisCardName = thisCardName;
        createdTower.GetComponent<Tower>().currentLevel = cardLevel;
        createdTower.GetComponent<SpriteRenderer>().sprite = thisTower;
        
        switch (type)
        {
            case DeckType.Basic:
                createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = new Color(1, .48f, .117f);
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
                createdTower.GetComponent<Tower>().manaStone.GetComponent<SpriteRenderer>().color = new Color(1, .48f, .117f);
                break;
        }
    }

    #endregion

    #region Cast Spell

    private void CastSpell(Cards spellCardType)
    {
        switch (spellCardType)
        {
            case Cards.FireballSpell:
                Instantiate(fireExplosion, transform.position, transform.rotation);
                break;
            case Cards.IceStormSpell:
                Instantiate(iceExplosion, transform.position, transform.rotation);
                break;
            case Cards.LightningStrikeSpell:
                CreateLightningBolts();
                break;
            case Cards.VoidPortalSpell:
                CreatedPortal = Instantiate(voidPortal, transform.position, transform.rotation);
                CreatedPortal.GetComponent<VoidPortal>().damage = int.Parse(damageText.text);
                break;
            default:
                break;
        }

        for (int i = 0; i < enemiesInRange.Count; i++)
        {
            switch (spellCardType)
            {
                case Cards.FireballSpell:
                    enemiesInRange[i].GetComponent<Enemy>().spellDamageToTake = int.Parse(damageText.text);
                    enemiesInRange[i].GetComponent<Enemy>().spellFireTimer = 120;
                    break;
                case Cards.IceStormSpell:
                    enemiesInRange[i].GetComponent<Enemy>().spellFrozenTimer = 120;
                    break;
                case Cards.LightningStrikeSpell:
                    break;
                case Cards.VoidPortalSpell:
                    break;
                default:
                    break;
            }
        }

        deck.GetComponent<Deck>().nextOpenCardSlot = cardSlot;
        deck.GetComponent<Deck>().cardsInHand--;
        deck.GetComponent<Deck>().Draw();

        Destroy(gameObject);
    }

    #endregion

    #region Creat Lightning Bolts

    public void CreateLightningBolts()
    {
        int boltsToCreate = 10;
        GameObject closestEnemy = FindClosestEnemy();
        GameObject createdObject;

        if (closestEnemy)
        {
            //create lighting bolts
            for (int i = 0; i < boltsToCreate; i++)
            {
                //create lightning bolt and assign values
                createdObject = Instantiate(lightningBolt, new Vector3(transform.position.x, transform.position.y + 1.2f, 0f), transform.rotation);
                createdObject.GetComponent<LightningBolt>().startPosition = new Vector3(transform.position.x, transform.position.y, 0f);
                createdObject.GetComponent<LightningBolt>().endPosition = closestEnemy.transform.position;
            }

            closestEnemy.GetComponent<Enemy>().health -= boltsToCreate * 2;
            closestEnemy.GetComponent<Enemy>().timesChained = 1;
            closestEnemy.GetComponent<Enemy>().lightningLevel = 6;
            closestEnemy.GetComponent<Enemy>().maxLightningBoltsToCreate = boltsToCreate;
            closestEnemy.GetComponent<Enemy>().lightningBolt = lightningBolt;
            closestEnemy.GetComponent<Enemy>().hasBeenHitByLightning = true;
            closestEnemy.GetComponent<Enemy>().lightningTimer = 1;
            closestEnemy.GetComponent<Enemy>().lightningDamage = boltsToCreate / 2;
            closestEnemy.GetComponent<Enemy>().CreateLightningBolts();
        }
    }

    #endregion

    #region Find Closest Enemy

    private GameObject FindClosestEnemy()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        Vector3 position = transform.position;
        Vector3 diff;
        float distance = Mathf.Infinity;
        float curDistance;

        foreach (GameObject enemy in allEnemies)
        {
            if (!enemy.GetComponent<Enemy>().hasBeenHitByLightning && (enemy.transform.position != gameObject.transform.position))
            {
                diff = enemy.transform.position - position;
                curDistance = diff.sqrMagnitude;

                if (curDistance < distance)
                {
                    closest = enemy;
                    distance = curDistance;
                }
            }
        }

        return closest;
    }

    #endregion

    #endregion

    #region Collisions

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(radius.activeSelf && (coll.gameObject.tag == "Enemy"))
        {
            enemiesInRange.Add(coll.gameObject);
        }
    }


    private void OnTriggerExit2D(Collider2D coll)
    {
        if (radius.activeSelf && (coll.gameObject.tag == "Enemy"))
        {
            enemiesInRange.Remove(coll.gameObject);
        }
    }
    #endregion
}