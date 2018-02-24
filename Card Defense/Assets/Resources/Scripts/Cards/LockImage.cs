using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockImage : MonoBehaviour
{
    #region Variables

    public GameObject thisCard; //the card this lock image will display over

    #endregion

    #region Update

    void Update ()
    {
        //check if the card is locked or not
		if(thisCard.GetComponent<Card>().isLocked)
        {
            //card is locked so display the lock image
            GetComponent<Image>().enabled = true;
        }
        else
        {
            //card is unlocked so don't display lock image
            GetComponent<Image>().enabled = false;
        }
	}

    #endregion
}
