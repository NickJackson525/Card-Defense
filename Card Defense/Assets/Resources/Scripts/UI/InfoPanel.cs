using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public Text title;
    public Image mapScreenshot;
    public Image star1;
    public Image star2;
    public Image star3;
    public Image difficultyCrown;
    public Sprite bronzeCrown;
    public Sprite silverCrown;
    public Sprite goldCrown;

    // Use this for initialization
    void Start ()
    {
        //get sprite references
        bronzeCrown = Resources.Load<Sprite>("Sprites/UI/BronzeCrown");
        silverCrown = Resources.Load<Sprite>("Sprites/UI/SilverCrown");
        goldCrown = Resources.Load<Sprite>("Sprites/UI/GoldCrown");
    }
}
