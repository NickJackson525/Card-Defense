using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    #region Variables

    public Sprite thisTower;   //the sprite the tower this card represents
    Sprite thisCard;    //the sprite for this card
    public bool inHand = true; //used to see where the card currently is
    Vector3 startPosition;     //stores the start position of this card

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        //get the start position
        startPosition = transform.position;
        thisCard = GetComponent<Image>().sprite;
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {

	}

    #endregion

    #region Private Methods

    private void OnMouseEnter()
    {
        //see if the card is in the hand or not
        if (inHand)
        {
            //if the card is in the hand, move up to indicate it is currently selected
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), .1f);
        }
    }

    private void OnMouseExit()
    {
        //jump back to the start position to indicate it is no longer selected
        transform.position = startPosition;
        GetComponent<Image>().sprite = thisCard;
    }

    private void OnMouseOver()
    {
        //check if the left mouse button is being held
        if (Input.GetMouseButton(0))
        {
            //the card is being played, so it will follow the mouse
            inHand = false;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            GetComponent<Image>().sprite = thisTower;
        }
        else
        {
            //the card isn't being played
            inHand = true;
            GetComponent<Image>().sprite = thisCard;
        }

        //check if the left mouse button was released, meaning the card was either played or put back in the hand
        if(Input.GetMouseButtonUp(0))
        {
            //return the card to the hand
            transform.position = startPosition;
        }
    }

    #endregion
}
