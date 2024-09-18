using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for handling cards as a whole stack
/// </summary>
public class Deck : MonoBehaviour
{
    [SerializeField] private List<Card> CardsList; //just to serialize in the inspector
    [SerializeField] private float shuffleDuration = 1.0f;
    [SerializeField] private float shuffleDistance = 2.0f; // How far the cards move during the shuffle

    public Stack<Card> Cards = new(); //better to simulate real behavior as we only need to pop the top most card

    private bool isShuffled;

    private void Start()
    {
        CardsListToStack();
    }

    /// <summary>
    /// convert the inspector CardsList to stack for easier programmatic operations
    /// </summary>
    private void CardsListToStack()
    {
        //I don't like this and may eventually decide to just use the list
        Cards.Clear();
        foreach (var card in CardsList)
        {
            Cards.Push(card);
        }
    }

    /// <summary>
    /// Pops a card from the cards stack
    /// </summary>
    /// <returns></returns>
    public Card PopCard() => Cards.Pop();


    /// <summary>
    /// visual for organizing the cards on top of each other
    /// </summary>

    [ContextMenu("Organize in a deck form")]
    private void OrganizeCards()
    {
        for (int i = CardsList.Count - 1; i > 0; i--)
        {
            CardsList[i].transform.position = this.transform.position + ((CardsList.Count - 1 - i) * 0.01f * Vector3.up);
        }
    }


    /// <summary>
    /// Shuffle the cards at the beginning of every run
    /// </summary>
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
            //CardsList[k].transform.DOShakePosition(1f, 0.5f);  >>> trying to simulate shuffle animation simply (doesn't feel good)
            CardsList[n] = CardsList[k];
            //CardsList[n].transform.DOShakePosition(1f, 0.5f);
            CardsList[k] = temp;
        }
        OrganizeCards();
        //ShuffleAnimation(); >>> not working for some reason
        CardsListToStack();
    }


    /// <summary>
    /// Animate cards shuffling
    /// </summary>
    private void ShuffleAnimation()
    {
        isShuffled = false;

        Vector3[] originalPositions = new Vector3[CardsList.Count];

        for (int i = 0; i < CardsList.Count; i++)
        {
            originalPositions[i] = new Vector3(CardsList[i].transform.position.x, CardsList[i].transform.position.y, CardsList[i].transform.position.z);
            Vector3 randomPosition = originalPositions[i] + new Vector3(
                Random.Range(-shuffleDistance, shuffleDistance),
                0,
                Random.Range(-shuffleDistance, shuffleDistance));

            // Move card to a random position
            CardsList[i].transform.DOMove(randomPosition, shuffleDuration / 2)
                .onComplete += () =>
                {
                    print("Card got to random");
                    // Move card back to its original position
                    CardsList[i].transform.DOMove(originalPositions[i], shuffleDuration / 2)
                       .OnComplete(() => isShuffled = true);
                };
        }
    }
}