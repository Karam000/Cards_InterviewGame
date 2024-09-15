using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardRanker : MonoBehaviour
{
    public static Card GetMaxCard(List<Card> cards)
    {
        List<Card> orderedCards = RankCards(cards);

        return orderedCards[0];
    }
    private static List<Card> RankCards(List<Card> cards)
    {
        var orderedCards = cards
                          .OrderByDescending(card => (int)card.CardData.CardNumber)
                          .ThenByDescending(card => (int)card.CardData.CardSuit);

        return orderedCards.ToList();
    }
}
