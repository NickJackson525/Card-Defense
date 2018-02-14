using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables

    public GameObject target;
    public Sprite thisSprite;
    public bool move = false;
    public DeckType type;
    public int damage;

    private Vector3 moveDirection;
    private float speed = 400f;

    #endregion

    #region Start

    private void Start()
    {
        moveDirection = target.transform.position - transform.position;
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
    }

    #endregion
}
