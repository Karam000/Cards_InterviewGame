using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardRanker : MonoBehaviour
{
    List<Card> GroundCards = new();

    public static CardRanker Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCardToGround(Card card) //we need an observer for when a card is played and when is done playing, so many listeners in these two instances
    {
        GroundCards.Add(card);
    }

    public Card GetMaxPlayedCard()
    {
        return GetMaxCard(GroundCards);
    }
    public Card GetMaxCard(List<Card> cards)
    {
        RankCards(cards);

        return cards[0];
    }
    private void RankCards(List<Card> cards)
    {
        var orderedCards = cards
                          .OrderByDescending(card => card.CardData.CardNumber)
                          .ThenByDescending(card => card.CardData.CardSuit);
                           
        cards = orderedCards.ToList();
    }


    
}
