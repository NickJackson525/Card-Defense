using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSignpost : MonoBehaviour
{
    #region Variables

    public LevelNumber level;
    public Image star1;
    public Image star2;
    public Image star3;
    public Image difficultyCrown;

    private Sprite bronzeCrown;
    private Sprite silverCrown;
    private Sprite goldCrown;

    #endregion

    #region Start

    // Use this for initialization
    void Awake ()
    {
        //get sprite references
        bronzeCrown = Resources.Load<Sprite>("Sprites/UI/BronzeCrown");
        silverCrown = Resources.Load<Sprite>("Sprites/UI/SilverCrown");
        goldCrown = Resources.Load<Sprite>("Sprites/UI/GoldCrown");
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if (bool.Parse(LevelSelectManager.Instance.LevelLibrary[level][LevelElements.isLevelLocked]))
        {
            GetComponent<Button>().interactable = false;
            GetComponent<Image>().color = Color.black;
        }
        else
        {
            GetComponent<Button>().interactable = true;
            GetComponent<Image>().color = Color.white;
        }

		if(bool.Parse(LevelSelectManager.Instance.LevelLibrary[level][LevelElements.Star1Unlocked]))
        {
            star1.color = Color.white;
        }
        else
        {
            star1.color = Color.black;
        }

        if (bool.Parse(LevelSelectManager.Instance.LevelLibrary[level][LevelElements.Star2Unlocked]))
        {
            star2.color = Color.white;
        }
        else
        {
            star2.color = Color.black;
        }

        if (bool.Parse(LevelSelectManager.Instance.LevelLibrary[level][LevelElements.Star3Unlocked]))
        {
            star3.color = Color.white;
        }
        else
        {
            star3.color = Color.black;
        }

        if(LevelSelectManager.Instance.LevelLibrary[level][LevelElements.DifficultyCompleted] == "Bronze")
        {
            difficultyCrown.sprite = bronzeCrown;
            difficultyCrown.color = Color.white;
        }
        else if (LevelSelectManager.Instance.LevelLibrary[level][LevelElements.DifficultyCompleted] == "Silver")
        {
            difficultyCrown.sprite = silverCrown;
            difficultyCrown.color = Color.white;
        }
        else if (LevelSelectManager.Instance.LevelLibrary[level][LevelElements.DifficultyCompleted] == "Gold")
        {
            difficultyCrown.sprite = goldCrown;
            difficultyCrown.color = Color.white;
        }
        else
        {
            difficultyCrown.sprite = bronzeCrown;
            difficultyCrown.color = Color.black;
        }
    }

    #endregion
}
