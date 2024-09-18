using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utiltiy class for filling and setting cards data automatedly
/// </summary>
public class CardDataFiller_Editor : MonoBehaviour
{
    [SerializeField] private List<Card> cards;

    [ContextMenu("Fill card data")]
    private void FillData()
    {
        int cardCounter = 0;
        while (cardCounter < cards.Count)
        {
            for (int i = 0; i < Enum.GetValues(typeof(CardSuits)).Length; i++)
            {
                for (int j = 0; j < Enum.GetValues(typeof(CardNumber)).Length; j++)
                {
                    cards[cardCounter].CardData.CardNumber = (CardNumber)j;
                    cards[cardCounter].CardData.CardSuit = (CardSuits)i;
                    cards[cardCounter].gameObject.name = ((CardSuits)i).ToString() + " " + ((CardNumber)j).ToString();
                    cardCounter++;
                    continue;
                }
                //cardCounter %= Enum.GetValues(typeof(CardNumber)).Length;
            }
        }
    }

    [ContextMenu("Rename cards by data")]
    private void RenameCardsByData()
    {
        foreach (var card in cards)
        {
            card.gameObject.name = card.CardData.CardSuit.ToString() + " " + card.CardData.CardNumber.ToString();
        }
    }
}