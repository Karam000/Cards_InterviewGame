using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private float movementDuration = 0.8f; //best to move to a scriptable object
    public CardData CardData;

    private int clickCount = 0;
    public Player Owner {get; private set;}

    public void SetOwnerPlayer(Player player,Transform playerCardsParent ,int index)
    {
        Owner = player;
        MoveToPlayerHand(player, playerCardsParent, index);
        transform.parent = playerCardsParent;
    }

    public void PlayCard(Transform playPos)
    {
        this.transform.DOMove(playPos.position, movementDuration)
                      .onComplete+= ()=> GroundManager.Instance.AddCardToGround(this);
    }
    public void Flip()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, -this.transform.localScale.y, this.transform.localScale.z);
    }
   
    public void Focus()
    {
        this.transform.DOScale(0.3f, 0.5f);
        this.transform.DOMoveY(1, 0.5f);
        print("focusing card: " + name);
        //this.transform.DOMoveX(-0.1f, 0.5f);
    }

    public void UnFocus(bool instant)
    {
        clickCount = 0;
        this.transform.DOScale(-0.3f, (instant ? 0 : 0.5f));
        this.transform.DOMoveY(-1, (instant ? 0 : 0.5f));
        print("UNfocusing card: " + name);

        //this.transform.DOMoveX(0.1f, (instant ? 0 : 0.5f));
    }
    private void MoveToPlayerHand(Player player, Transform playerCardsParent, int index)
    {
        this.transform.DOMove(player.transform.position + index *  0.4f * playerCardsParent.forward + index * 0.05f * playerCardsParent.up, movementDuration);
        this.transform.forward = -playerCardsParent.right;
        if(player is UserPlayer)
        {
            Flip();
        }
        Owner = player;
    }

    private void OnMouseDown()
    {
        if (Owner is UserPlayer) //to prevent from clicking on other players' cards
        {
            //clickCount++;
            //if (clickCount >= 2)
            {
                //UnFocus(false);
                StartCoroutine(Owner.PlayTurn(this));
            }
            //else
            //{
            //    (Owner as UserPlayer).FocusCard(this);
            //}
        }
            
    }
}

[Serializable]
public class CardData
{
    public CardNumber CardNumber;
    public CardSuits CardSuit;
}