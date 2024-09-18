using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
  

    EndTurnCommand EndTurnCommand = new();
    List<Card> GroundCards = new();

    public static GroundManager Instance;

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
        //if(card.Owner is NPCPlayer) 
        //   card.Flip();

        card.transform.parent = this.transform;
        GroundCards.Add(card);
        EndTurnCommand.Execute(EndTurnCommand);
    }

    public void ResetCards()
    {
        GroundCards.Clear();
    }

    public Card GetMaxPlayedCard()
    {
        return CardRanker.GetMaxCard(GroundCards);
    }
    
}
