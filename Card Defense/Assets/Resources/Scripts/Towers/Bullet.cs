using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables

    public GameObject target;
    public Sprite thisSprite;
    public bool move = false;
    public int damage;
    public float speed = 5f;

    private Vector3 moveDirection;

    #endregion

    #region Update

    void Update ()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
        }
        else if (move)
        {
            moveDirection = target.transform.position - transform.position;
            transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
        }
    }

    #endregion

    #region Collision

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if ((Random.Range(1, 4) == 1) && coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }

    #endregion
}
