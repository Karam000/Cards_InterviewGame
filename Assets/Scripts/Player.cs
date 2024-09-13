using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform myCardsParent;
    Stack<Card> myCards = new();

    public void AddCard(Card card)
    {
        myCards.Push(card);
        //card move animation to player hand
        card.MoveToPlayer(this, myCards.Count-1);    

        card.transform.parent = myCardsParent;
        myCardsParent.transform.DOMove(myCardsParent.transform.position - Vector3.forward * 0.2f, 0.08f); //to keep cards centered
    }

    public void PlayCard()
    {

    }
}
