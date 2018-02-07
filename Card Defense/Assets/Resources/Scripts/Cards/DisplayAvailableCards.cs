using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAvailableCards : MonoBehaviour
{
    #region Variables

    public List<CardInfo> allCardsDeck = new List<CardInfo>();
    public List<GameObject> displayedCards = new List<GameObject>();
    public GameObject card;
    public GameObject cardSlot1;
    public GameObject cardSlot2;
    public GameObject cardSlot3;
    public GameObject cardSlot4;
    public GameObject cardSlot5;
    public GameObject cardSlot6;
    public GameObject cardSlot7;
    public GameObject cardSlot8;
    public GameObject cardSlot9;
    public GameObject nextOpenCardSlot;
    public int currentPage = 0;
    public int cardsCreated = 0;

    private GameObject createdCard;
    private CardInfo tempCard;

    #endregion

    #region Start

    void Start ()
    {
        nextOpenCardSlot = cardSlot1;

        foreach(KeyValuePair<CardType, Dictionary<CardElement, string>> card in GameManager.Instance.CardLibrary)
        {
            AddCardToDeck(GameManager.Instance.CreateCard(card.Key));
        }

        ViewNextPage();
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
		
	}

    #endregion

    #region Public Methods

    public void AddCardToDeck(CardInfo cardToAdd)
    {
        allCardsDeck.Add(cardToAdd);
    }

    public void DestroyDisplayedCards()
    {
        foreach(GameObject card in displayedCards)
        {
            Destroy(card);
        }

        displayedCards.Clear();
    }

    public void ViewNextPage()
    {
        if (currentPage < ((float)allCardsDeck.Count / 9f))
        {
            currentPage++;
            DestroyDisplayedCards();
            DisplayCards();
        }
    }

    public void ViewPreviousPage()
    {
        if (currentPage > 1)
        {
            currentPage--;
            DestroyDisplayedCards();
            DisplayCards();
        }
    }


    public void DisplayCards()
    {
        nextOpenCardSlot = cardSlot1;
        cardsCreated = 0;

        for (int i = 0; i < 9; i++)
        {
            tempCard = allCardsDeck[cardsCreated + ((currentPage - 1) * 9)];
            cardsCreated++;

            #region Create Card Game Object

            createdCard = Instantiate(card, Vector3.zero, nextOpenCardSlot.transform.rotation, nextOpenCardSlot.transform);
            createdCard.GetComponent<Image>().sprite = tempCard.thisCard;
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
            createdCard.GetComponent<Card>().isLocked = tempCard.isLocked;
            createdCard.GetComponent<Card>().cardSlot = nextOpenCardSlot;
            createdCard.GetComponent<Card>().deck = gameObject;
            createdCard.GetComponent<Card>().numberInDeck = (cardsCreated - 1) + ((currentPage - 1) * 9);

            displayedCards.Add(createdCard);

            #endregion

            #region Update Next Open Card Slot

            if (cardsCreated == 1)
            {
                nextOpenCardSlot = cardSlot2;
            }
            else if (cardsCreated == 2)
            {
                nextOpenCardSlot = cardSlot3;
            }
            else if (cardsCreated == 3)
            {
                nextOpenCardSlot = cardSlot4;
            }
            else if (cardsCreated == 4)
            {
                nextOpenCardSlot = cardSlot5;
            }
            else if (cardsCreated == 5)
            {
                nextOpenCardSlot = cardSlot6;
            }
            else if (cardsCreated == 6)
            {
                nextOpenCardSlot = cardSlot7;
            }
            else if (cardsCreated == 7)
            {
                nextOpenCardSlot = cardSlot8;
            }
            else
            {
                nextOpenCardSlot = cardSlot9;
            }

            #endregion
        }
    }

    #endregion
}
