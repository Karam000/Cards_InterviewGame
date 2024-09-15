using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] List<Card> CardsList; //just to serialize in the inspector

    public Stack<Card> Cards = new(); //better to simulate real behavior as we only need to pop the top most card
    private void Start()
    {
        CardsListToStack();
    }

    private void CardsListToStack()
    {
        //I don't like this and may eventually decide to just use the list
        Cards.Clear();
        foreach (var card in CardsList)
        {
            Cards.Push(card);
        }
    }

    public Card PopCard() => Cards.Pop();

    [ContextMenu("Shuffle")]
    public void ShuffleCardS()
    {
        //using Knuth shuffle (modern for Fisher-Yates)

        System.Random r = new System.Random();
        //Step 1: For each unshuffled item in the collection
        for (int n = CardsList.Count - 1; n > 0; --n)
        {
            //Step 2: Randomly pick an item which has not been shuffled
            int k = r.Next(n + 1);

            //Step 3: Swap the selected item with the last "unstruck" item in the collection
            Card temp = CardsList[n];
            CardsList[n] = CardsList[k];
            CardsList[k] = temp;
        }

        CardsListToStack();
    }
    

}
