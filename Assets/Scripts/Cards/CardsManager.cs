using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    EndTurnCommand EndTurnCommand = new();
    List<Card> GroundCards = new();

    public static CardsManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        EndTurnCommand.AddObserver(PlayersManager.Instance);    
        EndTurnCommand.AddObserver(RoundManager.Instance);
    }
    public void AddCardToGround(Card card)
    {
        GroundCards.Add(card);
        EndTurnCommand.Execute(EndTurnCommand);
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
