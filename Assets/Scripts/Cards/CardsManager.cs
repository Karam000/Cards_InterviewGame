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
        return CardRanker.GetMaxCard(GroundCards);
    }
    
}
