using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Deck : MonoBehaviour
{
    #region Variables

    public List<CardInfo> deck = new List<CardInfo>();
    public GameObject cardSlot1;
    public GameObject cardSlot2;
    public GameObject cardSlot3;
    public GameObject cardSlot4;
    public GameObject card;
    public GameObject nextOpenCardSlot;
    public bool isFull = false;
    public int cardsInHand = 0;

    private CardInfo tempCard;
    private GameObject createdCard;
    private GameObject UICanvas;             //the ui canvas in the game

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        if (SceneManager.GetActiveScene().name != "Deck Builder")
        {
            UICanvas = GameObject.FindGameObjectWithTag("InGameUI");
        }

        if (GameManager.Instance.deckType2 != DeckType.None)
        {
            UICanvas.GetComponent<InGameUIManager>().numManaType1 = 1;
            UICanvas.GetComponent<InGameUIManager>().numManaType2 = 1;
        }
        else
        {
            UICanvas.GetComponent<InGameUIManager>().numManaType1 = 1;
            UICanvas.GetComponent<InGameUIManager>().numManaType2 = 0;
        }

        nextOpenCardSlot = cardSlot1;

        deck = GameManager.Instance.currentDeck;
        deck = ShuffleDeck(deck);
        Draw();
        Draw();
        Draw();
        Draw();
    }

    #endregion

    #region Update

    void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            GameManager.Instance.CreateDefaultDeck(Cards.BasicResource, Cards.Basic);
            deck = GameManager.Instance.currentDeck;
            isFull = true;

            Draw();
            Draw();
            Draw();
            Draw();
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            GameManager.Instance.CreateDefaultDeck(Cards.FireResource, Cards.BasicFire);
            deck = GameManager.Instance.currentDeck;
            isFull = true;

            Draw();
            Draw();
            Draw();
            Draw();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            GameManager.Instance.CreateDefaultDeck(Cards.IceResource, Cards.BasicIce);
            deck = GameManager.Instance.currentDeck;
            isFull = true;

            Draw();
            Draw();
            Draw();
            Draw();
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            GameManager.Instance.CreateDefaultDeck(Cards.LightningResource, Cards.BasicLightning);
            deck = GameManager.Instance.currentDeck;
            isFull = true;

            Draw();
            Draw();
            Draw();
            Draw();
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            GameManager.Instance.CreateDefaultDeck(Cards.VoidResource, Cards.BasicVoid);
            deck = GameManager.Instance.currentDeck;
            isFull = true;

            Draw();
            Draw();
            Draw();
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
        if ((deck.Count > 0) && (cardsInHand < 4))
        {
            tempCard = deck[0];
            deck.RemoveAt(0);
            isFull = false;
            cardsInHand++;

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
            createdCard.GetComponent<Card>().cardSlot = nextOpenCardSlot;
            createdCard.GetComponent<Card>().deck = gameObject;
            createdCard.GetComponent<Card>().type = tempCard.cardType;

            if (cardsInHand == 1)
            {
                nextOpenCardSlot = cardSlot2;
            }
            else if(cardsInHand == 2)
            {
                nextOpenCardSlot = cardSlot3;
            }
            else
            {
                nextOpenCardSlot = cardSlot4;
            }
        }
    }

    public List<CardInfo> ShuffleDeck(List<CardInfo> deckToShuffle)
    {
        AudioManager.Instance.PlaySound(AudioSourceType.Effects, Sound.DeckShuffle);

        CardInfo temp;
        int rand;

        for(int i = 0; i < deckToShuffle.Count; i++)
        {
            rand = Random.Range(0, deckToShuffle.Count - 1);
            temp = deckToShuffle[rand];
            deckToShuffle[rand] = deckToShuffle[i];
            deckToShuffle[i] = temp;
        }

        return deckToShuffle;
    }

    #endregion
}