using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlayer : Player
{
    public override void PlayTurn(Card card = null)
    {
        maxCard = CardRanker.GetMaxCard(myCards);
        maxCard.PlayCard(playedCardsPosition);
        myCards.Remove(maxCard);
        print(this.gameObject.name+" played "+maxCard.name);
    }
}
