using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlayer : Player
{
    public override IEnumerator PlayTurn(Card card = null)
    {
        yield return new WaitForSeconds(0.6f); //simulate NPC thinking
        maxCard = CardRanker.GetMaxCard(myCards);
        maxCard.PlayCard(playedCardsPosition);
        myCards.Remove(maxCard);
    }
}
