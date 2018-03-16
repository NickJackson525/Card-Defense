using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    #region Variables

    public Text mana1;
    public Text mana2;
    public Image manaImage1;
    public Image manaImage2;
    public int numManaType1 = 0;
    public int numManaType2 = 0;

    private GameObject pauseMenu;
    private Sprite basicImage;
    private Sprite fireImage;
    private Sprite iceImage;
    private Sprite lightningImage;
    private Sprite voidImage;

    #endregion

    #region Start

    void Start ()
    {
		basicImage = Resources.Load<Sprite>("Sprites/Cards/Basic/Basic Symbol");
        fireImage = Resources.Load<Sprite>("Sprites/Cards/Fire/Fire Symbol");
        iceImage = Resources.Load<Sprite>("Sprites/Cards/Ice/Ice Symbol");
        lightningImage = Resources.Load<Sprite>("Sprites/Cards/Lightning/Lightning Symbol");
        voidImage = Resources.Load<Sprite>("Sprites/Cards/Void/Void Symbol");
        pauseMenu = GameObject.Find("PauseMenu");
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if (GameManager.Instance.Paused)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }

        mana1.text = numManaType1.ToString();
        mana2.text = numManaType2.ToString();

        switch (GameManager.Instance.deckType1)
        {
            case DeckType.Basic:
                manaImage1.sprite = basicImage;
                mana1.gameObject.SetActive(true);
                manaImage1.gameObject.SetActive(true);
                break;
            case DeckType.Fire:
                manaImage1.sprite = fireImage;
                mana1.gameObject.SetActive(true);
                manaImage1.gameObject.SetActive(true);
                break;
            case DeckType.Ice:
                manaImage1.sprite = iceImage;
                mana1.gameObject.SetActive(true);
                manaImage1.gameObject.SetActive(true);
                break;
            case DeckType.Lightning:
                manaImage1.sprite = lightningImage;
                mana1.gameObject.SetActive(true);
                manaImage1.gameObject.SetActive(true);
                break;
            case DeckType.Void:
                manaImage1.sprite = voidImage;
                mana1.gameObject.SetActive(true);
                manaImage1.gameObject.SetActive(true);
                break;
            case DeckType.None:
                mana1.gameObject.SetActive(false);
                manaImage1.gameObject.SetActive(false);
                break;
            default:
                manaImage1.sprite = basicImage;
                mana1.gameObject.SetActive(true);
                manaImage1.gameObject.SetActive(true);
                break;
        }

        switch (GameManager.Instance.deckType2)
        {
            case DeckType.Basic:
                manaImage2.sprite = basicImage;
                mana2.gameObject.SetActive(true);
                manaImage2.gameObject.SetActive(true);
                break;
            case DeckType.Fire:
                manaImage2.sprite = fireImage;
                mana2.gameObject.SetActive(true);
                manaImage2.gameObject.SetActive(true);
                break;
            case DeckType.Ice:
                manaImage2.sprite = iceImage;
                mana2.gameObject.SetActive(true);
                manaImage2.gameObject.SetActive(true);
                break;
            case DeckType.Lightning:
                manaImage2.sprite = lightningImage;
                mana2.gameObject.SetActive(true);
                manaImage2.gameObject.SetActive(true);
                break;
            case DeckType.Void:
                manaImage2.sprite = voidImage;
                mana2.gameObject.SetActive(true);
                manaImage2.gameObject.SetActive(true);
                break;
            case DeckType.None:
                mana2.gameObject.SetActive(false);
                manaImage2.gameObject.SetActive(false);
                break;
            default:
                manaImage2.sprite = basicImage;
                mana2.gameObject.SetActive(true);
                manaImage2.gameObject.SetActive(true);
                break;
        }
    }

    #endregion
}