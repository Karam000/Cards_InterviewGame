using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] List<Card> CardsList;

    public Stack<Card> Cards = new();
    private void Start()
    {
        foreach (var card in CardsList)
        {
            Cards.Push(card);
        }
    }

    public Card GetTopCard() => Cards.Pop();
   
    public void ShuffleCardS()
    {

    }
    

}
