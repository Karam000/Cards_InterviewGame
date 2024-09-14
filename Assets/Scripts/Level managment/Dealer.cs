using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField] float dealingDelay = 0.1f;
    
    public IEnumerator DealCards(Deck deck)
    {
        PlayersManager.Instance.RandomizeFirstPlayer(); 
        int i = 0;
        while (deck.Cards.Count > 0)
        {
            PlayersManager.Instance.GetPlayerCCW(i).AddCardToHand(deck.PopCard()); //deal cards (card by card from the deck) in ccw order
            yield return new WaitForSeconds(dealingDelay);
            i++;
        }
    }
}
