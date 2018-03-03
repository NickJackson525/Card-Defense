using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    #region Start

    void Start ()
    {
        GameManager.Instance.Load();

        if (GameManager.Instance.currentDeck.Count == 0)
        {
            GameManager.Instance.CreateDefaultDeck(Cards.BasicResource, Cards.Basic);
            GameManager.Instance.deckType1 = DeckType.Basic;
            GameManager.Instance.deckType2 = DeckType.None;

            GameManager.Instance.Save();
        }

        foreach (KeyValuePair<Cards, Dictionary<CardElement, string>> card in GameManager.Instance.CardLibrary)
        {
            if(GameManager.Instance.playerLevel >= int.Parse(card.Value[CardElement.Level]))
            {
                card.Value[CardElement.IsLocked] = "False";
            }

            if(!bool.Parse(card.Value[CardElement.IsLocked]))
            {
                card.Value[CardElement.HasBeenLookedAt] = "True";
            }
        }
    }

    #endregion
}
