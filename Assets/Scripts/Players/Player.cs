using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all players. Has main properties and functions to represent a player.
/// <br>pretty much self-explainatory :)</br>
/// </summary>
public abstract class Player : MonoBehaviour
{
    [SerializeField] Transform myCardsParent;
    [SerializeField] protected Transform playedCardsPosition;
    public Transform EmojiPosition;

    public int Score { get; protected set; }
    public Card maxCard { get; protected set; }

    protected List<Card> myCards = new();
    protected int playCount = 0;

    /// <summary>
    /// Add card to this player hand
    /// </summary>
    /// <param name="card">the card to be added</param>
    public virtual void AddCardToHand(Card card)
    {
        myCards.Add(card);
        //card move animation to player hand
        card.SetOwnerPlayer(this, myCardsParent, myCards.Count-1);    

        myCardsParent.transform.DOMove(myCardsParent.transform.position - myCardsParent.forward * 0.4f, 0.08f); //to keep cards centered
    }

   /// <summary>
   /// called when it's this player's turn to play
   /// </summary>
   /// <param name="card">the card to play if this is a user (the mouse clicked card)</param>
   /// <returns></returns>
    public abstract IEnumerator PlayTurn(Card card = null);

    /// <summary>
    /// Increment score
    /// </summary>
    public void AddScorePoint()
    {
        Score++;
    }
   
}
