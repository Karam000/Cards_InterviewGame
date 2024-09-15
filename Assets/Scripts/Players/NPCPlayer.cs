using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlayer : Player
{
    public override void AddCardToHand(Card card)
    {
        base.AddCardToHand(card);

        maxCard = CardRanker.GetMaxCard(myCards);
    }
    public override void PlayTurn(Card card = null)
    {
        maxCard.PlayCard(playedCardsPosition);
    }
}
