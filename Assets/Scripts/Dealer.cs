using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField] List<Player> Players;
    [SerializeField] float dealingSpeed = 0.1f;
    public IEnumerator DealCards(Deck deck)
    {
        int startingPlayerId = Random.Range(0, Players.Count); //exclusive so will be max: count-1
        int i = 0;
        while (deck.Cards.Count > 0)
        {
            Players[(startingPlayerId + i) % Players.Count].AddCard(deck.Cards.Pop()); //deal cards (card by card from the deck) in ccw order
            yield return new WaitForSeconds(dealingSpeed);
            i++;
        }
       
    }
}
