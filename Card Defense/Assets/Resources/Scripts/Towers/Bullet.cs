﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables

    public GameObject target;
    public Sprite thisSprite;
    public bool move = false;
    public string type;
    public int damage;

    private Vector3 moveDirection;
    private float speed = 400f;

    #endregion

    private void Start()
    {
        moveDirection = target.transform.position - transform.position;
    }

    #region Update

    void Update ()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
        }
        else if (move)
        {
            GetComponent<Rigidbody2D>().velocity = moveDirection.normalized * speed * Time.deltaTime;
        }
    }

    #endregion

    #region Collision

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (Random.Range(1, 4) == 1)
            {
                Destroy(coll.gameObject);
            }

            Destroy(gameObject);
        }
    }

    #endregion
}
