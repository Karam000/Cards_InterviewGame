using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// Reponsibler for handling the playground of the level
/// </summary>
public class GroundManager : MonoBehaviour
{
    EndTurnCommand EndTurnCommand = new(); //invoked everytime a player plays card to the playground
    List<Card> GroundCards = new();  //list of currently played cards on the playground

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
        //Adding observers to EndTurnCommand
        EndTurnCommand.AddObserver(PlayersManager.Instance);    
        EndTurnCommand.AddObserver(RoundManager.Instance);
    }

    /// <summary>
    /// Add card to GroundCards list and excute the EndTurnCommand
    /// </summary>
    /// <param name="card">the card that has been played</param>
    public void AddCardToGround(Card card)
    {
        card.transform.parent = this.transform;
        GroundCards.Add(card);
        EndTurnCommand.Execute(EndTurnCommand);
    }

    /// <summary>
    /// called at the end of every round (4 turns) to reset
    /// </summary>
    public void ResetCards()
    {
        GroundCards.Clear();
    }

    /// <summary>
    /// Get the best card on the ground based on number and suit
    /// </summary>
    /// <returns>the best card on the ground</returns>
    public Card GetMaxPlayedCard()
    {
        return CardRanker.GetMaxCard(GroundCards);
    }
    
}
