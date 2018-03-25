using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePopup : MonoBehaviour
{
    public Text title;
    public Text xpGainText;
    public Image difficultyCrown;
    public Image star1;
    public Image star2;
    public Image star3;
    public Sprite bronzeCrown;
    public Sprite silverCrown;
    public Sprite goldCrown;

    private void Awake()
    {
        //get sprite references
        bronzeCrown = Resources.Load<Sprite>("Sprites/UI/BronzeCrown");
        silverCrown = Resources.Load<Sprite>("Sprites/UI/SilverCrown");
        goldCrown = Resources.Load<Sprite>("Sprites/UI/GoldCrown");
    }
}
