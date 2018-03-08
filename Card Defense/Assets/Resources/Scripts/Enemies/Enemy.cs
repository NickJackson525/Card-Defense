using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : PauseableObject
{
    #region Variables

    public int spellFireTimer = 0;                          //how long the damage over time from a spell will last
    public int spellFrozenTimer = 0;                       //how long the enemy will stay slowed
    public int spellDamageToTake = 0;                       //how much damage to take over time
    public float currSpeed;                                 //the speed the enemy is currently moving
    public float naturalSpeed;                              //the speed the enemy goes without anything altering it
    public float health = 20f;                              //the health of the enemy
    public float distFromEnd = 0;                           //how far away this enemy is from the end of the track
    
    private List<GameObject> path = new List<GameObject>(); //stores the path for the enemy to take
    private Vector3 moveDirection;                          //the direction the enemy is currently moving in
    private int pathCount = 0;                              //the current place the enemy is in the path
    private int bulletFireTimer = 0;                        //how long the damage over time from a bullet will last
    private int bulletFrozenTimer = 0;                      //how long the enemy will stay slowed
    private int bulletDamageToTake = 0;                     //how much damage to take over time

    #endregion

    #region Start

    protected virtual void Start ()
    {
        currSpeed = naturalSpeed;

        //get all the path nodes in the level
        path = GameObject.FindGameObjectsWithTag("PathNode").ToList();

        //sort the path nodes so they are in the correct order for the path
        path.Sort((p1, p2) => p1.GetComponent<PathNode>().nodeNumber.CompareTo(p2.GetComponent<PathNode>().nodeNumber));
    }

    #endregion

    #region Update

    protected virtual void Update()
    {
        //check that the game isn't paused
        if (!GameManager.Instance.Paused)
        {
            #region Update Distance to End

            distFromEnd = (path.Count() - (pathCount + 1)) + Vector2.Distance(path[pathCount].gameObject.transform.position, transform.position);

            #endregion

            #region Fire Damage From Bullet

            if(bulletFireTimer > 0)
            {
                bulletFireTimer--;

                if ((bulletFireTimer % 10) == 0)
                {
                    health -= bulletDamageToTake;
                }

                if(bulletFireTimer == 0)
                {
                    bulletDamageToTake = 0;
                }
            }

            #endregion

            #region Fire Damage From Spells

            if (spellFireTimer > 0)
            {
                spellFireTimer--;

                if ((spellFireTimer % 10) == 0)
                {
                    health -= spellDamageToTake;
                }

                if (spellFireTimer == 0)
                {
                    spellDamageToTake = 0;
                }
            }

            #endregion

            #region Frozen From Bullet

            if (bulletFrozenTimer > 0)
            {
                bulletFrozenTimer--;

                currSpeed = naturalSpeed / 2f;

                if(bulletFrozenTimer == 0)
                {
                    currSpeed = naturalSpeed;
                }
            }

            #endregion

            #region Frozen From Spells

            if (spellFrozenTimer > 0)
            {
                spellFrozenTimer--;

                currSpeed = 0;

                if (spellFrozenTimer == 0)
                {
                    currSpeed = naturalSpeed;
                }
            }

            #endregion

            #region Path

            //check that the enemy isn't at the end of the path
            if (pathCount <= path.Count())
            {
                //see if the enemy is close to the target node
                if (Vector2.Distance(gameObject.transform.position, path[pathCount].gameObject.transform.position) < .07f)
                {
                    //jup the enemy position to be equal to the nodes position
                    transform.position = path[pathCount].transform.position;

                    //advance to the next node
                    pathCount++;
                }

                //if the enemy has reached the last node, destroy it
                if (pathCount >= path.Count())
                {
                    GameManager.Instance.baseHealth -= (int)health;
                    Destroy(gameObject);
                }
                else
                {
                    //get the direction of the next node to move towards
                    moveDirection = path[pathCount].transform.position - transform.position;

                    //rotate sprite to face correct direction of movement
                    if (moveDirection.x > 0)
                    {
                        transform.rotation = new Quaternion(transform.rotation.x, 180f, transform.rotation.z, transform.rotation.w);
                        moveDirection = new Vector3(-moveDirection.x, moveDirection.y, moveDirection.z);
                    }
                    else
                    {
                        transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
                    }

                    //move towards the next node
                    transform.Translate(moveDirection.normalized * currSpeed * Time.deltaTime);
                }
            }

            #endregion

            #region Check Death

            if(health <= 0)
            {
                Destroy(gameObject);
            }

            #endregion
        }
    }

    #endregion

    #region Collision

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            switch(coll.GetComponent<Bullet>().type)
            {
                case DeckType.Basic:
                    health -= coll.GetComponent<Bullet>().damage;
                    break;
                case DeckType.Fire:
                    bulletFireTimer = 120;
                    bulletDamageToTake = coll.GetComponent<Bullet>().damage;
                    break;
                case DeckType.Ice:
                    bulletFrozenTimer = 120;
                    health -= coll.GetComponent<Bullet>().damage;
                    break;
                case DeckType.Lightning:
                    break;
                case DeckType.Void:
                    if(Random.Range(0, 8) == 0)
                    {
                        health = 0;
                    }

                    health -= coll.GetComponent<Bullet>().damage;
                    break;
                default:
                    health -= coll.GetComponent<Bullet>().damage;
                    break;
            }

            Destroy(coll.gameObject);
        }
    }

    #endregion
}