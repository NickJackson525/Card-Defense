using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    List<GameObject> path = new List<GameObject>();
    Vector3 moveDirection;
    const float speed = 1f;
    int pathCount = 0;

    // Use this for initialization
    void Start ()
    {
        path = GameObject.FindGameObjectsWithTag("PathNode").ToList();
        path.Sort((p1, p2) => p1.GetComponent<PathNode>().nodeNumber.CompareTo(p2.GetComponent<PathNode>().nodeNumber));
    }
	
	// Update is called once per frame
	void Update ()
    {
        #region Path

        if (pathCount <= path.Count())
        {
            if (Vector2.Distance(gameObject.transform.position, path[pathCount].gameObject.transform.position) < .07f)
            {
                transform.position = path[pathCount].transform.position;
                pathCount++;
            }

            if (pathCount >= path.Count())
            {
                Destroy(gameObject);
            }
            else
            {
                moveDirection = path[pathCount].transform.position - transform.position;
                transform.Translate(moveDirection.normalized * speed * Time.deltaTime);

                if (Vector3.Normalize(path[pathCount].transform.position - transform.position) == Vector3.up)
                {
                    //GetComponent<SpriteRenderer>().sprite = faceUp;
                }
                else if (Vector3.Normalize(path[pathCount].transform.position - transform.position) == Vector3.down)
                {
                    //GetComponent<SpriteRenderer>().sprite = faceDown;
                }
                else if (Vector3.Normalize(path[pathCount].transform.position - transform.position) == Vector3.left)
                {
                    //GetComponent<SpriteRenderer>().sprite = faceLeft;
                }
                else if (Vector3.Normalize(path[pathCount].transform.position - transform.position) == Vector3.right)
                {
                    //GetComponent<SpriteRenderer>().sprite = faceRight;
                }
            }
        }

        #endregion
    }
}
