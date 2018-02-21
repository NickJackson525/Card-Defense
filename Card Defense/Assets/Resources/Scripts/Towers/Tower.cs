using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region Variables

    public GameObject bullet;
    public GameObject currentTarget;
    public GameObject manaStone;
    public GameObject collRadius;
    public GameObject lightningBolt;
    public DeckType type;
    public int currentLevel = 1;
    public int damage = 1;
    public float range = 1;
    
    private GameObject createdBullet;
    private GameObject testEnemyExist;
    private GameObject UICanvas;             //the ui canvas in the game
    private SpriteRenderer spriteRender;
    private bool canShoot = true;
    private int shootTimer = 0;
    private int manaGenerationTimer = 800;
    private List<GameObject> enemyList = new List<GameObject>();

    #endregion

    #region Start

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        range = range * GameManager.rangeConst;
        collRadius.SetActive(false);
        UICanvas = GameObject.FindGameObjectWithTag("InGameUI");
    }

    #endregion

    #region Update

    void Update()
    {
        if (!GameManager.Instance.Paused)
        {
            //if damage and range are 0 then this is a resource tower
            if ((damage == 0) && (range == 0))
            {
                if (manaGenerationTimer > 0)
                {
                    manaGenerationTimer--;

                    if (manaGenerationTimer == 0)
                    {
                        if (GameManager.Instance.deckType1 == type)
                        {
                            UICanvas.GetComponent<InGameUIManager>().numManaType1++;
                        }
                        else if (GameManager.Instance.deckType2 == type)
                        {
                            UICanvas.GetComponent<InGameUIManager>().numManaType2++;
                        }

                        manaGenerationTimer = 400;
                    }
                }
            }
            else
            {
                currentTarget = FindClosestEnemy();
                testEnemyExist = GameObject.FindGameObjectWithTag("Enemy");
                shootTimer--;

                if (shootTimer == 0)
                {
                    canShoot = true;
                }

                #region Shoot

                if (canShoot && (testEnemyExist != null) && (currentTarget != null))
                {
                    if (enemyList.Count > 0)
                    {
                        if (type == DeckType.Lightning)
                        {
                            currentTarget = enemyList[0];

                            for (int i = 0; i < Random.Range(4, 8); i++)
                            {
                                createdBullet = Instantiate(lightningBolt, new Vector3(transform.position.x, transform.position.y + 1.2f, 0f), transform.rotation);
                                createdBullet.GetComponent<LightningBolt>().startPosition = new Vector3(transform.position.x, transform.position.y + 1.2f, 0f);
                                createdBullet.GetComponent<LightningBolt>().endPosition = currentTarget.transform.position;
                                currentTarget.GetComponent<Enemy>().health -= 1;

                                canShoot = false;
                                shootTimer = 60;
                            }
                        }
                        else
                        {
                            currentTarget = enemyList[0];

                            createdBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1.2f, 0f), transform.rotation);
                            createdBullet.GetComponent<Bullet>().move = true;
                            createdBullet.GetComponent<Bullet>().target = currentTarget;
                            createdBullet.GetComponent<Bullet>().damage = damage;
                            createdBullet.GetComponent<Bullet>().type = type;

                            canShoot = false;
                            shootTimer = 60;

                            #region Color Bullet

                            switch (type)
                            {
                                case DeckType.Basic:
                                    createdBullet.GetComponent<SpriteRenderer>().color = Color.white;
                                    break;
                                case DeckType.Fire:
                                    createdBullet.GetComponent<SpriteRenderer>().color = Color.red;
                                    break;
                                case DeckType.Ice:
                                    createdBullet.GetComponent<SpriteRenderer>().color = Color.blue;
                                    break;
                                case DeckType.Lightning:
                                    createdBullet.GetComponent<SpriteRenderer>().color = Color.yellow;
                                    break;
                                case DeckType.Void:
                                    createdBullet.GetComponent<SpriteRenderer>().color = Color.magenta;
                                    break;
                                default:
                                    createdBullet.GetComponent<SpriteRenderer>().color = Color.black;
                                    break;
                            }

                            #endregion
                        }
                    }
                }

                #endregion
            }
        }
    }

    #endregion

    #region Private Methods

    private GameObject FindClosestEnemy()
    {
        GameObject[] allEnemies;
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in allEnemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void SortEnemyList()
    {
        enemyList.Sort((p1, p2) => p1.GetComponent<Enemy>().distFromEnd.CompareTo(p2.GetComponent<Enemy>().distFromEnd));
    }

    #endregion

    #region Collisions

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            enemyList.Add(coll.gameObject);
            SortEnemyList();
        }
    }

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
