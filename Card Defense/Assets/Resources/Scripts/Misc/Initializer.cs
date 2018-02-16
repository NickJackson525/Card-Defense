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
            GameManager.Instance.CreateDefaultDeck(Cards.BasicResource, Cards.Basic);
            GameManager.Instance.deckType1 = DeckType.Basic;
            GameManager.Instance.deckType2 = DeckType.None;
        }
	}
}
