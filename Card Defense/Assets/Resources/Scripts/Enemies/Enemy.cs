using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : PauseableObject
{
    #region Variables

    List<GameObject> path = new List<GameObject>(); //stores the path for the enemy to take
    Vector3 moveDirection;                          //the direction the enemy is currently moving in
    const float speed = 1f;                         //the speed the enemy moves
    int pathCount = 0;                              //the current place the enemy is in the path

    #endregion

    #region Start

    void Start ()
    {
        //get all the path nodes in the level
        path = GameObject.FindGameObjectsWithTag("PathNode").ToList();

        //sort the path nodes so they are in the correct order for the path
        path.Sort((p1, p2) => p1.GetComponent<PathNode>().nodeNumber.CompareTo(p2.GetComponent<PathNode>().nodeNumber));
    }

    #endregion

    #region Update

    void Update ()
    {
        //check that the game isn't paused
        if (!GameManager.Instance.Paused)
        {
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
                    Destroy(gameObject);
                }
                else
                {
                    //get the direction of the next node to move towards
                    moveDirection = path[pathCount].transform.position - transform.position;

                    //move towards the next node
                    transform.Translate(moveDirection.normalized * speed * Time.deltaTime);

                    //rotate sprite to face correct direction of movement
                    if (Vector3.Normalize(path[pathCount].transform.position - transform.position) == Vector3.up)
                    {

                    }
                    else if (Vector3.Normalize(path[pathCount].transform.position - transform.position) == Vector3.down)
                    {

                    }
                    else if (Vector3.Normalize(path[pathCount].transform.position - transform.position) == Vector3.left)
                    {

                    }
                    else if (Vector3.Normalize(path[pathCount].transform.position - transform.position) == Vector3.right)
                    {

                    }
                }
            }

            #endregion
        }
    }

    #endregion
}
