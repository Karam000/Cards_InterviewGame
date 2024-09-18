using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Utility class to rank/compare cards values
/// </summary>
public class CardRanker : MonoBehaviour
{
    /// <summary>
    /// Get max card in a list 
    /// </summary>
    /// <param name="cards">list of cards to rank</param>
    /// <returns>best card in the list</returns>
    public static Card GetMaxCard(List<Card> cards)
    {
        RankCards(ref cards);

        return cards[0];
    }

    //public static bool CompareCards(Card card1, Card card2)
    //{

    //}

    /// <summary>
    /// order by number then suit
    /// </summary>
    /// <param name="cards"></param>
    private static void RankCards(ref List<Card> cards)
    {
        var orderedCards = cards
                          .OrderByDescending(card => (int)card.CardData.CardNumber)
                          .ThenByDescending(card => (int)card.CardData.CardSuit);

        cards = orderedCards.ToList();
    }

    
}
