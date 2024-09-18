using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class representing a playing card. responsible for a card operations as a single entity (as opposed to Deck)
/// </summary>
public class Card : MonoBehaviour
{
    [SerializeField] private float movementDuration = 0.8f; //best to move to a scriptable object
    public CardData CardData;

    //private int clickCount = 0;
    private bool isCardPlayed = false; //to prevent from playing again when on the ground

    /// <summary>
    /// my owner player. returns null when the card is played
    /// </summary>
    public Player Owner { get; private set; } 


    /// <summary>
    /// Set the owner of this card.
    /// </summary>
    /// <param name="player">owner player</param>
    /// <param name="playerCardsParent">where to parent this card to</param>
    /// <param name="index">index of this card in the player's hand (to move vertically a bit for visuals)</param>
    public void SetOwnerPlayer(Player player, Transform playerCardsParent, int index)
    {
        isCardPlayed = false;
        Owner = player;
        MoveToPlayerHand(player, playerCardsParent, index);
        transform.parent = playerCardsParent;
    }

    /// <summary>
    /// Move card to player hand (mererly an animation)
    /// </summary>
    /// <param name="player">owner player</param>
    /// <param name="playerCardsParent">where to parent this card to</param>
    /// <param name="index">index of this card in the player's hand (to move vertically a bit for visuals)</param>
    private void MoveToPlayerHand(Player player, Transform playerCardsParent, int index)
    {
        this.transform.DOMove(player.transform.position + index * 0.4f * playerCardsParent.forward + index * 0.05f * playerCardsParent.up, movementDuration);
        this.transform.forward = -playerCardsParent.right;

        if (player is UserPlayer)
        {
            this.transform.DORotate(new Vector3(-37.71f, 270, 0), 0.3f); //by experiment this is the best view for player
            Flip();
        }
    }

    /// <summary>
    /// Play card to the ground.
    /// </summary>
    /// <param name="playPos">the play position of the owner player</param>
    public void PlayCard(Transform playPos)
    {
        if(Owner is NPCPlayer)
        {
           Flip();
        }
        else
        {
            this.transform.DORotate(new Vector3(0, -90, this.transform.rotation.z), movementDuration); //nice feeling :)
        }

        GameFeelManager.Instance.PlayCardAudio();

        //move card to the playground
        this.transform.DOMove(playPos.position + (RoundManager.Instance.RoundCount-1) * 0.01f *Vector3.up, movementDuration)
                      .onComplete += () => GroundManager.Instance.AddCardToGround(this);

        isCardPlayed = true;
    }

    /// <summary>
    /// flip the card
    /// </summary>
    public void Flip()
    {
        this.transform.DOScaleY(-this.transform.localScale.y, movementDuration);
    }

    #region focus card - not working
    //public void Focus()
    //{
    //    this.transform.DOScale(0.3f, 0.5f);
    //    this.transform.DOMoveY(1, 0.5f);
    //    print("focusing card: " + name);
    //    //this.transform.DOMoveX(-0.1f, 0.5f);
    //}

    //public void UnFocus(bool instant)
    //{
    //    clickCount = 0;
    //    this.transform.DOScale(-0.3f, (instant ? 0 : 0.5f));
    //    this.transform.DOMoveY(-1, (instant ? 0 : 0.5f));
    //    print("UNfocusing card: " + name);

    //    //this.transform.DOMoveX(0.1f, (instant ? 0 : 0.5f));
    //} 
    #endregion

    

    //user input
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

/// <summary>
/// Simple class representing the value data of the card
/// </summary>
[Serializable]
public class CardData
{
    public CardNumber CardNumber;
    public CardSuits CardSuit;
}