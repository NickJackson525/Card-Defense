﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;
    public Text healthBarText;
	
	// Update is called once per frame
	void Update ()
    {
        healthBarFill.fillAmount = GameManager.Instance.baseHealth / 100f;
        healthBarText.text = GameManager.Instance.baseHealth.ToString() + " / 100";
	}
}
