using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region Variables

    #region Public

    public GameObject manaStone;  // Used so that the color can be changed upon creation of this tower to match the type
    public GameObject collRadius; // Used to show the player the range of this tower
    public DeckType type;         // Used to create the right type of bullet or mana
    public int currentLevel = 1;  // Used to scale everything when the tower levels up
    public int damage = 1;        // Used to assign the damage to the bullet when created
    public float range = 1;       // Used to scale the range collider and collRadius gameobject

    #endregion

    #region Private

    private enum TargetPriority { First, Last, Close, Strong }   // The list of target priorities this tower can have
    private TargetPriority thisPriority = TargetPriority.First;  // Used to determine which enemy within range to shoot at
    private GameObject currentTarget;                            // Used to track the closest enemy
    private GameObject bullet;                                   // Used as a template for creating bullets
    private GameObject lightningBolt;                            // Used as a template for creating lightning bolts
    private GameObject createdObject;                            // Used to modify the values of the created object. Either a bullet or lightning bolt
    private GameObject UICanvas;                                 // Used to increment mana levels
    private bool canShoot = true;                                // Used to control when this tower can shoot
    private int shootTimer = 0;                                  // Used to control the time between each shot of this tower
    private int manaGenerationTimer = 800;                       // Used to control the time between each mana generatrion of this tower
    private List<GameObject> enemyList = new List<GameObject>(); // Used to store all the enemies within range

    #endregion

    #endregion

    #region Start

    void Start()
    {
        //get references
        bullet = Resources.Load<GameObject>("Prefabs/Towers/Bullet");
        lightningBolt = Resources.Load<GameObject>("Prefabs/Towers/LightningBolt");
        UICanvas = GameObject.FindGameObjectWithTag("InGameUI");

        //scale range
        range = range * GameManager.rangeConst;

        //deactivate the radius object
        collRadius.SetActive(false);
    }

    #endregion

    #region Update

    void Update()
    {
        //check that the game isn't paused
        if (!GameManager.Instance.Paused)
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
                        //create lighting bolts
                        for (int i = 0; i < Random.Range(4, 8); i++)
                        {
                            //create lightning bolt and assign values
                            createdObject = Instantiate(lightningBolt, new Vector3(transform.position.x, transform.position.y + 1.2f, 0f), transform.rotation);
                            createdObject.GetComponent<LightningBolt>().startPosition = new Vector3(transform.position.x, transform.position.y + 1.2f, 0f);
                            createdObject.GetComponent<LightningBolt>().endPosition = currentTarget.transform.position;
                            currentTarget.GetComponent<Enemy>().health -= damage * currentLevel;
                        }
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

    #endregion
}