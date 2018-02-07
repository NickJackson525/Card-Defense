using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockImage : MonoBehaviour
{
    public GameObject thisCard;
	
	// Update is called once per frame
	void Update ()
    {
		if(thisCard.GetComponent<Card>().isLocked)
        {
            GetComponent<Image>().enabled = true;
        }
        else
        {
            GetComponent<Image>().enabled = false;
        }
	}
}
