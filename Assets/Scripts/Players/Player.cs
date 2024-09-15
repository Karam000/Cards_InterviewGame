using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField] Transform myCardsParent;
    [SerializeField] protected Transform playedCardsPosition;

    protected List<Card> myCards = new();
    protected Card maxCard;
    public int Score { get; protected set; }
    public virtual void AddCardToHand(Card card)
    {
        myCards.Add(card);
        //card move animation to player hand
        card.SetOwnerPlayer(this, myCardsParent, myCards.Count-1);    

        myCardsParent.transform.DOMove(myCardsParent.transform.position - myCardsParent.forward * 0.2f, 0.08f); //to keep cards centered
    }
    public abstract IEnumerator PlayTurn(Card card = null);

    public void AddScorePoint()
    {
        Score++;
    }
   
}
