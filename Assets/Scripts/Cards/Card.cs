using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private float movementDuration = 0.8f; //best to move to a scriptable object
    public CardData CardData;
    public Player Owner {get; private set;}

    public void SetOwnerPlayer(Player player,Transform playerCardsParent ,int index)
    {
        Owner = player;
        MoveToPlayerHand(player, index);
        transform.parent = playerCardsParent;
    }

    public void PlayCard(Transform playPos)
    {
        this.transform.DOMove(playPos.position, movementDuration); //here we should be notified abt turn end
        GroundCardsManager.Instance.AddCardToGround(this);
    }

    private void MoveToPlayerHand(Player player, int index)
    {
        this.transform.DOMove(player.transform.position + index *  0.2f * Vector3.forward , movementDuration);
        Owner = player;
    }

    private void OnMouseDown()
    {
        if (Owner is UserPlayer) //to prevent from clicking on other players' cards
            Owner.PlayTurn(this);
    }
}

[Serializable]
public class CardData
{
    public CardNumber CardNumber;
    public CardSuits CardSuit;
}