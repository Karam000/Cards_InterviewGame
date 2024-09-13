using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPlayer : Player
{
    public override void PlayCard(Card card)
    {
        card.PlayCard(playedCardsPosition);
    }
}
