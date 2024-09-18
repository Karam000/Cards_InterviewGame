using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField] Transform myCardsParent;
    [SerializeField] protected Transform playedCardsPosition;
    public Transform EmojiPosition;

    public int Score { get; protected set; }
    public Card maxCard { get; protected set; }

    protected List<Card> myCards = new();
    protected int playCount = 0;

    public virtual void AddCardToHand(Card card)
    {
        myCards.Add(card);
        //card move animation to player hand
        card.SetOwnerPlayer(this, myCardsParent, myCards.Count-1);    

        myCardsParent.transform.DOMove(myCardsParent.transform.position - myCardsParent.forward * 0.4f, 0.08f); //to keep cards centered
    }

   
    public abstract IEnumerator PlayTurn(Card card = null);

    public void AddScorePoint()
    {
        Score++;
    }
   
}
