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
    private bool isCardPlayed = false;
    public Player Owner { get; private set; }

    public void SetOwnerPlayer(Player player, Transform playerCardsParent, int index)
    {
        isCardPlayed = false;
        Owner = player;
        MoveToPlayerHand(player, playerCardsParent, index);
        transform.parent = playerCardsParent;
    }

    public void PlayCard(Transform playPos)
    {
        if(Owner is NPCPlayer)
        {
           Flip();
        }
        else
        {
            this.transform.DORotate(new Vector3(0, -90, this.transform.rotation.z), movementDuration);
        }

        this.transform.DOMove(playPos.position + (RoundManager.Instance.RoundCount-1) * 0.01f *Vector3.up, movementDuration)
                      .onComplete += () => GroundManager.Instance.AddCardToGround(this);

        isCardPlayed = true;
    }

    public void Flip()
    {
        //this.transform.localScale = new Vector3(this.transform.localScale.x, -this.transform.localScale.y, this.transform.localScale.z);
        this.transform.DOScaleY(-this.transform.localScale.y, movementDuration);
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
        this.transform.DOMove(player.transform.position + index * 0.4f * playerCardsParent.forward + index * 0.05f * playerCardsParent.up, movementDuration);
        this.transform.forward = -playerCardsParent.right;

        if (player is UserPlayer)
        {
            this.transform.DORotate(new Vector3(-37.71f, 270, 0), 0.3f); //by experiment this is the best view for player
            Flip();
        }
        Owner = player;
    }

    private void OnMouseDown()
    {
        if (isCardPlayed) return;

        if (Owner is UserPlayer && RoundManager.Instance.IsUserTurn) //to prevent from clicking on other players' cards
        {
            RoundManager.Instance.SetIsUserTurn(false); //can't click again until next turn 
            StartCoroutine(Owner.PlayTurn(this));
        }
    }
}

[Serializable]
public class CardData
{
    public CardNumber CardNumber;
    public CardSuits CardSuit;
}