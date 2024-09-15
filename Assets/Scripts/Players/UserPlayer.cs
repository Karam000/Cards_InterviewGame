using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPlayer : Player
{
    public override IEnumerator PlayTurn(Card card = null)
    {
       yield return null;
       card.PlayCard(playedCardsPosition);
    }
}
