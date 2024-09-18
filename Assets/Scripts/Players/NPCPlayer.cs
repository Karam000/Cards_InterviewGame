using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child of Player.
/// <br>Represents an NPC player that can't be controlled by the User.</br>
/// </summary>
public class NPCPlayer : Player
{
    /// <summary>
    /// Play NPC turn.
    /// <br>1. simulate thinking (time and emoji)</br>
    /// <br>2. play best card in hand</br>
    /// </summary>
    /// <param name="card">the card to be played</param>
    /// <returns></returns>
    public override IEnumerator PlayTurn(Card card = null)
    {
        float thinkingTime = GameFeelManager.Instance.SimulateNPCThinking(this);
        yield return new WaitForSeconds(thinkingTime); //simulate NPC thinking
        maxCard = CardRanker.GetMaxCard(myCards);
        maxCard.PlayCard(playedCardsPosition);
        myCards.Remove(maxCard);
    }
}
