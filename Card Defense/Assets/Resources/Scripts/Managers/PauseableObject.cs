using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseableObject : MonoBehaviour
{
    #region Variables

    protected Rigidbody2D rb; //stores the rigidbody of the gameobject
    protected Animator anim;  //stores the animator of the object

    Vector2 storedVelocity; //stores the current velocity of the object
    bool isSimulated;       //stores the simulated value from the rigidbody

    #endregion

    #region Awake

    protected virtual void Awake ()
    {
        //check if the object has a rigidbody, and if it does store it
		if(GetComponent<Rigidbody2D>())
        {
            rb = GetComponent<Rigidbody2D>();
        }

        //check if the object has an animator, and if it does store it
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }

        GameManager.Instance.AddPausableObject(this);
    }

    #endregion

    #region Private Methods

    //called when the object gets destroyed from the scene
    private void OnDestroy()
    {
        //remove this object from the pauseable objects list in gamemanager
        GameManager.Instance.RemovePausableObject(this);
    }

    #endregion

    #region Public Methods

    public void PauseObject()
    {
        if(rb)
        {
            storedVelocity = rb.velocity;
            isSimulated = rb.simulated;

            rb.velocity = Vector2.zero;
            rb.simulated = false;
        }

        if(anim)
        {
            anim.speed = 0f;
        }
    }

    public void UnPauseObject()
    {
        if (rb)
        {
            rb.simulated = isSimulated;
            rb.velocity =storedVelocity;
        }

        if (anim)
        {
            anim.speed = 1f;
        }
    }

    #endregion
}
