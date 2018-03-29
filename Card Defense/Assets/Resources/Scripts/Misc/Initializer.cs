using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    #region Start

    void Start ()
    {
        GameManager.Instance.Load();

        // Uncomment to reset level saves
        LevelSelectManager.Instance.SaveLevelInfo();

        LevelSelectManager.Instance.LoadLevelInfo();

        if (GameManager.Instance.currentDeck.Count == 0)
        {
            GameManager.Instance.CreateDefaultDeck(Cards.BasicResource, Cards.Basic);
            GameManager.Instance.deckType1 = DeckType.Basic;
            GameManager.Instance.deckType2 = DeckType.None;

            GameManager.Instance.Save();
        }
    }

    #endregion
}