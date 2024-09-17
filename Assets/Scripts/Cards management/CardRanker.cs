using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardRanker : MonoBehaviour
{
    public static Card GetMaxCard(List<Card> cards)
    {
        RankCards(ref cards);

        return cards[0];
    }

    //public static bool CompareCards(Card card1, Card card2)
    //{

    //}
    private static void RankCards(ref List<Card> cards)
    {
        var orderedCards = cards
                          .OrderByDescending(card => (int)card.CardData.CardNumber)
                          .ThenByDescending(card => (int)card.CardData.CardSuit);

        cards = orderedCards.ToList();
    }

    
}
