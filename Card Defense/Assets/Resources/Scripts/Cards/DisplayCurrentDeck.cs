using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrentDeck : MonoBehaviour
{
    #region Variables

    #region Public 

    public GameObject cardSlot1;        // The first location to display a card
    public GameObject cardSlot2;        // The second location to display a card
    public GameObject cardSlot3;        // The third location to display a card
    public GameObject cardSlot4;        // The fourth location to display a card
    public GameObject cardSlot5;        // The fifth location to display a card
    public GameObject cardSlot6;        // The sixth location to display a card
    public GameObject cardSlot7;        // The seventh location to display a card
    public GameObject cardSlot8;        // The eigth location to display a card
    public GameObject cardSlot9;        // The ninth location to display a card
    public Text currentPageDisplay;
    public Text displayNumCardsInDeck;

    #endregion

    #region Private

    private List<CardInfo> currentDeck;      // A local copy of the current deck to be used to display them in a grid
    private List<GameObject> displayedCards; // The current cards being displayed on the grid
    private GameObject card;                 // Used to create the displayed cards
    private GameObject nextOpenCardSlot;     // Used to keep track of the next open card slot
    private GameObject createdCard;          // Used to temporarily store the card GameObject just created
    private CardInfo tempCard;               // Used to get the card info grom the CardLibrary dictoionary
    private int currentDeckSize = 0;         // Used to store the current deck size
    private int currentPage = 0;             // Used to keep track of which page is being displayed
    private int cardsCreated = 0;            // Used to keep track of how many cards have been created/displayed

    #endregion

    #endregion

    #region Start

    void Start()
    {
        //initialize variables
        card = Resources.Load<GameObject>("Prefabs/Cards/Deck Builder Card");
        currentDeck = GameManager.Instance.currentDeck;
        displayedCards = new List<GameObject>();
        nextOpenCardSlot = cardSlot1;
        currentDeckSize = currentDeck.Count;

        //view the first page
        ViewNextPage();
    }

    #endregion

    #region Update

    void Update()
    {
        //check if a card has been removed or added
        if (currentDeckSize != GameManager.Instance.currentDeck.Count)
        {
            //reset deck size
            currentDeckSize = GameManager.Instance.currentDeck.Count;

            //redisplay the current deck
            DestroyDisplayedCards();
            DisplayCards();
        }

        //update deck size
        currentDeckSize = GameManager.Instance.currentDeck.Count;

        currentPageDisplay.text = currentPage + " / " + ((currentDeck.Count / 9) + 1);
        displayNumCardsInDeck.text = GameManager.Instance.currentDeck.Count + " / " + GameManager.deckSize;
    }

    #endregion

    #region Public Methods

    //Method adds a new card to the current deck
    public void AddCardToDeck(CardInfo cardToAdd)
    {
        currentDeck.Add(cardToAdd);
    }

    //Method destroys all the currently displayed cards so new ones can be created
    public void DestroyDisplayedCards()
    {
        foreach (GameObject card in displayedCards)
        {
            Destroy(card);
        }

        displayedCards.Clear();
    }

    //Go to the next page of the deck
    public void ViewNextPage()
    {
        //check that this isn't the last page of the deck
        if (currentPage < ((currentDeck.Count / 9) + 1))
        {
            //view the next page of the deck
            currentPage++;
            DestroyDisplayedCards();
            DisplayCards();
        }
    }

    //Go to the previous page of the deck
    public void ViewPreviousPage()
    {
        //check that this isn't the first page
        if (currentPage > 1)
        {
            //view the previous page
            currentPage--;
            DestroyDisplayedCards();
            DisplayCards();
        }
    }

    /// <summary>
    /// This method displays the cards from the current page of the deck, up to 9 cards
    /// </summary>
    public void DisplayCards()
    {
        //start at the first card slot
        nextOpenCardSlot = cardSlot1;
        cardsCreated = 0;

        //loop 9 times, once for each card slot
        for (int i = 0; i < 9; i++)
        {
            //check that there are still cards to display on this page
            if (cardsCreated + ((currentPage - 1) * 9) < currentDeck.Count)
            {
                //get the next card and increase the number of cards created
                tempCard = currentDeck[cardsCreated + ((currentPage - 1) * 9)];
                cardsCreated++;

                #region Create Card Game Object

                //create the carg object and initialize all of its values
                createdCard = Instantiate(card, Vector3.zero, nextOpenCardSlot.transform.rotation, nextOpenCardSlot.transform);
                createdCard.GetComponent<Image>().sprite = tempCard.thisCard;
                createdCard.GetComponent<Card>().thisCardName = tempCard.thisCardName;
                createdCard.GetComponent<Card>().costText.text = tempCard.towerCost.ToString();
                createdCard.GetComponent<Card>().damageText.text = tempCard.towerDamage.ToString();
                createdCard.GetComponent<Card>().rangeText.text = tempCard.towerRange.ToString();
                createdCard.GetComponent<Card>().cardNameText.text = tempCard.cardType.ToString();
                createdCard.GetComponent<Card>().cardText.text = tempCard.cardText;
                createdCard.GetComponent<Card>().cardWatermark.sprite = tempCard.towerWatermark;
                createdCard.GetComponent<Card>().cardArt.sprite = tempCard.thisCardArt;
                createdCard.GetComponent<Card>().cardBack.sprite = tempCard.thisCard;
                createdCard.GetComponent<Card>().cardBackOutline.sprite = tempCard.thisCardOutline;
                createdCard.GetComponent<Card>().cardLevel = tempCard.cardLevel;
                createdCard.GetComponent<Card>().thisTower = tempCard.thisTower;
                createdCard.GetComponent<Card>().isSpell = tempCard.isSpell;
                createdCard.GetComponent<Card>().isLocked = tempCard.isLocked;
                createdCard.GetComponent<Card>().cardSlot = nextOpenCardSlot;
                createdCard.GetComponent<Card>().deck = gameObject;
                createdCard.GetComponent<Card>().inDeck = true;
                createdCard.GetComponent<Card>().numberInDeck = (cardsCreated - 1) + ((currentPage - 1) * 9);
                createdCard.GetComponent<Card>().type = tempCard.cardType;

                //add the creaded card to the displayed cards deck
                displayedCards.Add(createdCard);

                #endregion

                #region Update Next Open Card Slot

                switch(cardsCreated)
                {
                    case 1:
                        nextOpenCardSlot = cardSlot2;
                        break;
                    case 2:
                        nextOpenCardSlot = cardSlot3;
                        break;
                    case 3:
                        nextOpenCardSlot = cardSlot4;
                        break;
                    case 4:
                        nextOpenCardSlot = cardSlot5;
                        break;
                    case 5:
                        nextOpenCardSlot = cardSlot6;
                        break;
                    case 6:
                        nextOpenCardSlot = cardSlot7;
                        break;
                    case 7:
                        nextOpenCardSlot = cardSlot8;
                        break;
                    case 8:
                        nextOpenCardSlot = cardSlot9;
                        break;
                }

                #endregion
            }
        }
    }

    #endregion
}