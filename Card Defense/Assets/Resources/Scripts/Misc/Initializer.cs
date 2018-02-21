using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        if (GameManager.Instance.currentDeck.Count == 0)
        {
            GameManager.Instance.CreateDefaultDeck(Cards.LightningResource, Cards.BasicLightning);
            GameManager.Instance.deckType1 = DeckType.Lightning;
            GameManager.Instance.deckType2 = DeckType.None;
        }
	}
}
