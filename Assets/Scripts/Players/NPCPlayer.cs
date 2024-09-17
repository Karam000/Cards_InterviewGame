using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlayer : Player
{
    
    public override IEnumerator PlayTurn(Card card = null)
    {
        float thinkingTime = GameFeelManager.Instance.SimulateNPCThinking(this);
        yield return new WaitForSeconds(thinkingTime); //simulate NPC thinking
        maxCard = CardRanker.GetMaxCard(myCards);
        maxCard.PlayCard(playedCardsPosition);
        myCards.Remove(maxCard);
    }
}
