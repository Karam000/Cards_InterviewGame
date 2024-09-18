using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child of Player. Represents the User player.
/// </summary>
public class UserPlayer : Player
{
    //private Card currentFocusedCard;
    public override IEnumerator PlayTurn(Card card = null)
    {
       yield return null;
       card.PlayCard(playedCardsPosition);
    }

    //public void FocusCard(Card card)
    //{
    //    if(currentFocusedCard != null && card != currentFocusedCard)
    //       currentFocusedCard.UnFocus(false);

    //    card.Focus();
    //    currentFocusedCard = card;
    //}
}
