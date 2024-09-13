using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlayer : Player
{
    public override void PlayCard(Card card)
    {
        maxCard.PlayCard(playedCardsPosition);
    }
}
