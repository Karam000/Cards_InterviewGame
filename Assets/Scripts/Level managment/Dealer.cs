using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for the dealing mechanism in CCW order
/// </summary>
public class Dealer : MonoBehaviour
{
    [SerializeField] float dealingDelay = 0.1f;
    
    /// <summary>
    /// Deal cards in CCW order
    /// </summary>
    /// <param name="deck">The deck object containing all cards</param>
    /// <returns></returns>
    public IEnumerator DealCards(Deck deck)
    {
        PlayersManager.Instance.RandomizeFirstPlayer(); 
        int i = 0;
        GameFeelManager.Instance.PlayDealingAudio();
        while (deck.Cards.Count > 0)
        {
            PlayersManager.Instance.GetPlayerCCW(i).AddCardToHand(deck.PopCard()); //deal cards (card by card from the deck) in ccw order
            yield return new WaitForSeconds(dealingDelay);
            i++;
        }
        GameFeelManager.Instance.StopAudio();
    }
}
