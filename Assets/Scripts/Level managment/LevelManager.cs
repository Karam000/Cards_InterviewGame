using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Dealer Dealer;
    [SerializeField] Deck Deck;
    void Start()
    {
        StartCoroutine(Dealer.DealCards(Deck));
    }

    private void LevelSequence()
    {

    }

    
}
