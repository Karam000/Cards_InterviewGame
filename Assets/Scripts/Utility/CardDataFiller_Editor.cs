using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataFiller_Editor : MonoBehaviour
{
    [SerializeField] List<Card> cards;

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
                    cards[cardCounter].gameObject.name = ((CardSuits)i).ToString()+" "+ ((CardNumber)j).ToString();
                    cardCounter++;
                    continue;
                }
                //cardCounter %= Enum.GetValues(typeof(CardNumber)).Length;
            } 
        }
    }
}
