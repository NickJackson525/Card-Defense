﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    #region Variables

    #region Public

    public GameObject manaStone;  // Used so that the color can be changed upon creation of this tower to match the type
    public GameObject collRadius; // Used to show the player the range of this tower
    public GameObject deck;
    public GameObject cardSlot;
    public Text costText;
    public Vector3 startPosition; // Used to see if the tower is being put back in the hand or not
    public Cards thisCardName;
    public DeckType type;         // Used to create the right type of bullet or mana
    public int currentLevel = 1;  // Used to scale everything when the tower levels up
    public int damage = 1;        // Used to assign the damage to the bullet when created
    public float range = 1;       // Used to scale the range collider and collRadius gameobject
    public bool isPlaced = false; // Used to move the tower around before it gets placed down

    #endregion

    #region Private

    private enum TargetPriority { First, Last, Close, Strong }   // The list of target priorities this tower can have
    private TargetPriority thisPriority = TargetPriority.First;  // Used to determine which enemy within range to shoot at
    private GameObject currentTarget;                            // Used to track the closest enemy
    private GameObject bullet;                                   // Used as a template for creating bullets
    private GameObject lightningBolt;                            // Used as a template for creating lightning bolts
    private GameObject createdObject;                            // Used to modify the values of the created object. Either a bullet or lightning bolt
    private GameObject UICanvas;                                 // Used to increment mana levels
    private GameObject cardPrefab;
    private GameObject tower;                                    //the tower object that this card will create
    private GameObject towerToUpgrade;
    private Vector3 mousePosition;
    private bool canShoot = true;                                // Used to control when this tower can shoot
    private bool canBePlaced = true;                             // Used to limit where the tower cna be placed at
    private bool canPlaceUpdrage = false;
    private int shootTimer = 0;                                  // Used to control the time between each shot of this tower
    private int manaGenerationTimer = 800;                       // Used to control the time between each mana generatrion of this tower
    private int rand;
    private List<GameObject> enemyList = new List<GameObject>(); // Used to store all the enemies within range

    #endregion

    #endregion

    #region Start

    void Start()
    {
        //get references
        cardPrefab = Resources.Load<GameObject>("Prefabs/Cards/Card");
        bullet = Resources.Load<GameObject>("Prefabs/Towers/Bullet");
        lightningBolt = Resources.Load<GameObject>("Prefabs/Towers/LightningBolt");
        tower = Resources.Load<GameObject>("Prefabs/Towers/Tower");
        UICanvas = GameObject.FindGameObjectWithTag("InGameUI");

        //scale range
        //range = range * GameManager.rangeConst;
        GetComponent<CircleCollider2D>().radius *= range;
        collRadius.transform.localScale *= range;
    }

    #endregion

    #region Update

    void Update()
    {
        //check that the game isn't paused
        if (!GameManager.Instance.Paused)
        {
            if (isPlaced)
            {
                //if damage and range are 0 then this is a resource tower
                if ((damage == 0) && (range == 0))
                {
                    //check that the timer still is counting down
                    if (manaGenerationTimer > 0)
                    {
                        //update the timer
                        manaGenerationTimer--;

                        //check if the timer is at 0
                        if (manaGenerationTimer == 0)
                        {
                            //determine which type this tower is and update the appropriate mana type
                            if (GameManager.Instance.deckType1 == type)
                            {
                                UICanvas.GetComponent<InGameUIManager>().numManaType1++;
                            }
                            else if (GameManager.Instance.deckType2 == type)
                            {
                                UICanvas.GetComponent<InGameUIManager>().numManaType2++;
                            }

                            //reset timer
                            manaGenerationTimer = 800;
                        }
                    }
                }
                else
                {
                    //find the closest enemy
                    currentTarget = FindClosestEnemy();

                    //update shoot timer
                    shootTimer--;

                    //check if the shoot timer is 0, meaning the tower can shoot again
                    if (shootTimer <= 0)
                    {
                        canShoot = true;
                    }

                    #region Shoot

                    //check if the tower can shoot and if there are enemi
                    if (canShoot && (enemyList.Count > 0))
                    {
                        //select the current target
                        currentTarget = enemyList[0];

                        //reset the canshoot variable and reset the timer
                        canShoot = false;
                        shootTimer = 60;

                        //check if this tower is lighting type
                        if (type == DeckType.Lightning)
                        {
                            rand = Random.Range(4, 8);

                            //create lighting bolts
                            for (int i = 0; i < rand; i++)
                            {
                                //create lightning bolt and assign values
                                createdObject = Instantiate(lightningBolt, new Vector3(transform.position.x, transform.position.y + 1.2f, 0f), transform.rotation);
                                createdObject.GetComponent<LightningBolt>().startPosition = new Vector3(transform.position.x, transform.position.y + 1.2f, 0f);
                                createdObject.GetComponent<LightningBolt>().endPosition = currentTarget.transform.position;
                            }

                            currentTarget.GetComponent<Enemy>().health -= (rand * (damage * currentLevel)) / 2;
                        }
                        else
                        {
                            //create bullet and assign values
                            createdObject = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1.2f, 0f), transform.rotation);
                            createdObject.GetComponent<Bullet>().move = true;
                            createdObject.GetComponent<Bullet>().target = currentTarget;
                            createdObject.GetComponent<Bullet>().damage = damage * currentLevel;
                            createdObject.GetComponent<Bullet>().type = type;

                            #region Color Bullet

                            //color the bullet based on the type of tower
                            switch (type)
                            {
                                case DeckType.Basic:
                                    createdObject.GetComponent<SpriteRenderer>().color = Color.white;
                                    break;
                                case DeckType.Fire:
                                    createdObject.GetComponent<SpriteRenderer>().color = Color.red;
                                    break;
                                case DeckType.Ice:
                                    createdObject.GetComponent<SpriteRenderer>().color = Color.blue;
                                    break;
                                case DeckType.Lightning:
                                    createdObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                                    break;
                                case DeckType.Void:
                                    createdObject.GetComponent<SpriteRenderer>().color = Color.magenta;
                                    break;
                                default:
                                    createdObject.GetComponent<SpriteRenderer>().color = Color.black;
                                    break;
                            }

                            #endregion
                        }
                    }

                    #endregion
                }
            }
            else
            {
                //check if the card has been dragged out of the hand
                if (transform.position.y >= (startPosition.y + 5f))
                {
                    //check if the left mouse button is being held
                    if (Input.GetMouseButton(0))
                    {
                        //get mouse position and convert it to world space
                        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                        //lerp towards mouse position
                        transform.position = Vector3.Lerp(transform.position, new Vector3(mousePosition.x, mousePosition.y, 0), 1f);
                    }

                    if (Input.GetMouseButtonUp(0) && canBePlaced && !canPlaceUpdrage)
                    {
                        isPlaced = true;

                        //deactivate the radius object
                        collRadius.SetActive(false);

                        //lock the tower in place
                        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

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
                    }
                    else if(Input.GetMouseButtonUp(0) && canPlaceUpdrage)
                    {
                        if (((GameManager.Instance.deckType1 == type) && (UICanvas.GetComponent<InGameUIManager>().numManaType1 >= 2 * int.Parse(costText.text))) 
                            || ((GameManager.Instance.deckType2 == type) && (UICanvas.GetComponent<InGameUIManager>().numManaType2 >= 2 * int.Parse(costText.text))))
                        {
                            CreateTower(towerToUpgrade);

                            //update deck to draw a new card in the appropriate slot
                            deck.GetComponent<Deck>().nextOpenCardSlot = cardSlot;
                            deck.GetComponent<Deck>().cardsInHand--;
                            deck.GetComponent<Deck>().Draw();

                            //decrease mana stored
                            if (GameManager.Instance.deckType1 == type)
                            {
                                UICanvas.GetComponent<InGameUIManager>().numManaType1 -= 2 * int.Parse(costText.text);
                            }
                            else if (GameManager.Instance.deckType2 == type)
                            {
                                UICanvas.GetComponent<InGameUIManager>().numManaType2 -= 2 * int.Parse(costText.text);
                            }

                            Destroy(towerToUpgrade);
                            Destroy(gameObject);
                        }
                        else
                        {
                            CreateCard();
                            Destroy(gameObject);
                        }
                    }
                    else if (Input.GetMouseButtonUp(0) && !canBePlaced && !canPlaceUpdrage)
                    {
                        CreateCard();
                        Destroy(gameObject);
                    }
                }
                else
                {
                    CreateCard();
                    Destroy(gameObject);
                }
            }
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// This method finds the closest enemy to the tower and returns a reference to it
    /// </summary>
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
            diff = enemy.transform.position - position;
            curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }

        return closest;
    }

    /// <summary>
    /// This method sorts the enemies that are within range according to how far along the path they are.
    /// </summary>
    private void SortEnemyList()
    {
        enemyList.Sort((p1, p2) => p1.GetComponent<Enemy>().distFromEnd.CompareTo(p2.GetComponent<Enemy>().distFromEnd));
    }

    private void CreateCard()
    {
        GameObject createdCard;
        CardInfo card = GameManager.Instance.CreateCard(thisCardName);

        createdCard = Instantiate(cardPrefab, Vector3.zero, cardSlot.transform.rotation, cardSlot.transform);
        createdCard.GetComponent<Image>().sprite = card.thisCard;
        createdCard.GetComponent<Card>().thisCardName = card.thisCardName;
        createdCard.GetComponent<Card>().costText.text = costText.text;
        createdCard.GetComponent<Card>().damageText.text = card.towerDamage.ToString();
        createdCard.GetComponent<Card>().rangeText.text = card.towerRange.ToString();
        createdCard.GetComponent<Card>().cardNameText.text = card.cardType.ToString();
        createdCard.GetComponent<Card>().cardText.text = card.cardText;
        createdCard.GetComponent<Card>().cardWatermark.sprite = card.towerWatermark;
        createdCard.GetComponent<Card>().cardBack.sprite = card.thisCard;
        createdCard.GetComponent<Card>().cardLevel = card.cardLevel;
        createdCard.GetComponent<Card>().thisTower = card.thisTower;
        createdCard.GetComponent<Card>().isSpell = card.isSpell;
        createdCard.GetComponent<Card>().cardSlot = cardSlot;
        createdCard.GetComponent<Card>().deck = deck;
        createdCard.GetComponent<Card>().type = card.cardType;
    }

    #region Create Tower

    private void CreateTower(GameObject origionalTower)
    {
        GameObject createdTower = Instantiate(tower, origionalTower.transform.position, origionalTower.transform.rotation);

        if (thisCardName.ToString().Contains("Heavy") || thisCardName.ToString().Contains("Resource"))
        {
            createdTower.GetComponent<Tower>().thisCardName = thisCardName;
            createdTower.GetComponent<Tower>().type = type;
            createdTower.GetComponent<Tower>().deck = deck;
            createdTower.GetComponent<Tower>().cardSlot = cardSlot;
            createdTower.GetComponent<Tower>().costText = costText;
            createdTower.GetComponent<Tower>().startPosition = startPosition;
            createdTower.GetComponent<Tower>().isPlaced = true;
            createdTower.GetComponent<Tower>().damage++;
            createdTower.GetComponent<Tower>().range++;
            createdTower.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            createdTower.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            createdTower.GetComponent<Tower>().collRadius.SetActive(false);
        }
        else
        {
            createdTower.GetComponent<Tower>().thisCardName = thisCardName;
            createdTower.GetComponent<Tower>().thisCardName++;
            createdTower.GetComponent<Tower>().type = type;
            createdTower.GetComponent<Tower>().deck = deck;
            createdTower.GetComponent<Tower>().cardSlot = cardSlot;
            createdTower.GetComponent<Tower>().costText = costText;
            createdTower.GetComponent<Tower>().startPosition = startPosition;
            createdTower.GetComponent<Tower>().isPlaced = true;
            createdTower.GetComponent<Tower>().damage = int.Parse(GameManager.Instance.CardLibrary[createdTower.GetComponent<Tower>().thisCardName][CardElement.Damage]);
            createdTower.GetComponent<Tower>().range = int.Parse(GameManager.Instance.CardLibrary[createdTower.GetComponent<Tower>().thisCardName][CardElement.Range]);
            createdTower.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(GameManager.Instance.CardLibrary[createdTower.GetComponent<Tower>().thisCardName][CardElement.TowerSprite]);
            createdTower.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            createdTower.GetComponent<Tower>().collRadius.SetActive(false);
        }

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
    }

    #endregion

    #endregion

    #region Collisions

    /// <summary>
    /// This method checks if an enemy collided with the range of the tower, and adds it to the enemy list
    /// </summary>
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            enemyList.Add(coll.gameObject);
            SortEnemyList();
        }
    }

    /// <summary>
    /// This method removes enemies from the enemies list when they leave the radius of the tower
    /// </summary>
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            enemyList.Remove(coll.gameObject);
            SortEnemyList();
        }
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if ((coll.gameObject.GetComponent<Tower>()) && coll.gameObject.GetComponent<Tower>().thisCardName == thisCardName)
        {
            towerToUpgrade = coll.gameObject;
            canPlaceUpdrage = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            canBePlaced = false;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        canPlaceUpdrage = false;
        canBePlaced = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    #endregion
}