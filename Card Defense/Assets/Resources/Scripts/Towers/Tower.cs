using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region Variables

    public GameObject bullet;
    public GameObject currentTarget;
    GameObject createdBullet;
    GameObject testEnemyExist;
    int shootTimer = 0;
    public int currentLevel = 1;
    bool canShoot = true;
    public float range = 1f;
    SpriteRenderer spriteRender;

    #endregion

    #region Start

    // Use this for initialization
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
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
                //createdBullet.GetComponent<Bullet>().move = true;
                //createdBullet.GetComponent<Bullet>().target = currentTarget;
                //createdBullet.GetComponent<Bullet>().damage = createdBullet.GetComponent<Bullet>().damage * (currentLevel + 1);
                //createdBullet.GetComponent<Bullet>().type = thisPlant;
                canShoot = false;
                shootTimer = 60 - ((currentLevel - 1) * 20);

                //switch (thisPlant)
                //{
                //    case GameManager.ShopItems.BASIC:
                //        createdBullet.GetComponent<Bullet>().thisSprite = basicBullet;
                //        break;
                //    case GameManager.ShopItems.FIRE:
                //        createdBullet.GetComponent<Bullet>().thisSprite = fireBullet;
                //        break;
                //    case GameManager.ShopItems.ICE:
                //        createdBullet.GetComponent<Bullet>().thisSprite = iceBullet;
                //        break;
                //    case GameManager.ShopItems.VOID:
                //        createdBullet.GetComponent<Bullet>().thisSprite = voidBullet;
                //        break;
                //    default:
                //        createdBullet.GetComponent<Bullet>().thisSprite = basicBullet;
                //        break;
                //}
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
