using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    #region Variables

    private GameObject fill;
    private GameObject fillText;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        fill = GameObject.Find("Fill");
        fillText = GameObject.Find("FillText");
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
		if(fill)
        {
            fill.GetComponent<Image>().fillAmount = GameManager.Instance.currentXP / GameManager.Instance.xpToNextLevel;
        }

        if(fillText)
        {
            fillText.GetComponent<Text>().text = GameManager.Instance.currentXP + " / " + GameManager.Instance.xpToNextLevel;
        }
	}

    #endregion
}
