using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region Variables

    public GameObject bullet;
    public GameObject currentTarget;
    public GameObject manaStone;
    public string type;
    public int currentLevel = 1;
    public int damage = 1;
    public float range = 1;
    
    private GameObject createdBullet;
    private GameObject testEnemyExist;
    private SpriteRenderer spriteRender;
    private bool canShoot = true;
    private int shootTimer = 0;

    #endregion

    #region Start

    // Use this for initialization
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        range = range * GameManager.rangeConst;
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update()
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
            if (Vector2.Distance(currentTarget.transform.position, this.gameObject.transform.position) <= range)
            {
                createdBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
                createdBullet.GetComponent<Bullet>().move = true;
                createdBullet.GetComponent<Bullet>().target = currentTarget;
                createdBullet.GetComponent<Bullet>().damage = damage;
                createdBullet.GetComponent<Bullet>().type = type;

                canShoot = false;
                shootTimer = 60;

                #region Color Bullet

                switch (type)
                {
                    case "Basic":
                        createdBullet.GetComponent<SpriteRenderer>().color = Color.white;
                        break;
                    case "Fire":
                        createdBullet.GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    case "Ice":
                        createdBullet.GetComponent<SpriteRenderer>().color = Color.blue;
                        break;
                    case "Lightning":
                        createdBullet.GetComponent<SpriteRenderer>().color = Color.yellow;
                        break;
                    case "Void":
                        createdBullet.GetComponent<SpriteRenderer>().color = Color.magenta;
                        break;
                    default:
                        createdBullet.GetComponent<SpriteRenderer>().color = Color.black;
                        break;
                }

                #endregion
            }
        }

        #endregion
    }

    #endregion

    #region Custom Methods

    public GameObject FindClosestEnemy()
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

    #endregion
}
