using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField] float dealingDelay = 0.1f;
    
    public IEnumerator DealCards(Deck deck)
    {
        PlayersManager.Instance.SetFirstPlayer(); 
        int i = 0;
        while (deck.Cards.Count > 0)
        {
            PlayersManager.Instance.GetPlayerByIndex(i).AddCard(deck.GetTopCard()); //deal cards (card by card from the deck) in ccw order
            yield return new WaitForSeconds(dealingDelay);
            i++;
        }
    }
}
