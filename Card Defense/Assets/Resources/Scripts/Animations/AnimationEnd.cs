using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd : PauseableObject
{
    int timer = 120;

	// Update is called once per frame
	void Update ()
    {
        timer--;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
	}
}