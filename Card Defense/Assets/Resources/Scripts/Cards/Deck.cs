using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    #region Variables

    public GameObject cardSlot1;
    public GameObject cardSlot2;
    public GameObject cardSlot3;
    public GameObject cardSlot4;
    public GameObject card;
    public bool isFull = false;
    private List<CardInfo> deck = new List<CardInfo>();
    private CardInfo tempCard;
    private GameObject createdCard;
    private GameObject nextOpenCardSlot;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        nextOpenCardSlot = cardSlot1;

    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            tempCard = new CardInfo(GameManager.CardType.BasicFire, 1, 1, 1, "Basic Fire Tower", Resources.Load<Sprite>("Sprites/Cards/Fire Symbol"), Resources.Load<Sprite>("Sprites/Towers/Square"), Resources.Load<Sprite>("Sprites/Cards/Fire Card Back"), false);
            AddCardToDeck(tempCard);
        }

        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            Draw();
        }
	}

    #endregion

    #region Public Methods

    public void AddCardToDeck(CardInfo cardToAdd)
    {
        //check that the deck isn't full yet
        if (deck.Count < GameManager.deckSize)
        {
            deck.Add(cardToAdd);

            //check if the deck is full now
            if (deck.Count == GameManager.deckSize)
            {
                //deck is full
                isFull = true;
            }
        }
        else
        {
            //can't add card because deck is full
        }
    }

    public void Draw()
    {
        if (deck.Count > 0)
        {
            tempCard = deck[0];
            deck.RemoveAt(0);

            createdCard = Instantiate(card, Vector3.zero, nextOpenCardSlot.transform.rotation, nextOpenCardSlot.transform);
            createdCard.GetComponent<Card>().thisCardType = tempCard.thisCardType;
            createdCard.GetComponent<Card>().costText.text = tempCard.towerCost.ToString();
            createdCard.GetComponent<Card>().damageText.text = tempCard.towerDamage.ToString();
            createdCard.GetComponent<Card>().rangeText.text = tempCard.towerRange.ToString();
            createdCard.GetComponent<Card>().cardNameText.text = tempCard.cardText;
            createdCard.GetComponent<Card>().cardWatermark.sprite = tempCard.towerWatermark;
            createdCard.GetComponent<Card>().cardBack.sprite = tempCard.thisCard;
            createdCard.GetComponent<Card>().cardLevel = tempCard.cardLevel;
            createdCard.GetComponent<Card>().thisTower = tempCard.thisTower;
            createdCard.GetComponent<Card>().isSpell = tempCard.isSpell;
        }
    }

    #endregion
}
