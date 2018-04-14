using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PauseableObject
{
    #region Variables

    public GameObject target;
    public Sprite thisSprite;
    public bool move = false;
    public DeckType type;
    public int damage;
    public const int fireTimer = 120;
    public const int iceTimer = 120;
    public int voidDeathChance = 20; // 1 out of 20 chance
    public int voidTeleportChance = 10; // 1 out of 10 chance


    private Vector3 moveDirection;
    private float speed = 800f;
    private int destroyTimer = 400;

    #endregion

    #region Start

    private void Start()
    {
        moveDirection = target.transform.position - transform.position;

        if(type == DeckType.Void)
        {
            switch(damage)
            {
                case 1:
                    //no change
                    break;
                case 2:
                    voidDeathChance = 15;
                    voidTeleportChance = 8;
                    break;
                case 3:
                    voidDeathChance = 10;
                    voidTeleportChance = 6;
                    break;
                default:
                    //no change
                    break;
            }
        }
    }

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
            GetComponent<Rigidbody2D>().velocity = moveDirection.normalized * speed * Time.deltaTime;
        }

        destroyTimer--;

        if(destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion
}