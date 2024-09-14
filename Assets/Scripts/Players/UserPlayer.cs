using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPlayer : Player
{
    public override void PlayTurn(Card card = null)
    {
        card.PlayCard(playedCardsPosition);
    }
}
