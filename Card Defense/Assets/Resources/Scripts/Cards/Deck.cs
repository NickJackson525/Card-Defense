using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    #region Variables

    public GameObject cardSlot1;
    public bool isFull = false;
    private List<Card> deck = new List<Card>();
    private Card tempCard;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
		
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            tempCard = new Card(GameManager.CardType.BasicFire, 1, 1, 1, "Basic Fire Tower", Resources.Load<Sprite>("Sprites/Cards/Fire Symbol"), Resources.Load<Sprite>("Sprites/Towers/Square"), Resources.Load<Sprite>("Sprites/Cards/Fire Card Back"), false);
            AddCardToDeck(tempCard);
        }

        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            Draw();
            //tempCard = new Card(GameManager.CardType.FireResource, 0, 0, 0, "Fire Resource", Resources.Load<Sprite>("Sprites/Cards/Fire Symbol"), Resources.Load<Sprite>("Sprites/Towers/Square"), Resources.Load<Sprite>("Sprites/Cards/Fire Card Back"), false);
            //AddCardToDeck(tempCard);
        }
	}

    #endregion

    #region Public Methods

    public void AddCardToDeck(Card cardToAdd)
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

            cardSlot1.GetComponent<Card>().thisCardType = tempCard.thisCardType;
            cardSlot1.GetComponent<Card>().towerCost = tempCard.towerCost;
            cardSlot1.GetComponent<Card>().towerDamage = tempCard.towerDamage;
            cardSlot1.GetComponent<Card>().towerRange = tempCard.towerRange;
            cardSlot1.GetComponent<Card>().cardText = tempCard.cardText;
            cardSlot1.GetComponent<Card>().towerWatermark = tempCard.towerWatermark;
            cardSlot1.GetComponent<Card>().thisTower = tempCard.thisTower;
            cardSlot1.GetComponent<Card>().thisCard = tempCard.thisCard;
            cardSlot1.GetComponent<Card>().isSpell = tempCard.isSpell;
        }
    }

    #endregion
}
